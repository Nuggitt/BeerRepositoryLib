using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerRepositoryLib
{
    public class BeersRepository
    {
        private int _nextId = 7;

        private List<Beer> _beers = new List<Beer>()
        {
            new Beer() { Id = 1, Name = "Budweiser", Abv = 5.0 },
            new Beer() { Id = 2, Name = "Guinness", Abv = 4.2 },
            new Beer() { Id = 3, Name = "Tuborg Classic", Abv = 4.6 },
            new Beer() { Id = 4, Name = "Bud Light", Abv = 3.5 },
            new Beer() { Id = 5, Name = "Heineken", Abv = 5.0 },
            new Beer() { Id = 6, Name = "Corona", Abv = 4.5 }

        };


        public List<Beer> GetBeers()
        {
            List<Beer> copiedBeers = new List<Beer>();
            foreach (var beer in _beers)
            {
                copiedBeers.Add(new Beer(beer));
            }
            return new List<Beer>(copiedBeers);
        }

        public IEnumerable<Beer> Get(double? abv = null, string? nameIncludes = null, string? sortBy = null)
        {
            IEnumerable<Beer> result = new List<Beer>(_beers);

            if (abv != null)
            {
                result = result.Where(b => b.Abv == abv); //Filtering by ABV
            }
            if (nameIncludes != null)
            {
                result = result.Where(b => b.Name.Contains(nameIncludes)); //Filtering by name
            }

            if (sortBy != null)
            {
                sortBy = sortBy.ToLower();
                switch (sortBy)
                {
                    case "name":
                        result = result.OrderBy(b => b.Name); //Sorting by name
                        break;
                    case "name_desc":
                        result = result.OrderByDescending(b => b.Name); //Sorting by name descending
                        break;
                    case "abv":
                        result = result.OrderBy(b => b.Abv); //Sorting by ABV
                        break;
                    case "abv_desc":
                        result = result.OrderByDescending(b => b.Abv); //Sorting by ABV descending
                        break;
                    default:
                        break;

                }
            }
            return result.ToList();
        }

        public override string ToString()
        {
            return string.Join(",", _beers);
        }


        public Beer AddBeer(Beer beer)
        {
            beer.Validate();
            beer.Id = _nextId++;
            _beers.Add(beer);
            return beer;
        }

        public Beer? RemoveBeer(int id)
        {
            Beer? beer = _beers.FirstOrDefault(b => b.Id == id);
            if (beer == null)
            {
                return null;
            }
            _beers.Remove(beer);
            return beer;
        }

        public Beer? GetBeerById(int id)
        {
            return _beers.FirstOrDefault(b => b.Id == id);
        }

        public Beer? UpdateBeer(int id, Beer beer)
        {
            beer.Validate();
            Beer? beerToUpdate = GetBeerById(id);
            if (beerToUpdate == null)
            {
                return null;
            }
            beerToUpdate.Name = beer.Name;
            beerToUpdate.Abv = beer.Abv;
            return beerToUpdate;
        }
    }
}
