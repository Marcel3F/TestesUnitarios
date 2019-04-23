using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteUnitario.Api.Domain;
using TesteUnitario.Api.Interfaces;

namespace TesteUnitario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoComprasController : ControllerBase
    {
        private readonly ICarrinhoComprasService _carrinhoComprasService;

        public CarrinhoComprasController(ICarrinhoComprasService carrinhoComprasService)
        {
            _carrinhoComprasService = carrinhoComprasService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemCompra>> ListarItens()
        {
            var itens = _carrinhoComprasService.ListarTodos();
            return Ok(itens);
        }

        [HttpGet("{id}")]
        public ActionResult<ItemCompra> ObterItem(Guid id)
        {
            var item = _carrinhoComprasService.ObterItemPorId(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public ActionResult AdicionarItem([FromBody] ItemCompra itemCompra)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = _carrinhoComprasService.Adicionar(itemCompra);
            return CreatedAtAction("ObterItem", new { id = item.Id }, item);
        }
        
        [HttpDelete("{id}")]
        public ActionResult RemoverItem(Guid id)
        {
            var item = _carrinhoComprasService.ObterItemPorId(id);

            if (item == null)
                return NotFound();

            _carrinhoComprasService.Remover(id);
            return Ok();
        }
    }
}
