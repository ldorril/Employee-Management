using FluentValidation;
using myprogramApi.Models;

namespace myprogramApi.Validators
{
    public class EmployeeValidator: AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Phone).NotEmpty();

        }

       
    }
}
