using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.Domains
{
    public class Produto
    {
        [Key]
        public Guid IdProduto { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        public Produto()
        {
            IdProduto = Guid.NewGuid();
        }
    }
}
