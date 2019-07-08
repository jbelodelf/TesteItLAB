using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.ItLAB.Bussines.Interface;
using Teste.ItLAB.Bussines.Repositories;
using Teste.ItLAB.Data;
using Teste.ItLAB.Data.Repositories;
using Teste.ItLAB.Model.Dtos;
using Teste.ItLAB.Model.Interfaces;
using Teste.ItLAB.WebAplication.Controllers;
using Xunit;

namespace Teste.ItLAB.TDD
{
    public class ProdutoTest
    {
        private readonly DbContextOptionsBuilder<ContextAplication> _OptionsBuider;
        private readonly ContextAplication _context;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoBussines _produtoBussines;
        private readonly ProdutoController _controller;

        public ProdutoTest()
        {
            _OptionsBuider = new DbContextOptionsBuilder<ContextAplication>();
            _context = new ContextAplication(_OptionsBuider.Options);
            _produtoRepository = new ProdutoRepository(_context);
            _produtoBussines = new ProdutoBussinesRepository(_produtoRepository);
            //_controller = new ProdutoController();
        }

        [Fact]
        public void Test1()
        {

        }

        //[Fact]
        //public async void Task_AddProduto_Valido_Retorn_OkResult()
        //{
        //    //var produtoMock = new Mock<IProdutoBussines>();
        //    //Arrange
        //    ProdutoDTO produto = new ProdutoDTO()
        //    {
        //        ID = 0,
        //        NOME = "Produto 1",
        //        IDTIPO = 1,
        //        DTFABRICACAO = Convert.ToDateTime("2019-07-06"),
        //        VALOR = 1600,
        //        DATACADASTRO = DateTime.Now
        //    };

        //    // Act
        //    var data = _produtoBussines.AddProduto(produto);

        //    //Assert
        //    Assert.True(data);
        //}

        //[Fact]
        //public async void Task_PostProuto_Invalido_Retorn_BadRequest()
        //{
        //    //Arrange
        //    ProdutoDTO produto = new ProdutoDTO()
        //    {
        //        ID = 0,
        //        NOME = "",
        //        IDTIPO = 0,
        //        DTFABRICACAO = Convert.ToDateTime("2019-07-06"),
        //        VALOR = 100,
        //        DATACADASTRO = DateTime.Now
        //    };

        //    // Act
        //    var data = await _controller.Post(ProdutoDTO);

        //    //Assert
        //    Assert.IsType<BadRequestResult>(data);
        //}

        //[Fact]
        //public async void Task_PutProuto_Valido_Retorna_OkResult()
        //{
        //    //Arrange
        //    var IdProduto = 1;
        //    ProdutoDTO produto = new ProdutoDTO()
        //    {
        //        ID = 0,
        //        NOME = "",
        //        IDTIPO = null,
        //        DTFABRICACAO = Convert.ToDateTime("2019-07-06"),
        //        VALOR = 100,
        //        DATACADASTRO = DateTime.Now
        //    };

        //    // Act
        //    var produto = await _controller.Get(IdProduto);
        //    var okResult = produto.Should().BeOfType<OkObjectResult>().Subject;
        //    var result = okResult.Value.Should().BeAssignableTo<ProdutoDTO>().Subject;

        //    produto.Nome = "";
        //    produto.VALOR = 150;

        //    var updatedData = await _controller.Put(produto);

        //    //Assert
        //    Assert.IsType<BadRequestResult>(updatedProduto);
        //}

        //[Fact]
        //public async void Task_PutProuto_Invalido_Retorna_BadRequest()
        //{
        //    //Arrange

        //    // Act

        //    //Assert
        //}

        //[Fact]
        //public async void Task_GetProutoById_Retorna_OkResult()
        //{
        //    // Act

        //    //Assert
        //}

        //[Fact]
        //public async void Task_GetAllProutos_Retorna_BadRequest()
        //{
        //    // Act

        //    //Assert
        //}

        //[Fact]
        //public async void Task_DeleteProuto_Retorna_OkResult()
        //{
        //    // Act

        //    //Assert
        //}

        //[Fact]
        //public async void Task_DeleteProuto_Retorna_BadRequest()
        //{
        //    // Act

        //    //Assert
        //}
    }
}
