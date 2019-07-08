using NSubstitute;
using Teste.ItLAB.Bussines.Interface;
using Xunit;

namespace Teste.ItLAB.TDD
{
    public class ProdutoTest
    {
        private readonly IProdutoBussines _mock;

        public ProdutoTest()
        {
            _mock = Substitute.For<IProdutoBussines>();
        }

        //[Fact]
        //public void AddProduto_Valido_Retorn_OkResult()
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
        //    var data = _mock.AddProduto(produto);

        //    //Assert
        //    Assert.True(data);
        //}

        //[Fact]
        //public void PostProuto_Invalido_Retorn_BadRequest()
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
        //    var data = _mock.Post(ProdutoDTO);

        //    //Assert
        //    Assert.True(data);
        //}

        //[Fact]
        //public async void PutProuto_Valido_Retorna_OkResult()
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
        //    var produto = _mock.Get(IdProduto);
        //    var okResult = produto.Should().BeOfType<OkObjectResult>().Subject;
        //    var result = okResult.Value.Should().BeAssignableTo<ProdutoDTO>().Subject;

        //    produto.Nome = "";
        //    produto.VALOR = 150;

        //    var updatedData = _mock.Put(produto);

        //    //Assert
        //    Assert.True(data);
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
