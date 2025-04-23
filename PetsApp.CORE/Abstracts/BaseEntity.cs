using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsApp.CORE.Enums;

namespace PetsApp.CORE.Abstracts
{
    public abstract class BaseEntity
    {
        //🐱🐶🐰
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Status Status { get; set; }
        
    }
}
