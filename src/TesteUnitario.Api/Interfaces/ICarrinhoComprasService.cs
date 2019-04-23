using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteUnitario.Api.Domain;

namespace TesteUnitario.Api.Interfaces
{
    public interface ICarrinhoComprasService
    {
        IEnumerable<ItemCompra> ListarTodos();
        ItemCompra Adicionar(ItemCompra newItem);
        ItemCompra ObterItemPorId(Guid id);
        void Remover(Guid id);
    }
}
