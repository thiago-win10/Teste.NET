using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }

        [Display(Name = "Email(opcional)")]
        public string Email2 { get; set; }
        public string Telefone { get; set; }

        [Display(Name = "Telefone(opcional)")]
        public string Telefone2 { get; set; }
        public ClienteEndereco ClienteEndereco { get; set; }
        public List<CarrinhoCompra> CarrinhoCompras { get; set; }

    }
}
