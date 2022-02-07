using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Sevices.Concreate;
using ProgrammersBlog.Sevices.Utilities;
using ProgrammersBlog.Shared.Utilities.Result.Abstract;
using ProgrammersBlog.Shared.Utilities.Result.Complex_Types;
using ProgrammersBlog.Shared.Utilities.Result.Concreate;


namespace ProgrammersBlog.Services.Concrete
{
    public class CommentManager: ManagerBase, ICommentService
    {
      

        public CommentManager(IUnitOfWork unitOfWork, IMapper mapper):base(unitOfWork, mapper)
        {
           
        }

        public async Task<IDataResult<CommentDto>> GetAsync(int commentId)
        {
            var comment = await UnitofWork.Comments.GetAsync(c => c.ıd == commentId);
            if (comment != null)
            {
                return new DataResult<CommentDto>(ResultStatus.Success, new CommentDto
                {
                    Comment = comment,
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: false), new CommentDto
            {
                Comment = null,
            });
        }

        public async Task<IDataResult<CommentUpdateDto>> GetCommentUpdateDtoAsync(int commentId)
        {
            var result = await UnitofWork.Comments.AnyAsync(c => c.ıd == commentId);
            if (result)
            {
                var comment = await UnitofWork.Comments.GetAsync(c => c.ıd == commentId);
                var commentUpdateDto = Mapper.Map<CommentUpdateDto>(comment);
                return new DataResult<CommentUpdateDto>(ResultStatus.Success, commentUpdateDto);
            }
            else
            {
                return new DataResult<CommentUpdateDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: false), null);
            }
        }

