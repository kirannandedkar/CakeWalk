using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CakeWalk.DAL.Entity.Table
{
  public class EmailTemplate : BaseEntity
    {
        [Key]
        public int EmailTemplateID { get; set; }
        public string EmailTemplateName { get; set; }
        public string Subject { get; set; }
        public string EmailBody { get; set; }
    }
}
