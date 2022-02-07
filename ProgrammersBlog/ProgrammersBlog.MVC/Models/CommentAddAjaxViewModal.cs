using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.MVC.Models
{
    public class CommentAddAjaxViewModal
    {
        public CommentAddDto CommemtAddDto { get; set; }

        public string CommentAddPartial { get; set; }
        public CommentDto CommentDto { get; set; }
    }
}
