﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProgrammersBlog.Entities.Complex_Type;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Result.Abstract;


namespace ProgrammersBlog.Mvc.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadedDto>> Upload(string name, IFormFile pictureFile,PictureType pictureType ,string folderName = null);
        IDataResult<ImagerDeletedDto> Delete(string picturName);
    }
}