using MinimalAPI.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public sealed class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        // Arrange
        var veiculo = new Veiculo();

        // Act
        veiculo.Id = 1;
        veiculo.Nome = "teste";
        veiculo.Marca = "teste";
        veiculo.Ano = 1;

        // Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("teste", veiculo.Nome);
        Assert.AreEqual("teste", veiculo.Marca);
        Assert.AreEqual(1, veiculo.Ano);
    }
}