        public async Task<IDataResult<CommentListDto>> GetAllAsync()
        {
            var comments = await UnitofWork.Comments.GetAllAsync(null,c=>c.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: true), new CommentListDto
            {
                Comments = null,
            });
        }

        public async Task<IDataResult<CommentListDto>> GetAllByDeletedAsync()
        {
            var comments = await UnitofWork.Comments.GetAllAsync(c=>c.IsDeleted, c => c.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: true), new CommentListDto
            {
                Comments = null,
            });
        }

        public async Task<IDataResult<CommentListDto>> GetAllByNonDeletedAsync()
        {
            var comments = await UnitofWork.Comments.GetAllAsync(c => !c.IsDeleted, c => c.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: true), new CommentListDto
            {
                Comments = null,
            });
        }

        public async Task<IDataResult<CommentListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var comments = await UnitofWork.Comments.GetAllAsync(c => !c.IsDeleted&&c.IsActive, c => c.Article);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: true), new CommentListDto
            {
                Comments = null,
            });
        }
       
        public async Task<IDataResult<CommentDto>> AddAsync(CommentAddDto commentAddDto)
        {
            var articles = await UnitofWork.Articles.GetAsync(x => x.ıd == commentAddDto.ArticleId);
            if (articles == null)
            {
                return new DataResult<CommentDto>(ResultStatus.Error,Messages.Article.NotFound(isPlural:false),data:null);
            }
            var comment = Mapper.Map<Comment>(commentAddDto);
            var addedComment = await UnitofWork.Comments.AddAsync(comment);
            articles.CommentCount += 1;
            await UnitofWork.Articles.UpdateAsync(articles);
            await UnitofWork.SaveAsync();
            return new DataResult<CommentDto>(ResultStatus.Success, Messages.Comment.Add(commentAddDto.CreatedByName), new CommentDto
            {
                Comment = addedComment,
            });
        }

        public async Task<IDataResult<CommentDto>> UpdateAsync(CommentUpdateDto commentUpdateDto, string modifiedByName)
        {
            var oldComment = await UnitofWork.Comments.GetAsync(c => c.ıd == commentUpdateDto.ıd);
            var comment = Mapper.Map<CommentUpdateDto, Comment>(commentUpdateDto, oldComment);
            comment.ModifiedByName = modifiedByName;
            var updatedComment = await UnitofWork.Comments.UpdateAsync(comment);
            updatedComment.Article = await UnitofWork.Articles.GetAsync(a => a.ıd == updatedComment.ArticleId);
            await UnitofWork.SaveAsync();
            return new DataResult<CommentDto>(ResultStatus.Success, Messages.Comment.Update(comment.CreatedByName), new CommentDto
            {
                Comment = updatedComment,
            });
        }

        public async Task<IDataResult<CommentDto>> DeleteAsync(int commentId, string modifiedByName)
        {
            var comment = await UnitofWork.Comments.GetAsync(c => c.ıd == commentId, c=>c.Article);
            if (comment != null)
            {
                var article = comment.Article;
                comment.IsDeleted = true;
                comment.IsActive = false;
                comment.ModifiedByName = modifiedByName;
                comment.ModifiedDateTime = DateTime.Now;
                var deletedComment = await UnitofWork.Comments.UpdateAsync(comment);
                article.CommentCount -= 1;
                await UnitofWork.Articles.UpdateAsync(article);
                await UnitofWork.SaveAsync();
                return new DataResult<CommentDto>(ResultStatus.Success, Messages.Comment.Delete(deletedComment.CreatedByName), new CommentDto
                {
                    Comment = deletedComment,
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: false), new CommentDto
            {
                Comment = null,
            });
        }

        public async Task<IResult> HardDeleteAsync(int commentId)
        {
           
            var comment = await UnitofWork.Comments.GetAsync(c => c.ıd == commentId,c=>c.Article);
            if (comment != null)
            {
                if (comment.IsDeleted)
                {
                    await UnitofWork.Comments.DeleteAsync(comment);
                    await UnitofWork.SaveAsync();
                    return new Result(ResultStatus.Success, Messages.Comment.HardDelete(comment.CreatedByName));
                }
                    var araticle = comment.Article;
                await UnitofWork.Comments.DeleteAsync(comment);
                araticle.CommentCount = await UnitofWork.Comments.CountAsync(c => c.ArticleId == araticle.ıd && !c.IsDeleted);
                await UnitofWork.Articles.UpdateAsync(araticle);
                await UnitofWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Comment.HardDelete(comment.CreatedByName));
            }
            return new Result(ResultStatus.Error, Messages.Comment.NotFound(isPlural: false));
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var commentsCount = await UnitofWork.Comments.CountAsync();
            if (commentsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, commentsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var commentsCount = await UnitofWork.Comments.CountAsync(c=>!c.IsDeleted);
            if (commentsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, commentsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<CommentDto>> ApproveAsync(int commentıd,string modifiedbyname)
        {
            var comment =await UnitofWork.Comments.GetAsync(c => c.ıd == commentıd,  c=>c.Article);

            if (comment != null)
            {
                var article = comment.Article;
                comment.IsActive = true;
                comment.ModifiedByName = modifiedbyname;
                comment.ModifiedDateTime = DateTime.Now;
                var newcomment = await UnitofWork.Comments.UpdateAsync(comment);
                article.CommentCount = await UnitofWork.Comments.CountAsync(c => c.ArticleId == article.ıd && !c.IsDeleted);
                await UnitofWork.Articles.UpdateAsync(article);

                await UnitofWork.SaveAsync();
                return new DataResult<CommentDto>(ResultStatus.Success,message: Messages.Comment.Approve(commentıd), new CommentDto
                {
                    Comment = newcomment
                });
            }

            else
            {
                return new DataResult<CommentDto>(ResultStatus.Error, message: Messages.Comment.NotFound(isPlural: false),data:null);
            }
        }

        public async Task<IDataResult<CommentDto>> UndoDeleteAsync(int commentId, string modifiedByName)
        {

            var comment = await UnitofWork.Comments.GetAsync(c => c.ıd == commentId, c => c.Article);
            if (comment != null)
            {
                var araticle = comment.Article;
                comment.IsDeleted = false;
                comment.IsActive = true;
                comment.ModifiedByName = modifiedByName;
                comment.ModifiedDateTime = DateTime.Now;
                var deletedComment = await UnitofWork.Comments.UpdateAsync(comment);
                araticle.CommentCount += 1;
                await UnitofWork.Articles.UpdateAsync(araticle);
                await UnitofWork.SaveAsync();
                return new DataResult<CommentDto>(ResultStatus.Success, Messages.Comment.UndoDelete(deletedComment.CreatedByName), new CommentDto
                {
                    Comment = deletedComment,
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, Messages.Comment.NotFound(isPlural: false), new CommentDto
            {
                Comment = null,
            });
        }
    }
}
