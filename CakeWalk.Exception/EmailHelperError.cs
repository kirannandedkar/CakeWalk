using CakeWalk.DAL;
using CakeWalk.DAL.Entity;
using CakeWalk.DAL.Entity.Table;
using CakeWalk.Exceptions.DTO;
using CakeWalk.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Linq;

namespace CakeWalk.Exceptions
{
   public class EmailHelperError
    {
        CakeWalkDBContext dataContext;
        private IConfiguration _configuration;
       

        public EmailHelperError(CakeWalkDBContext context, IConfiguration Configuration)
        {
            dataContext = context;
            _configuration = Configuration;

        }

        /// <summary>
        /// SendErrorMail
        /// </summary>
        /// <param name="emailRequest"></param>
        /// <returns></returns>
        public bool SendErrorMail(EmailRequestErrorDTO emailRequest)
        {
            try
            {
                SendEmailHelper objEmail = new SendEmailHelper();
                objEmail.HostName = _configuration["HostName"];
                objEmail.Port = Int32.Parse(_configuration["Port"]);
                objEmail.FromEmail = _configuration["FromEmail"];
                objEmail.EnableSsl = true;
                objEmail.DeliveryMethod = SmtpDeliveryMethod.Network;
                objEmail.Password = _configuration["Password"];
                objEmail.UserName = _configuration["UserNameData"];
                objEmail.TO = emailRequest.To;
                if (emailRequest.CC != null)
                {
                    objEmail.CC = emailRequest.CC;
                }
                if (emailRequest.BCC != null)
                {
                    objEmail.BCC = emailRequest.BCC;
                }
                                   
               var emaiTemplate =  dataContext.EmailTemplates.FirstOrDefault(x => x.EmailTemplateName == emailRequest.EmailTemplateName);       
                if (emaiTemplate != null)
                {
                    objEmail.Subject = emaiTemplate.Subject;
                    string body = emaiTemplate.EmailBody;
                    if (emailRequest.IPAddress != null)
                    {
                        body = body.Replace("#IPAddress#", emailRequest.IPAddress);
                    }
                    if (emailRequest.LogType != null)
                    {
                        body = body.Replace("#LogType#", emailRequest.LogType);
                    }
                    if (emailRequest.CustomErrorMessage != null)
                    {
                        body = body.Replace("#CustomErrorMessage#", emailRequest.CustomErrorMessage);
                    }
                    if (emailRequest.ModuleName != null)
                    {
                        body = body.Replace("#ModuleName#", emailRequest.ModuleName);
                    }
                    if (emailRequest.TrackTrace != null)
                    {
                        body = body.Replace("#TrackTrace#", emailRequest.TrackTrace);
                    }
                    if (emailRequest.SystemErrorMesage != null)
                    {
                        body = body.Replace("#SystemErrorMesage#", emailRequest.SystemErrorMesage);
                    }
                    if (emailRequest.CreatedAt != null)
                    {
                        string currentDateString = String.Format("{0:MM-dd-yyyy}", emailRequest.CreatedAt);
                        body = body.Replace("#CreatedDate#", currentDateString);
                    }
                    body = body.Replace("#Year#", DateTime.Now.Year.ToString());
                    objEmail.Body = body;
                    var mail = objEmail.SendEmail();
                    return mail;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }
    }
}
