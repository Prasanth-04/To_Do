using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace To_Do.Entity
{
    public class AppUser

    {
        [Key]
        public int userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
