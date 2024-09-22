using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TimeSheets_App.Model;

namespace TimeSheets_App.Data
{
    public class TimesheetDbContext : DbContext
    {
        public TimesheetDbContext(DbContextOptions<TimesheetDbContext> options) : base(options)
        {
        }

        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<Model.Activity> Activities { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Project>   Projects { get; set; }

        public DbSet<SubProject> SubProjects { get; set; }
        public DbSet<Batch> Batches { get; set; }
    }
}
