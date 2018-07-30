using System;
using System.Collections.Generic;
using System.Text;

namespace CakeWalk.DAL.Entity
{
   public class BaseEntity
    {
        public Nullable<DateTime> CreatedAt { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Nullable<int> DeletedBy { get; set; }
    }
}
