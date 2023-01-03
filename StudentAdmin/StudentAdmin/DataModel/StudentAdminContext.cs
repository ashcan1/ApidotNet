using Microsoft.EntityFrameworkCore;
using StudentAdmin.DataModel;

namespace StudentAdmin.DataModel
{
    public class StudentAdminContext : DbContext
    {
        public StudentAdminContext(DbContextOptions<StudentAdminContext> options): base(options)
         {

        }
        // when we run ef core migration will create tables on sql server
        public DbSet <student> Student { get; set; }
        public DbSet <Gender> Gender { get; set; }
         
        public  DbSet<Address> Address { get; set; }


    }

        
  }

