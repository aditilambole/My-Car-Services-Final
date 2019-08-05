using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyCarServicesFinal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should be of minimum 3 characters maximum 20 characters")]
        [RegularExpression(@"^([A-Za-z]+)", ErrorMessage = "Enter valid first name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter lastname")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "lastname should be of minimum 3 characters maximum 20 characters")]
        [RegularExpression(@"^([A-Za-z]+)", ErrorMessage = "Enter valid last name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter City")]
        public string City { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       
        public DbSet<Car> Cars { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}