using System;
using System.Collections.Generic;
using System.Text;

namespace CakeWalk.Model.DTO
{
    // Befor you started need to add comment
   public class EmailTemplateDTO : BaseDTO
    {
        public int EmailTemplateID { get; set; }
        public string EmailTemplateName { get; set; }
        public string Subject { get; set; }
        public string EmailBody { get; set; }
    }
}
