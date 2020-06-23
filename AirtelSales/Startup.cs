using AirtelSales.DAL;
using AirtelSales.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirtelSales.Startup))]
namespace AirtelSales
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        private AirtelSalesDBEntities db = new AirtelSalesDBEntities();
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            //In Startup iam creating first Admin Role and creating a default Admin User
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool    
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new ApplicationUser();
                user.UserName = "admin@bluechiptech.biz";
                user.Email = "admin@bluechiptech.biz";


                string userPWD = "admin123";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                    var newUser = db.AspNetUsers.Find(user.Id);
                    
                    db.SaveChanges();
                }
            }

            // creating RegionalManager role     
            if (!roleManager.RoleExists("RegionalManager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "RegionalManager";
                roleManager.Create(role);

            }
            // creating ZonalManager role     
            if (!roleManager.RoleExists("ZonalManager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "ZonalManager";
                roleManager.Create(role);

            }

            //creating Creating AreaManager Operation
            if (!roleManager.RoleExists("AreaManager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "AreaManager";
                roleManager.Create(role);

            }

            //creating Creating MarketDeveloper Operation
            if (!roleManager.RoleExists("MarketDeveloper"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "MarketDeveloper";
                roleManager.Create(role);

            }

            //creating dealer role
            if (!roleManager.RoleExists("Dealer"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Dealer";
                roleManager.Create(role);

            }

            //Creating SubDealer role
            if (!roleManager.RoleExists("SubDealer"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "SubDealer";
                roleManager.Create(role);

            }

            // Creating Reseller
            if (!roleManager.RoleExists("Reseller"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Reseller";
                roleManager.Create(role);

            }
        }
    }
}
