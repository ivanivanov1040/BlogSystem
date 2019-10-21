using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Models
{
    public class ApplicationRoleModel : IdentityRole
    {
        public string Description { get; set; }
        public string Aditional { get; set; }
    }
}
