using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TesteUnitario.Api.Domain;
using TesteUnitario.Api.Interfaces;

namespace TesteUnitario.ApiTestes.Mock
{
    public class CarrinhoComprasServiceFake : ICarrinhoComprasService
    {
        private IEnumerable<ItemCompra> _itemCompras;

        public CarrinhoComprasServiceFake()
        {   
            var item1 = new ItemCompra(Guid.Parse("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"));
            item1.AdicionarDetalhesItemCompra("Item 1", 5.00M, "Fabricante 1");

            var item2 = new ItemCompra();
            item2.AdicionarDetalhesItemCompra("Item 2", 10.00M, "Fabricante 2");

            var item3 = new ItemCompra();
            item3.AdicionarDetalhesItemCompra("Item 3", 15.00M, "Fabricante 3");

            _itemCompras = new List<ItemCompra>() { item1, item2, item3 };
        }

        public ItemCompra Adicionar(ItemCompra item)
        {
            _itemCompras.ToList().Add(item);
            return item;
        }

        public IEnumerable<ItemCompra> ListarTodos()
        {
            return _itemCompras;
        }

        public ItemCompra ObterItemPorId(Guid id)
        {
            return _itemCompras.FirstOrDefault(i => i.Id == id);
        }

        public void Remover(Guid id)
        {
            if (_itemCompras.Any(a => a.Id == id))
            {
                var itemList = _itemCompras.ToList();
                itemList.RemoveAll(i => i.Id == id);
                _itemCompras = itemList;
            }
        }
    }
}
