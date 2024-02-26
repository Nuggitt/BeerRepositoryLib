using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeerRepositoryLib.Tests
{
    [TestClass()]
    public class BeerTests
    {
        //Arranging objects
        Beer beer = new Beer() { Id = 1, Name = "Budweiser", Abv = 5.0 };
        Beer beer2 = new Beer() { Id = 2, Name = null, Abv = 5.0 };
        Beer beer3 = new Beer() { Id = 3, Name = "", Abv = 4.6 };
        Beer beer4 = new Beer() { Id = 4, Name = "Guinness", Abv = 68 };
        Beer beer5 = new Beer() { Id = 5, Name = "Tuborg Classic", Abv = 4.6 };
        Beer beer6 = new Beer() { Id = 6, Name = "Bud Light", Abv = -3 };
        Beer beer7 = new Beer() { Id = 7, Name = "Be", Abv = 4.6 };


        [TestMethod()]
        public void ValidateNameTest()
        {
            beer.ValidateName();
            Assert.ThrowsException<ArgumentException>(() => beer2.ValidateName()); //null
            Assert.ThrowsException<ArgumentException>(() => beer3.ValidateName()); //empty
            Assert.ThrowsException<ArgumentException>(() => beer7.ValidateName()); //less than 3 characters

        }

        [TestMethod()]
        public void ValidateAbvTest()
        {
            beer.ValidateAbv();
            Assert.ThrowsException<ArgumentException>(() => beer4.ValidateAbv()); //greater than 67
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => beer6.ValidateAbv()); //negative


        }

        [TestMethod()]
        public void ToStringTest()
        {
            string str = beer.ToString();
            Assert.AreEqual("Id: 1, Name: Budweiser, ABV: 5", str); //expected

        }

        [TestMethod()]
        public void ValidateTest()
        {
            beer.Validate();
            Assert.ThrowsException<ArgumentException>(() => beer2.Validate()); //null
            Assert.ThrowsException<ArgumentException>(() => beer3.Validate()); //empty
            Assert.ThrowsException<ArgumentException>(() => beer7.Validate()); //less than 3 characters
            Assert.ThrowsException<ArgumentException>(() => beer4.Validate()); //greater than 67
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => beer6.Validate()); //negative
        }
    }
}