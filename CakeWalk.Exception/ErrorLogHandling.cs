using CakeWalk.DAL;
using CakeWalk.DAL.Entity.Table;
using CakeWalk.Exceptions.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeWalk.Exceptions
{
   public class ErrorLogHandling
    {
        CakeWalkDBContext dataContext;
        private IConfiguration _configuration;

        public ErrorLogHandling(CakeWalkDBContext context, IConfiguration Configuration)
        {
            dataContext = context;
            _configuration = Configuration;

        }
        /// <summary>
        /// Save Error  
        /// </summary>
        /// <param name="IPAddress">IPAddress</param>
        /// <param name="LogType">LogType</param>
        /// <param name="ModuleName">ModuleName</param>
        /// <param name="TrackTrace">TrackTrace</param>
        /// <param name="SystemErrorMesage">SystemErrorMesage</param>
        /// <param name="CustomErrorMessage">CustomErrorMessage</param>
        public void SaveError(string IPAddress, string LogType, string ModuleName, string TrackTrace, string SystemErrorMesage, string CustomErrorMessage)
        {
            try
            {
                ErrorLog error = new ErrorLog();
                error.CreatedAt = DateTime.UtcNow;
                error.IPAddress = IPAddress;
                error.CustomErrorMessage = CustomErrorMessage;
                error.LogType = LogType;
                error.ModuleName = ModuleName;
                error.SystemErrorMessage = SystemErrorMesage;
                error.TrackTrace = TrackTrace;
                dataContext.ErrorLogs.Add(error);
                dataContext.SaveChanges();

                if (Convert.ToBoolean(_configuration["EnableSendErrorEmail"]) == true)
                {
                    EmailRequestErrorDTO emailrequest = new EmailRequestErrorDTO();
                    emailrequest.CC = _configuration["ErrorCC"];
                    emailrequest.To = _configuration["ErrorTo"];
                    emailrequest.IPAddress = IPAddress;
                    emailrequest.CustomErrorMessage = CustomErrorMessage;
                    emailrequest.LogType = LogType;
                    emailrequest.ModuleName = ModuleName;
                    emailrequest.SystemErrorMesage = SystemErrorMesage;
                    emailrequest.TrackTrace = TrackTrace;
                    emailrequest.CreatedAt = error.CreatedAt;
                    emailrequest.EmailTemplateName = "ERRORLOGEMAIL";
                    EmailHelperError ehelper = new EmailHelperError(dataContext, _configuration);
                    ehelper.SendErrorMail(emailrequest);
                }
            }
            catch 
            {

            }
        }

        /// <summary>
        /// Save Success 
        /// </summary>
        /// <param name="IPAddress">IPAddress</param>
        /// <param name="LogType">LogType</param>
        /// <param name="ModuleName">ModuleName</param>
        /// <param name="TrackTrace">TrackTrace</param>
        /// <param name="SystemErrorMesage">SystemErrorMesage</param>
        /// <param name="CustomErrorMessage">CustomErrorMessage</param>
        public void SaveSuccess(string IPAddress, string LogType, string ModuleName, string TrackTrace, string SystemErrorMesage, string CustomErrorMessage, string portalName)
        {
            try
            {
                ErrorLog error = new ErrorLog();
                error.CreatedAt = DateTime.Now;
                error.IPAddress = IPAddress;
                error.CustomErrorMessage = CustomErrorMessage;
                error.LogType = LogType;
                error.ModuleName = ModuleName;
                error.SystemErrorMessage = SystemErrorMesage;
                error.TrackTrace = TrackTrace;
                CakeWalkDBContext dataContext = new CakeWalkDBContext();
                dataContext.ErrorLogs.Add(error);
                dataContext.SaveChanges();
            }
            catch
            {

            }
        }
    }
}
