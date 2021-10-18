using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDeCasa.Models
{
    public class Loja
    {
        [Key]
        public long id { get; set; }

        // TODO: Definir método correto de autenticação para inserção de CPF > Padrão 12345678900 ou 123.456.789-00
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(18, ErrorMessage = "Precisa ter entre 14 e 18 caracteres")]
        [MinLength(14, ErrorMessage = "Precisa ter entre 14 e 18 caracteres")]
        public string cnpj { get; set; }

        // TODO: Definir política de senha de acordo com autenticação
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(30, ErrorMessage = "Precisa ter entre 8 e 30 caracteres")]
        [MinLength(8, ErrorMessage = "Precisa ter entre 8 e 30 caracteres")]
        public string senha { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [EmailAddress(ErrorMessage = "Insira um endereço de e-mail válido")]
        public string email { get; set; }

        [MaxLength(60, ErrorMessage = "Precisa ter entre 8 e 60 caracteres")]
        [MinLength(8, ErrorMessage = "Precisa ter entre 8 e 60 caracteres")]
        public string nome { get; set; }

        [ConcurrencyCheck]
        public double saldo { get; set; }

    }
}
