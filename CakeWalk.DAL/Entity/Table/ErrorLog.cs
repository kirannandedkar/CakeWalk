using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CakeWalk.DAL.Entity.Table
{
   public class ErrorLog
    {
        [Key]
        public int ErrorLogID { get; set; }
        public string IPAddress { get; set; }
        public string CustomErrorMessage { get; set; }
        public string ModuleName { get; set; }
        public string TrackTrace { get; set; }
        public string SystemErrorMessage { get; set; }
        public string LogType { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
    }
}
