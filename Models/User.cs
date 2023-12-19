using Arowolo_Delivery_Project.Enums;
using Microsoft.AspNetCore.Identity;

namespace Arowolo_Delivery_Project.Models
{
    public class User : IdentityUser<Guid>, IBaseEntity
    {
        public string FullName { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        //public string Email { get; set; }
        public Gender Gender { get; set; } = Gender.Male;

        public string Address { get; set; } = string.Empty;

        // since the identity user comes with th e like of Id, password, email and phone Number
        //public string PhoneNumber { get; set; } = string.Empty;
        //public string Password { get; set; }

        public ICollection<Basket> BasketList { get; set; } = new List<Basket>();

        public DateTime CreateDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
