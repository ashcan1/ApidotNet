using StudentAdmin.Model;

namespace StudentAdmin.DataModel
{
    public class UpdateStudentRequest
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public Guid GenderId { get; set; }
        public Address? PhysicalAddress { get; set; }
        public Address? PostalAddress { get; set; }

    }
}
