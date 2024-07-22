using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace webapi.DTO.Inbound
{
    public class Dto_Usuario
    {
        [Required]
        [MinLength(10)]
        public string NumeroIdentificacao { get; set; }
        [Required]
        [MinLength(5)]
        public string NomeCompleto { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [Required]
        public string Telefone { get; set; }
        [Required]
        [MinLength(6)]
        public string Senha { get; set; }
        [Required]
        public int ProvinciaId { get; set; }
    }
}