using CakeWalk.DAL.Entity;
using CakeWalk.DAL.Entity.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeWalk.DAL
{
   public partial class CakeWalkDBContext
    {
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}
