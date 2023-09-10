using Attendance_Management_System.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Management_System.Data
{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Privilage> Privilage { get; set; }
        public DbSet<UserPrivilege> UserPrivilege { get; set; }     
        public DbSet<Location> Location { get; set; }
        public DbSet<SignUp> SignUp { get; set; }
        public DbSet<SignIn> SignIn { get; set; }
        public DbSet<Approval> Approval { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<AdminSignUp> AdminSignUp { get; set; }

    }
}
