using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteUnitario.Api.Domain;
using TesteUnitario.Api.Interfaces;

namespace TesteUnitario.Api.Services
{
    public class CarrinhoComprasService : ICarrinhoComprasService
    {
        public ItemCompra Adicionar(ItemCompra newItem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemCompra> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public ItemCompra ObterItemPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
