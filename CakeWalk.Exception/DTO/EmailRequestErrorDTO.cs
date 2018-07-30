using System;
using System.Collections.Generic;
using System.Text;

namespace CakeWalk.Exceptions.DTO
{
   public class EmailRequestErrorDTO
    {
        public string To { get; set; }
        public string EmailTemplateName { get; set; }
        public string BCC { get; set; }
        public string CC { get; set; }
        public string IPAddress { get; set; }
        public string CustomErrorMessage { get; set; }
        public string ModuleName { get; set; }
        public string TrackTrace { get; set; }
        public string SystemErrorMesage { get; set; }
        public string LogType { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
    }
}
