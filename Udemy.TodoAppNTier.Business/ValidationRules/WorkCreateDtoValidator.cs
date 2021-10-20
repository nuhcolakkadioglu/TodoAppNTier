using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.Dtos.WorkDtos;

namespace Udemy.TodoAppNTier.Business.ValidationRules
{
    public class WorkCreateDtoValidator : AbstractValidator<WorkCreateDto>
    {
        public WorkCreateDtoValidator()
        {
            RuleFor(m => m.Definition).NotEmpty().WithMessage("bu alan boş geçilemez").Must(NuhOlamaz).WithMessage("Nuh olamaz");
        }

        private bool NuhOlamaz(string arg)
        {
            if (arg == "nuh") return false;
            else
                return true;
        }
    }
}
