using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAdmin.DataModel
{
    public class Address
    {

     
        public Guid Id { get; set; }
        public string? PhysicalAddress { get; set; }
        public string? PostalAddress { get; set; }
        public Guid StudentId { get; set; }

    }
}
