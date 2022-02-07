 using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Entities.Complex_Type;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.MVC.Areas.Admin.Models;
using ProgrammersBlog.Shared.Utilities.Extansions;
using ProgrammersBlog.Shared.Utilities.Result.Complex_Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProgrammersBlog.MVC.Areas.Admin.Controllers
{

    [Area("Admin")]

    public class UserController : BaseController
    {
  
        private readonly SignInManager<User> _signInManager;
        

      

        public UserController(UserManager<User> userManager , IMapper mapper , SignInManager<User> signInManager, IImageHelper ımageHelper):base(userManager,mapper,ımageHelper)
        {
            
            _signInManager = signInManager;
          
        }

      

        [Authorize(Roles = "SuperAdmin,User.Read")]
        public async Task<IActionResult> Index()
        {
            var users = await UserManager.Users.ToListAsync();

                return View(new UserListDto 
                {
                    Users =  users,
                    ResultStatus = ResultStatus.Success


                });
        }


        [Authorize(Roles = "SuperAdmin,User.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllUsers()
        {
            var users = await UserManager.Users.ToListAsync();

      var userlistdto =  JsonSerializer.Serialize(new UserListDto
            {
                Users = users,
                ResultStatus = ResultStatus.Success

      }, new JsonSerializerOptions {ReferenceHandler = ReferenceHandler.Preserve });

            return Json(userlistdto);
        }



        [Authorize(Roles = "SuperAdmin,User.Create")]
        [HttpGet ]
        public  IActionResult Add()
        {
            return PartialView("_UserAddPartial");

           
        }

        [Authorize(Roles = "SuperAdmin,User.Create")]
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            if (ModelState.IsValid)
            {
               var uplodedImageDtoResult = await ImageHelper.Upload(userAddDto.UserName,userAddDto.PictureFile,PictureType.User);
                userAddDto.Picture = uplodedImageDtoResult.ResultStatus == ResultStatus.Success ? uplodedImageDtoResult.Data.FullName : "userImages/defaultUser.png";
                var user = Mapper.Map<User>(userAddDto);
                var result = await UserManager.CreateAsync(user, userAddDto.Password);
                if (result.Succeeded)
                {
                    var userAddAjaxModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
                    {
                        UserDto = new UserDto
                        {
                            ResultStatus = ResultStatus.Success,
                            Message = $"{user.UserName} adlı kullanıcı adına sahip, kullanıcı başarıyla eklenmiştir.",
                            User = user
                        },
                        UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
                    });
                    return Json(userAddAjaxModel);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    var userAddAjaxErrorModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
                    {
                        UserAddDto = userAddDto,
                        UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
                    });
                    return Json(userAddAjaxErrorModel);
                }

            }
            var userAddAjaxModelStateErrorModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
            {
                UserAddDto = userAddDto,
                UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
            });
            return Json(userAddAjaxModelStateErrorModel);

        }
      
        [Authorize(Roles = "SuperAdmin,User.Update")]
        [HttpGet]
        public async Task<PartialViewResult> Update(int userId)
        {
            var user = await UserManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var userUpdateDto = Mapper.Map<UserUpdateDto>(user);
            return PartialView("_UserUpdatePartial", userUpdateDto);

        }

        [Authorize(Roles = "SuperAdmin,User.Update")]
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userupdatedto)
        {
            if (ModelState.IsValid)
            {
                bool isNewPictureUplodad = false;
                var oldUser = await UserManager.FindByIdAsync(userupdatedto.Id.ToString());
                var oldUserPicture = oldUser.Picture;
                if (userupdatedto.PictureFile!=null)
                {
                    var uplodedImageDtoResult = await ImageHelper.Upload(userupdatedto.UserName, userupdatedto.PictureFile,PictureType.User);
                    userupdatedto.Picture = uplodedImageDtoResult.ResultStatus == ResultStatus.Success ? uplodedImageDtoResult.Data.FullName : "userImages/defaultUser.png";
                    if (oldUserPicture != "userImages/defaultUser.png")
                    {
                        isNewPictureUplodad = true;
                    } 
                }

                var uptadeduser = Mapper.Map<UserUpdateDto, User>(userupdatedto, oldUser);
                var result = await UserManager.UpdateAsync(uptadeduser);
                if (result.Succeeded)
                {
                    if (isNewPictureUplodad)
                    {
                        ImageHelper.Delete(oldUserPicture);

                    }
                    var userUpdateViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel
                    {
                        UserDto = new UserDto { ResultStatus = ResultStatus.Success, Message = $"{uptadeduser.UserName} adlı kullanıcı başarı ile güncellenmiştir", User = uptadeduser },
                        UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userupdatedto)
                    });
                    return Json(userUpdateViewModel);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(key: "", error.Description);
                    }
                    var userUpdateErrorViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel
                    {
                      UserUpdateDto =userupdatedto ,
                        UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userupdatedto)
                    });
                    return Json(userUpdateErrorViewModel);
                }
            }
            else
            {
                var userUpdateErrorModelStateViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel
                {
                    UserUpdateDto = userupdatedto,
                    UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userupdatedto)
                });
                return Json(userUpdateErrorModelStateViewModel);
            }
        }

        [Authorize(Roles = "SuperAdmin,User.Read")]
        [HttpGet]
        public async Task<PartialViewResult> GetDetail(int userId)
        {
            var user = await UserManager.Users.SingleOrDefaultAsync(u => u.Id == userId);
            return PartialView("_GetDetailPartial", new UserDto { User = user });
        }




        [Authorize(Roles = "SuperAdmin,User.Delete")]
        [HttpPost]

    public async Task<JsonResult> Delete(int userid)
        {
            var user = await UserManager.FindByIdAsync(userid.ToString());
            var resut = await UserManager.DeleteAsync(user);
            if (resut.Succeeded)
            {
                var deleteduser = JsonSerializer.Serialize(new UserDto { ResultStatus = ResultStatus.Success, Message = $"{user.UserName} adlı kullanıcı başarıyla silindi", User = user
                });
                return Json(deleteduser);
            }

            else 
            {
                string errormessage = String.Empty;
                foreach(var error in resut.Errors)
                {
                 errormessage =  $"*{error.Description}\n" ;
                }
                var deletedUserErrorModel = JsonSerializer.Serialize(new UserDto
                {
                    ResultStatus = ResultStatus.Error,
                    Message = $"{user.UserName} adlı kullanıcı adına sahip kullanıcı silinirken bazı hatalar oluştu.\n{errormessage}",
                    User = user

                });

                return Json(deletedUserErrorModel);
            }
        }

      




        [HttpGet]
        public IActionResult Login()
        {
            return View("UserLogin");
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(userLoginDto.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password,
                        userLoginDto.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                        return View("UserLogin");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                    return View("UserLogin");
                }
            }
            else
            {
                return View("UserLogin");
            }

        }
      

        [Authorize]
        [HttpGet]
        public async Task<ViewResult> ChangeDetails()
        {
            var user =await UserManager.GetUserAsync(HttpContext.User);
            var updatedto = Mapper.Map<UserUpdateDto>(user);
            return View(updatedto);
        }



        [Authorize]
        [HttpPost]
        public async Task<ViewResult> ChangeDetails(UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isNewPictureUplodad = false;
                var oldUser = await UserManager.GetUserAsync(HttpContext.User);
                var oldUserPicture = oldUser.Picture;
                if (userUpdateDto.PictureFile != null)
                {
                    var uplodedImageDtoResult = await ImageHelper.Upload(userUpdateDto.UserName, userUpdateDto.PictureFile,PictureType.User);
                    userUpdateDto.Picture = uplodedImageDtoResult.ResultStatus == ResultStatus.Success ? uplodedImageDtoResult.Data.FullName : "userImages/defaultUser.png";
                    if (oldUserPicture != "userImages/defaultUser.png")
                    {
                        isNewPictureUplodad = true;
                    }
                  
                }

                var uptadeduser = Mapper.Map<UserUpdateDto, User>(userUpdateDto, oldUser);
                var result = await UserManager.UpdateAsync(uptadeduser);
                if (result.Succeeded)
                {
                    if (isNewPictureUplodad)
                    {
                        ImageHelper.Delete(oldUserPicture);

                    }
                    TempData.Add("SuccsessMessage", $"{uptadeduser.UserName} adlı kullanıcı başarı ile güncellenmiştir");
                    return View(userUpdateDto);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(key: "", error.Description);
                    }
                    return View(userUpdateDto);
                }
            }
            else
            {
                return View(userUpdateDto);
            } 
        }
        [Authorize]
        [HttpGet]
        public ViewResult PasswordChange()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PasswordChange(UserPasswordChangeDto userPasswordChangeDto)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.GetUserAsync(HttpContext.User);
                var isVeriFied = await UserManager.CheckPasswordAsync(user, userPasswordChangeDto.CurrendPassword);
                if (isVeriFied)
                {
                    var result = await UserManager.ChangePasswordAsync(user, userPasswordChangeDto.CurrendPassword, userPasswordChangeDto.NewPassword);
                    if (result.Succeeded)
                    {
                        await UserManager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.PasswordSignInAsync(user, userPasswordChangeDto.NewPassword, true, false);
                        TempData.Add("SuccsessMessage", "Şifreniz başarı ile güncellenmiştir");
                        return View();

                    }

                    else
                    {
                        foreach(var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(userPasswordChangeDto);
                    }
                }
                else
                {
                    ModelState.AddModelError(" ", "Lütfen Girmiş oldugunuz şuan ki şifrenizi kontrol ediniz");
                    return View(userPasswordChangeDto);
                }
            }
            else
            {
                return View(userPasswordChangeDto);
            }
         
        }
    }
}
