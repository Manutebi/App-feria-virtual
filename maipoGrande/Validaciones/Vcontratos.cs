using FluentValidation;
using maipoGrande.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maipoGrande.Validaciones
{
    public class Vcontratos : AbstractValidator<Addusuarios>
    {
        public Vcontratos() 
        {
            RuleFor(p => p)
                .NotEmpty().WithMessage("El contrato esta vacio.");
                
        }
    }
}
