using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSociety.Application.DTO.UserProfile
{
    public class GetSearchUserProfileDto
    {
        public string FullName { get; set; }
        public string Bio { get; set; }
        public int Id { get; set; }
    }
}
