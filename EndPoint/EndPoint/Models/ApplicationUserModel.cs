using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Models
{
    public class ApplicationUserModel : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JWT { get; set; }

        public ICollection<PostModel> Posts { get; set; }
        public ICollection<CommentModel> Comments { get; set; }
    }
}
