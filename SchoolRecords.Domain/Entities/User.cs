using FluentValidation;
using SchoolRecords.Domain.Entities.Base;
using SchoolRecords.Shared.Constants.Validations.User;

namespace SchoolRecords.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public int? SchoolingId { get; set; }
        public Schooling Schooling { get; set; }

        public int? SchoolRecordId { get; set; }
        public SchoolRecord SchoolRecord { get; set; }


        public bool IsValid
        {
            get
            {
                var validator = new UserValidator();
                var results = validator.Validate(this);
                return results.IsValid;
            }
        }

        public List<string> Errors
        {
            get
            {
                var errors = new List<string>();

                var validator = new UserValidator();
                var results = validator.Validate(this);
                foreach (var failure in results.Errors)
                {
                    errors.Add("A propriedade " + failure.PropertyName + " é inválida. Mensagem: " + failure.ErrorMessage);
                }

                return errors;
            }
        }

        public void SetInactive()
        {
            Active = false;
        }
    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.BirthDate).LessThanOrEqualTo(DateTime.Now).WithMessage(UserValidationMessage.BIRTH_DATE_GREATER_THAN_TODAY);
            RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage(UserValidationMessage.BIRTH_DATE_GREATER_THAN_TODAY);
            RuleFor(user => user.Schooling).NotNull().WithMessage(UserValidationMessage.SCHOOLING_NULL);
        }
    }
}
