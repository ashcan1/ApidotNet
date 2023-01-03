using FluentValidation;
using StudentAdmin.DataModel;
using StudentAdmin.Repository;

namespace StudentAdmin.Validation
{
    public class AddStudentValiddata : AbstractValidator<AddStudent>
    {
        public AddStudentValiddata(IStudentRepository studentRepository)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Mobile).LessThan(9999999999).LessThan(100000000000);
            RuleFor(x => x.GenderId).NotEmpty().Must(Id =>
            {
                var gender = studentRepository.GetGender().Result.ToList()
                .FirstOrDefault(x => x.Id == Id);
                if (gender != null)
                {
                    return true;

                }
                return false;


            }).WithMessage("Please select valid gender");

            RuleFor(x => x.Address.PostalAddress).NotEmpty();
            RuleFor(x => x.Address.PhysicalAddress).NotEmpty();

        }
    }
}
