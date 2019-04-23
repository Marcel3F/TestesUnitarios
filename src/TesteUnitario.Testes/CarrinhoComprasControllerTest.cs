using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteUnitario.Api.Controllers;
using TesteUnitario.Api.Domain;
using TesteUnitario.Api.Interfaces;
using TesteUnitario.ApiTestes.Mock;
using Xunit;

namespace TesteUnitario.ApiTestes
{
    public class CarrinhoComprasControllerTest
    {
        CarrinhoComprasController _controller;
        ICarrinhoComprasService _service;

        private readonly Guid testeId = Guid.Parse("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

        public CarrinhoComprasControllerTest()
        {
            _service = new CarrinhoComprasServiceFake();
            _controller = new CarrinhoComprasController(_service);
        }

        [Fact]
        public void ListarItens_Retorna_Ok()
        {
            // Act
            var okResult = _controller.ListarItens();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void ListarItens_Retorna_TodosItens()
        {
            // Act
            var okResult = _controller.ListarItens().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<ItemCompra>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void ObterItem_Retorna_NotFoundResult()
        {
            // Act
            var notFoundResult = _controller.ObterItem(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void ObterItem_Retorna_Ok()
        {
            // Arrange (testeId)

            // Act
            var okResult = _controller.ObterItem(testeId);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void ObterItem_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange (testeId)

            // Act
            var okResult = _controller.ObterItem(testeId).Result as OkObjectResult;

            // Assert
            Assert.IsType<ItemCompra>(okResult.Value);
            Assert.Equal(testeId, (okResult.Value as ItemCompra).Id);
        }

        [Fact]
        public void Adicionar_Retorna_BadRequest()
        {
            // Arrange
            var item = new ItemCompra();
            item.AdicionarDetalhesItemCompra(string.Empty, 12.00M, "Fabricante1");

            _controller.ModelState.AddModelError("Nome", "Required");

            // Act
            var badResponse = _controller.AdicionarItem(item);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
        
        [Fact]
        public void Adicionar_Retorna_CreatedResponse()
        {
            // Arrange
            var item = new ItemCompra();
            item.AdicionarDetalhesItemCompra("Item 4", 12.00M, "Fabricante1");

            // Act
            var createdResponse = _controller.AdicionarItem(item);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }
        
        [Fact]
        public void Adicionar_Retorna_ItemCriado()
        {
            // Arrange
            var item = new ItemCompra();
            item.AdicionarDetalhesItemCompra("Item 4", 12.00M, "Fabricante1");

            // Act
            var retorno = _controller.AdicionarItem(item) as CreatedAtActionResult;
            var itemRetornado = retorno.Value as ItemCompra;

            // Assert
            Assert.IsType<ItemCompra>(item);
            Assert.Equal("Item 4", item.Nome);
        }

        [Fact]
        public void Remover_Retorna_NotFound()
        {
            // Arrange
            var notExistingGuid = Guid.NewGuid();

            // Act
            var badResponse = _controller.RemoverItem(notExistingGuid);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remover_Retorna_Ok()
        {
            // Arrange (testeId)

            // Act
            var okResponse = _controller.RemoverItem(testeId);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }
        [Fact]
        public void Remover_ApenasUmItem()
        {
            // Arrange (testeId)

            // Act
            var okResponse = _controller.RemoverItem(testeId);

            // Assert
            Assert.Equal(2, _service.ListarTodos().Count());
        }
    }
}
