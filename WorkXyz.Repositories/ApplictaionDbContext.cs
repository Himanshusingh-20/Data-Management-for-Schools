using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkXyz.Entities;


namespace WorkXyz.Repositories
{
    public class ApplictaionDbContext : DbContext
    {
        public ApplictaionDbContext(DbContextOptions<ApplictaionDbContext> options):base(options) {
        }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<StudentsNew> StudentsNew { get; set; }
        public DbSet<Subjects> Subjects { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        //Fluent Api Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherSubject>().HasKey(x => new {x.SubjectsId,x.TeacherId});
            base.OnModelCreating(modelBuilder);
        }
    }
}
