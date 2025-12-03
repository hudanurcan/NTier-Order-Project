using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Concrats.Models.ResponseModels.AppUserProfiles
{
    public class AppUserProfileResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DataStatus Status { get; set; }

    }
}
