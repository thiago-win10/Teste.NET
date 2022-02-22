﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models

{
    public class ClienteEndereco
    {
        public int ClienteEnderecoId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
    }
}