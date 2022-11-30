using FluentValidation;
using maipoGrandeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maipoGrande.Pages;

namespace maipoGrande.Validaciones
{
    public class Vusuarios : AbstractValidator<Usuario>
    {
        public Vusuarios() 
        {
            RuleFor(p => p.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El usuario esta vacio.")
                .Length(5, 10).WithMessage("El usuario debe tener entre 5 y 10 caracteres")
                .Must(LestrasValidas).WithMessage("El usuario contiene caracteres invalidos");
                
        }

        protected bool LestrasValidas(string Nombre)
        {
            Nombre = Nombre.Replace(" ", "");
            Nombre = Nombre.Replace("-", "");
            return Nombre.All(Char.IsLetter);
        }
    }
}
