using Microsoft.AspNetCore.Identity;

namespace Restaurant.Data
{
    public class Client : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Meal> Meals { get; set; }
        public ICollection<Bevarage> Bevarages { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }

}
