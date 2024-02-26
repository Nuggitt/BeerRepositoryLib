using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerRepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerRepositoryLib.Tests
{
    [TestClass()]
    public class BeersRepositoryTests
    {

        private BeersRepository _beersRepository = new BeersRepository();


        [TestMethod()]
        public void GetBeersTest()
        {
            List<Beer> beers = _beersRepository.GetBeers();
            Assert.AreEqual(6, beers.Count);
        }

        [TestMethod()]
        public void GetTest()
        {
            IEnumerable<Beer> beers = _beersRepository.Get(sortBy: "name"); //Sorting by name
            Assert.AreEqual("Bud Light", beers.First().Name);

            var beersNamedBud = _beersRepository.Get(nameIncludes: "Bud"); //Filtering by name
            Assert.AreEqual(2, beersNamedBud.Count());

            var beersWithAbv5 = _beersRepository.Get(abv: 5.0); //Filtering by ABV
            Assert.AreEqual(2, beersWithAbv5.Count());

            var beersSortedByNameDesc = _beersRepository.Get(sortBy: "name_desc"); //Sorting by name descending
            Assert.AreEqual("Tuborg Classic", beersSortedByNameDesc.First().Name);

            var beersSortedByAbv = _beersRepository.Get(sortBy: "abv"); //Sorting by ABV ascending budlight 3.5
            Assert.AreEqual("Bud Light", beersSortedByAbv.First().Name);

            var beersSortedByAbvDesc = _beersRepository.Get(sortBy: "abv_desc"); //Sorting by ABV descending budweiser 5.0
            Assert.AreEqual("Budweiser", beersSortedByAbvDesc.First().Name);

        }

        [TestMethod()]
        public void ToStringTest()
        {
            string str = _beersRepository.ToString();
            Assert.IsTrue(str.Contains("Budweiser"));
        }

        [TestMethod()]
        public void AddBeerTest()
        {
            _beersRepository.AddBeer(new Beer() { Id = 7, Name = "Becks", Abv = 4.8 });
            List<Beer> beers = _beersRepository.GetBeers();
            Assert.AreEqual(7, beers.Count);
        }

        [TestMethod()]
        public void RemoveBeerTest()
        {
            _beersRepository.RemoveBeer(6); //Removing beer
            List<Beer> beers = _beersRepository.GetBeers();
            Assert.AreEqual(5, beers.Count);
            
            _beersRepository.RemoveBeer(6); //Removing non existing beer
            Assert.IsNull(_beersRepository.GetBeerById(6));
        }

        [TestMethod()]
        public void GetBeerByIdTest()
        {
            Beer? beer = _beersRepository.GetBeerById(1); //Getting beer by id
            Assert.IsNotNull(beer); 
            Assert.AreEqual("Budweiser", beer.Name); //Checking if the name is correct
        }

        [TestMethod()]
        public void UpdateBeerTest()
        {
            _beersRepository.UpdateBeer(1, new Beer() { Id = 1, Name = "Budweiser", Abv = 5.5 }); //Updating beer abv from 5.0 to 5.5
            Beer? beer = _beersRepository.GetBeerById(1); //Getting beer by id
            Assert.IsNotNull(beer); //Checking if the beer exists
            Assert.AreEqual(5.5, beer.Abv); //Checking if the abv is correct

            _beersRepository.UpdateBeer(7, beer); //Updating non existing beer
            Assert.IsNull(_beersRepository.GetBeerById(7)); //Checking if the beer exists
        }
    }
}