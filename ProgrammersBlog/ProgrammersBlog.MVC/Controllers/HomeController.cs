using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NToastNotify;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Sevices.Abstract;
using ProgrammersBlog.Shared.Utilities.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly IMailService _mailService;
        private readonly IToastNotification _toastNotification;
        private readonly IWritableOptions<AboutUsPageInfo> _aboutuspageınfowriter;




        public HomeController(IArticleService articleService,IOptionsSnapshot<AboutUsPageInfo> aboutaspageınfo,IMailService mailService,IToastNotification toastNotification,IWritableOptions<AboutUsPageInfo> aboutuspageınfowriter)
        {
            _articleService = articleService;
            _aboutUsPageInfo = aboutaspageınfo.Value;
            _mailService = mailService;
            _toastNotification = toastNotification;
            _aboutuspageınfowriter = aboutuspageınfowriter;
        }

        public async Task<IActionResult> Index(int? categoryıd,int currentPage = 1,int pageSize = 5,bool IsAscending = false)
        {
            var articlesresult = await (categoryıd == null
                ? _articleService.GetAllByPagingAsync(null,currentPage,pageSize,IsAscending)
                : _articleService.GetAllByPagingAsync(categoryıd.Value,currentPage,pageSize, IsAscending));
            return View(articlesresult.Data);
        }
        [HttpGet]
        public IActionResult About()
        {
           
          
            return View(_aboutUsPageInfo);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Contact(EmailSendDto emailSendDto)
        {
            if (ModelState.IsValid)
            {
                var result = _mailService.SendContactEmail(emailSendDto);
                _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                {
                    Title = "Başarılı İşlem"
                });
                return View();
            }
            return View(emailSendDto);
        }


    }
}
