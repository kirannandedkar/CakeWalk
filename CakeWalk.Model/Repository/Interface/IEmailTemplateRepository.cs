using CakeWalk.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeWalk.Model.Repository.Interface
{
    // Befor you started need to add comment
    public interface IEmailTemplateRepository
    {
        EmailTemplateDTO GetEmailTemplateByEmailTemplateName(string emailTemplateName);
    }
}
