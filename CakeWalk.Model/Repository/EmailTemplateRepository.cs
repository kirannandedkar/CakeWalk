using CakeWalk.DAL;
using CakeWalk.DAL.Entity.Table;
using CakeWalk.Model.DTO;
using CakeWalk.Model.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CakeWalk.Model.Repository
{
    // Befor you started need to add comment
    public class EmailTemplateRepository : BaseRepository<EmailTemplate, CakeWalkDBContext>, IEmailTemplateRepository
    {
        public static string IPAddress;
        private IConfiguration _configuration;
        public EmailTemplateRepository(CakeWalkDBContext dBContext, string ipAddress, IConfiguration Configuration)
        {
            base.dataContext = dBContext;
            IPAddress = ipAddress;
            _configuration = Configuration;
        }

        /// <summary>
        /// Get EmailTemplate By EmailTemplateName
        /// </summary>
        /// <param name="emailTemplateName"></param>
        /// <returns></returns>
        public EmailTemplateDTO GetEmailTemplateByEmailTemplateName(string emailTemplateName)
        {
            try
            {
                var emailTemplateData = (from e in dataContext.EmailTemplates
                                         where e.EmailTemplateName == emailTemplateName
                                         select new EmailTemplateDTO
                                         {
                                             EmailBody = e.EmailBody,
                                             EmailTemplateID = e.EmailTemplateID,
                                             EmailTemplateName = e.EmailTemplateName,
                                             Subject = e.Subject
                                         }).FirstOrDefault();
                return emailTemplateData;
            }
            catch (Exception ex)
            {
                CakeWalk.Exceptions.ErrorLogHandling errorLogHandling = new CakeWalk.Exceptions.ErrorLogHandling(dataContext, _configuration);
                errorLogHandling.SaveError(IPAddress, "System", "EmailTemplateRepository/GetEmailTemplateByEmailTemplateName", ex.StackTrace.ToString(), ex.Message.ToString(), "Error generating at GetEmailTemplateByEmailTemplateName in EmailTemplateRepository");
                return null;
            }
        }
    }
}
