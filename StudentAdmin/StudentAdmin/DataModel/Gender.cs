using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAdmin.DataModel
{
    public class Gender
    {
   
        public Guid Id { get; set; }
        public string Description { get; set; }

    }
}
