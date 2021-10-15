using AutoFixture;
using BiblioAventurier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using FluentAssertions;


namespace UnitTestAventurier
{
    [TestClass]
    public class UnitTestPlateau
    {
        private readonly Fixture _fixture = new Fixture();


        [TestInitialize]
        public async Task Initialize()
        {

        }

        [TestMethod]
        public void Should_ReturnTrue_When_ConsigneAskedWithGoodPositionAndGoodDirections()
        {
            //Arrange
            var plateau = _fixture.Create<Plateau>();

            //Act
            string directions = "SSSSEEEEEENN";
            var result = plateau.Consigne(3, 0, directions);

            //Assert
            result
                .Should().NotBe(false, "Echec : un problème a été rencontré, ce n'est pas le résultat attendu");

        }

        [TestMethod]
        public void Should_ReturnFalse_When_ConsigneAskedWithBadDirections()
        {
            //Arrange
            var plateau = _fixture.Create<Plateau>();

            //Act
            string directions = "OONOOOSSO";
            var result = plateau.Consigne(3, 0, directions);

            //Assert
            result
                .Should().NotBe(true, "Echec : un problème a été rencontré, ce n'est pas le résultat attendu");
        }

        [TestMethod]
        public void Should_ReturnFalse_When_ConsigneAskedWithBadPosition()
        {
            //Arrange
            var plateau = _fixture.Create<Plateau>();

            //Act
            string directions = "SSSSEEEEEENN";
            var result = plateau.Consigne(6, 9, directions);

            //Assert
            result
                .Should().NotBe(true, "Echec : un problème a été rencontré, ce n'est pas le résultat attendu");
        }


    }
}
