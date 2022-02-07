using ProgrammersBlog.Entities.Complex_Type;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Sevices.Abstract
{
    
   public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> Get(int articleId);
        Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDtoAsync(int articleId);
        Task<IDataResult<ArticleListDto>> GetAll();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeleted();
        Task<IDataResult<ArticleListDto>> GetAllByDeleted();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive();
        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId);
        Task<IDataResult<ArticleListDto>> GetAllByViewCountAsync(bool isAscending , int? takesize);
        Task<IDataResult<ArticleListDto>> GetAllByPagingAsync(int? categoryId,int cuurentPage=1, int pageSize=5,bool isAscending = false);
        Task<IDataResult<ArticleListDto>> GetAllByUserıdOnFilter(int userıd,FilterBy filterBy,OrderBy orderBy,bool isAscending,int takesize,int categoryıd,DateTime startAt,DateTime endAt,int minViewCount,int maxViewCount,int minCommenCountcount,int maxcommentcount);
        
       
        Task<IDataResult<ArticleListDto>> SearchAsync(string keyword, int cuurentPage = 1, int pageSize = 5, bool isAscending = false);
        Task<IResult> IncreaseViewCountAsync(int articleıd);
        Task<IResult> AddAsync(ArticleAddDto ArticleAddDto, string CreatedByName,int userId);
        Task<IResult> UpdateAsync(ArticleUpdateDto articleUpdateDto, string ModifiedByName);
        Task<IResult> Delete(int articleId, string ModifiedByName);
        Task<IResult> UndoDelete(int articleId, string ModifiedByName);
        Task<IResult> HardDelete(int articleId);

        Task<IDataResult<int>> Count();

        Task<IDataResult<int>> CountByIsDeleted();
    }
}
