using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteUnitario.Api.Domain
{
    public class ItemCompra
    {
        public ItemCompra(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        [Required]
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public string Fabricante { get; private set; }

        public void AdicionarDetalhesItemCompra(string nome, decimal preco, string fabricante)
        {
            Nome = nome;
            Preco = preco;
            Fabricante = fabricante;
        }
    }
}
