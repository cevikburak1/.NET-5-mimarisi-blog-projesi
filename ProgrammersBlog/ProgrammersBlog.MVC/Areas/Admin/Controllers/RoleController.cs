using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.MVC.Areas.Admin.Models;
using ProgrammersBlog.Shared.Utilities.Extansions;
using ProgrammersBlog.Shared.Utilities.Result.Complex_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProgrammersBlog.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : BaseController
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleController(RoleManager<Role> roleManager,UserManager<User> userManager,IMapper mapper,IImageHelper ımageHelper ):base(userManager,mapper,ımageHelper)
        {
            _roleManager = roleManager;
        }

        [Authorize(Roles="SuperAdmin,Role.Read")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
           
            return View(new RoleListDto
            {
                Roles = roles
            });
            
        }

        [Authorize(Roles = "SuperAdmin,Role.Read")]
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var roleListDto = JsonSerializer.Serialize(new RoleListDto
            {
                Roles = roles
            });
            return Json(roleListDto);
        }


        [Authorize(Roles = "SuperAdmin,User.Update")]
        [HttpGet]
        public async Task<IActionResult> Assign(int userId)
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var user = await UserManager.Users.SingleOrDefaultAsync(c => c.Id == userId);
            var userroles = await UserManager.GetRolesAsync(user);

            UserRoleAssignDto userRoleAssiginDto = new UserRoleAssignDto
            {
                UserId = user.Id,
                UserName = user.UserName
            };

            foreach(var role in roles)
            {
                RoleAssignDto roleAssignDto = new RoleAssignDto
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    HasRole = userroles.Contains(role.Name)
                };

                userRoleAssiginDto.RoleAssignDtos.Add(roleAssignDto);
                }

            return PartialView("_RoleAssignPartial", userRoleAssiginDto);
          }

        [Authorize(Roles = "SuperAdmin,User.Update")]
        [HttpPost]
        public async Task<IActionResult> Assign(UserRoleAssignDto userRoleAssignDto)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.Users.SingleOrDefaultAsync(x => x.Id == userRoleAssignDto.UserId);
                foreach (var roleAssiginDto in userRoleAssignDto.RoleAssignDtos)
                {
                    if (roleAssiginDto.HasRole == true)

                    {
                        await UserManager.AddToRoleAsync(user, roleAssiginDto.RoleName);
                    }

                    else
                    {
                        await UserManager.RemoveFromRoleAsync(user, roleAssiginDto.RoleName);
                    }
                }

                var userroleassignAjaxviewmodal = JsonSerializer.Serialize(new UserRoleAssiginAjaxViewModal
                {
                    UserDto = new UserDto
                    {
                        User = user,
                        Message = $"{user.UserName} Kullanıcısna ait Rol atama işlemi başarı ile gerçekleşti :)",
                        ResultStatus = ResultStatus.Success
                    },
                    UserRoleAssignPartial = await this.RenderViewToStringAsync("_RoleAssiginPartial", userRoleAssignDto)
                });
                return Json(userroleassignAjaxviewmodal);
                }

            else
            {
                var roleassiginajaxerrormodal = JsonSerializer.Serialize(new UserRoleAssiginAjaxViewModal
                {
                    UserRoleAssignPartial = await this.RenderViewToStringAsync("_RoleAssiginPartial", userRoleAssignDto),
                    userRoleAssiginDto = userRoleAssignDto
                });
                return Json(roleassiginajaxerrormodal);
            }

           }
        }
    }
      

