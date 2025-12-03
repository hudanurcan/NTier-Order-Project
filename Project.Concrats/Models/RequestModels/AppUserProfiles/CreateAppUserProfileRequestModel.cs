using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Concrats.Models.RequestModels.AppUserProfiles
{
    public class CreateAppUserProfileRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; } // bir user ın bir profili olacak. bu yüzden profil oluştururken kullanıcdan var olan bir user id alıyoruz.
    }
}
