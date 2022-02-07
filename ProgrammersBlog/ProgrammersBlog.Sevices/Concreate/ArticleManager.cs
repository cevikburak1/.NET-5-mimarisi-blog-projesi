
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concreate;
using ProgrammersBlog.Entities.Complex_Type;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Sevices.Abstract;
using ProgrammersBlog.Sevices.Utilities;
using ProgrammersBlog.Shared.Utilities.Result.Abstract;
using ProgrammersBlog.Shared.Utilities.Result.Complex_Types;
using ProgrammersBlog.Shared.Utilities.Result.Concreate;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Sevices.Concreate
{
    public class ArticleManager : ManagerBase, IArticleService
    {


        private readonly UserManager<User> _userManager;

       

        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager) : base(unitOfWork, mapper)
        {
            _userManager = userManager;
        }


        public async Task<IResult> AddAsync(ArticleAddDto articleAddDto, string createdByName, int userId)
        {
            var article = Mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = userId;
            await UnitofWork.Articles.AddAsync(article);
            await UnitofWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Article.Add(article.Title));
        }

        public async Task<IDataResult<int>> Count()
        {
            var articlecount = await UnitofWork.Articles.CountAsync();

            if (articlecount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, articlecount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, "Beklenilmeyen bir hata ile karşılaşıldı", -1);
            }
        }

        public async Task<IDataResult<int>> CountByIsDeleted()
        {
            var articlecount = await UnitofWork.Articles.CountAsync(c => !c.IsDeleted);

            if (articlecount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, articlecount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, "Beklenilmeyen bir hata ile karşılaşıldı", -1);
            }
        }

        public async Task<IResult> Delete(int articleId, string ModifiedByName)
        {
            var result = await UnitofWork.Articles.AnyAsync(a => a.ıd == articleId);
            if (result)
            {
                var article = await UnitofWork.Articles.GetAsync(a => a.ıd == articleId);
                article.IsDeleted = true;
                article.IsActive = false;
                article.ModifiedByName = ModifiedByName;
                article.ModifiedDateTime = DateTime.Now;
                await UnitofWork.Articles.UpdateAsync(article);
                await UnitofWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Article.Delete(article.Title));
            }
            return new Result(ResultStatus.Error, Messages.Article.NotFound(isPlural: false));
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleıd)
        {
            var art = await UnitofWork.Articles.GetAsync(a => a.ıd == articleıd, u=>u.User);
            var article = await UnitofWork.Articles.GetAsync(a=> a.ıd == articleıd, b => b.Category);
         
            //article.User = art.User;
            //var article = await UnitofWork.Articles.GetAsync(a => a.ıd == articleıd, a => a.User, a => a.Category, a => a.Comments);
            if (article != null)
            {
                article.Comments = await UnitofWork.Comments.GetAllAsync(c => c.ArticleId == articleıd && !c.IsDeleted &&c.IsActive);
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, Messages.Article.NotFound(isPlural: false), null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await UnitofWork.Articles.GetAllAsync(null, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.Article.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result = await UnitofWork.Categories.AnyAsync(c => c.ıd == categoryId);
            if (result)
            {
                var articles = await UnitofWork.Articles.GetAllAsync(
                    a => a.CategoryId == categoryId && !a.IsDeleted && a.IsActive, ar => ar.User, ar => ar.Category);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.Article.NotFound(isPlural: true), null);
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: false), null);

        }

        public async Task<IDataResult<ArticleListDto>> GetAllByDeleted()
        {
            var articles = await UnitofWork.Articles.GetAllAsync(a => a.IsDeleted, ar => ar.User, ar => ar.Category);
           
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto

                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Makaleler bulunamadı", data: null);
            }
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await UnitofWork.Articles.GetAllAsync(predicate: a => a.IsDeleted == false, ar => ar.User, artciles => artciles.Category);
            throw new SqlNullValueException();
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto

                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {

                return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Makaleler bulunamadı", data: null);
            }
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await UnitofWork.Articles.GetAllAsync(a => a.IsDeleted == false && a.IsActive, ar => ar.User, ar => ar.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto

                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Makaleler bulunamadı", data: null);
            }
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByPagingAsync(int? categoryId, int cuurentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var articles = categoryId == null ? await UnitofWork.Articles.GetAllAsync(a => a.IsActive && !a.IsDeleted, a => a.Category, a => a.User) : await UnitofWork.Articles.GetAllAsync(a=>a.CategoryId==categoryId && a.IsActive && !a.IsDeleted, a => a.Category, a => a.User);
            var sortedarticels = isAscending ? articles.OrderBy(a => a.Date).Skip((cuurentPage - 1) * pageSize).Take(pageSize).ToList() : articles.OrderByDescending(a => a.Date).Skip((cuurentPage - 1) * pageSize).Take(pageSize).ToList();
            return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
            {
                Articles = sortedarticels,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = cuurentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending

            });
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByUserıdOnFilter(int userıd, FilterBy filterBy, OrderBy orderBy, bool isAscending, int takesize, int categoryıd, DateTime startAt, DateTime endAt, int minViewCount, int maxViewCount, int minCommenCountcount, int maxcommentcount)
        {
            var anyUser = await _userManager.Users.AnyAsync(u => u.Id == userıd);
            if (!anyUser)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Error, $"{userıd} numaralı kullanıcı bulunamadı.",
                    null);
            }

            var userArticles = await UnitofWork.Articles.GetAllAsync(a => a.IsActive && !a.IsDeleted && a.UserId == userıd);
            List<Article> sortedArticles = new List<Article>();
            switch (filterBy)
            {
                case FilterBy.Category:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.CategoryId == categoryıd).Take(takesize)
                                    .OrderBy(a => a.Date).ToList()
                                : userArticles.Where(a => a.CategoryId == categoryıd).Take(takesize)
                                    .OrderByDescending(a => a.Date).ToList();
                            break;
                        case OrderBy.ViewCount:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.CategoryId == categoryıd).Take(takesize)
                                    .OrderBy(a => a.ViewsCount).ToList()
                                : userArticles.Where(a => a.CategoryId == categoryıd).Take(takesize)
                                    .OrderByDescending(a => a.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentCount:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.CategoryId == categoryıd).Take(takesize)
                                    .OrderBy(a => a.CommentCount).ToList()
                                : userArticles.Where(a => a.CategoryId == categoryıd).Take(takesize)
                                    .OrderByDescending(a => a.CommentCount).ToList();
                            break;
                    }
                    break;
                case FilterBy.Date:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takesize)
                                    .OrderBy(a => a.Date).ToList()
                                : userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takesize)
                                    .OrderByDescending(a => a.Date).ToList();
                            break;
                        case OrderBy.ViewCount:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takesize)
                                    .OrderBy(a => a.ViewsCount).ToList()
                                : userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takesize)
                                    .OrderByDescending(a => a.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentCount:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takesize)
                                    .OrderBy(a => a.CommentCount).ToList()
                                : userArticles.Where(a => a.Date >= startAt && a.Date <= endAt).Take(takesize)
                                    .OrderByDescending(a => a.CommentCount).ToList();
                            break;
                    }
                    break;
                case FilterBy.ViewCount:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takesize)
                                    .OrderBy(a => a.Date).ToList()
                                : userArticles.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takesize)
                                    .OrderByDescending(a => a.Date).ToList();
                            break;
                        case OrderBy.ViewCount:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takesize)
                                    .OrderBy(a => a.ViewsCount).ToList()
                                : userArticles.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takesize)
                                    .OrderByDescending(a => a.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentCount:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takesize)
                                    .OrderBy(a => a.CommentCount).ToList()
                                : userArticles.Where(a => a.ViewsCount >= minViewCount && a.ViewsCount <= maxViewCount).Take(takesize)
                                    .OrderByDescending(a => a.CommentCount).ToList();
                            break;
                    }
                    break;
                case FilterBy.CommentCount:
                    switch (orderBy)
                    {
                        case OrderBy.Date:
                            sortedArticles = isAscending
                                ? userArticles.Where(a =>
                                        a.CommentCount >= minCommenCountcount && a.CommentCount <= maxcommentcount)
                                    .Take(takesize)
                                    .OrderBy(a => a.Date).ToList()
                                : userArticles.Where(a =>
                                        a.CommentCount >= minCommenCountcount && a.CommentCount <= maxcommentcount)
                                    .Take(takesize)
                                    .OrderByDescending(a => a.Date).ToList();
                            break;
                        case OrderBy.ViewCount:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.CommentCount >= minCommenCountcount && a.CommentCount <= maxcommentcount)
                                    .Take(takesize)
                                    .OrderBy(a => a.ViewsCount).ToList()
                                : userArticles.Where(a => a.CommentCount >= minCommenCountcount && a.CommentCount <= maxcommentcount)
                                    .Take(takesize)
                                    .OrderByDescending(a => a.ViewsCount).ToList();
                            break;
                        case OrderBy.CommentCount:
                            sortedArticles = isAscending
                                ? userArticles.Where(a => a.CommentCount >= minCommenCountcount && a.CommentCount <= maxcommentcount)
                                    .Take(takesize)
                                    .OrderBy(a => a.CommentCount).ToList()
                                : userArticles.Where(a => a.CommentCount >= minCommenCountcount && a.CommentCount <= maxcommentcount)
                                    .Take(takesize)
                                    .OrderByDescending(a => a.CommentCount).ToList();
                            break;
                    }

                    break;
            }

            return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
            {
                Articles = sortedArticles
            });
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByViewCountAsync(bool isAscending, int? takesize)
        {
            var article = await UnitofWork.Articles.GetAllAsync(x => x.IsActive == true && !x.IsDeleted, b => b.Category, d => d.User);
            var sortedArticles = isAscending ? article.OrderBy(a => a.ViewsCount) : article.OrderByDescending(a => a.ViewsCount);

            return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
            {
                Articles = takesize == null ? sortedArticles.ToList() : sortedArticles.Take(takesize.Value).ToList()
            });
        }

        public async Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDtoAsync(int articleId)
        {
            var result = await UnitofWork.Articles.AnyAsync(c => c.ıd == articleId);
            if (result)
            {
                // patlama
                var article = await UnitofWork.Articles.GetAsync(c => c.ıd == articleId);
                var articleUpdateDto = Mapper.Map<ArticleUpdateDto>(article);
                return new DataResult<ArticleUpdateDto>(ResultStatus.Success, articleUpdateDto);
            }
            else
            {
                return new DataResult<ArticleUpdateDto>(ResultStatus.Error, message: Messages.Category.NotFound(isPlural: false), null);
            }
        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var result = await UnitofWork.Articles.AnyAsync(a => a.ıd == articleId);
            if (result)
            {
                var article = await UnitofWork.Articles.GetAsync(a => a.ıd == articleId);


                await UnitofWork.Articles.DeleteAsync(article);
                await UnitofWork.SaveAsync();
                return new Result(ResultStatus.Success, message: $"{article.Title} Başlıklı makale başarı ile Veri Tabanından silinmiştir");
            }
            else
            {
                return new Result(ResultStatus.Error, message: " Böyle bir Makale bulunamadı");
            }
        }

        public async Task<IResult> IncreaseViewCountAsync(int articleıd)
        {
            var article = await UnitofWork.Articles.GetAsync(a => a.ıd == articleıd);
            if (article == null)
            {
                return new Result(ResultStatus.Error, Messages.Article.NotFound(isPlural: false));
            }
            article.ViewsCount += 1;
          await  UnitofWork.Articles.UpdateAsync(article);
            await UnitofWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Article.IncreaseViewCountAsync(article.Title));
        }

        public async Task<IDataResult<ArticleListDto>> SearchAsync(string keyword,  int cuurentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            if (string.IsNullOrWhiteSpace(keyword))
            {
                var articles = await UnitofWork.Articles.GetAllAsync(a => a.IsActive && !a.IsDeleted, a => a.Category, a => a.User);
                var sortedarticels = isAscending ? articles.OrderBy(a => a.Date).Skip((cuurentPage - 1) * pageSize).Take(pageSize).ToList() : articles.OrderByDescending(a => a.Date).Skip((cuurentPage - 1) * pageSize).Take(pageSize).ToList();
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = sortedarticels,
                    CurrentPage = cuurentPage,
                    PageSize = pageSize,
                    TotalCount = articles.Count,
                    IsAscending = isAscending

                }); 

            }

            var searcharticles = await UnitofWork.Articles.SearchAsync(new List<Expression<Func<Article, bool>>>
            {
                (a)=>a.Title.Contains(keyword),
                (a)=>a.Category.Name.Contains(keyword),
                (a)=>a.SeoDescription.Contains(keyword),
                (a)=>a.SeoTags.Contains(keyword)
            }
            ,a=>a.Category,a=>a.User);

            var searchAndSortedarticels = isAscending ? searcharticles.OrderBy(a => a.Date).Skip((cuurentPage - 1) * pageSize).Take(pageSize).ToList() : searcharticles.OrderByDescending(a => a.Date).Skip((cuurentPage - 1) * pageSize).Take(pageSize).ToList();
            return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
            {
                Articles = searchAndSortedarticels,
                CurrentPage = cuurentPage,
                PageSize = pageSize,
                TotalCount = searcharticles.Count,
                IsAscending = isAscending

            });
        }

        public async Task<IResult> UndoDelete(int articleId, string ModifiedByName)
        {
            var result = await UnitofWork.Articles.AnyAsync(a => a.ıd == articleId);
            if (result)
            {
                var article = await UnitofWork.Articles.GetAsync(a => a.ıd == articleId);
                article.IsDeleted = false;
                article.IsActive = true;
                article.ModifiedByName = ModifiedByName;
                article.ModifiedDateTime = DateTime.Now;
                await UnitofWork.Articles.UpdateAsync(article);
                await UnitofWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Article.UndoDelete(article.Title));
            }
            return new Result(ResultStatus.Error, Messages.Article.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            var oldArticle = await UnitofWork.Articles.GetAsync(a => a.ıd == articleUpdateDto.ıd); //Id
            var article = Mapper.Map<ArticleUpdateDto, Article>(articleUpdateDto, oldArticle);
            article.ModifiedByName = modifiedByName;
            await UnitofWork.Articles.UpdateAsync(article);
            await UnitofWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Article.Update(article.Title));
        }
    }
}
