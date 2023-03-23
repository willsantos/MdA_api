using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Domain.UsuarioContratos
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email é obrigatório para Login")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha do usuario é obrigatória.")]
        [StringLength(18, MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
