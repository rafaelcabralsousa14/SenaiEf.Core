﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.Domains
{
    public class Pedido
    {
        [Key]
        public Guid IdPedido { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        public Pedido()
        {
            IdPedido = Guid.NewGuid();
        }
    }
}
