namespace BeerRepositoryLib
{
    public class Beer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Abv { get; set; }

        public Beer(Beer other)
        {
            Id = other.Id;
            Name = other.Name;
            Abv = other.Abv;
        }

        public Beer()
        {
            
        }

        public void ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException("Name cannot be null or empty");
            }

            if (Name.Length < 3)
            {
                throw new ArgumentException("Name lenght cannot be on 2 characters or less");
            }
        }


        public void ValidateAbv()
        {
            if (Abv < 0)
            {
                throw new ArgumentOutOfRangeException("ABV cannot be negative");
            }

            if (Abv > 67)
            {
                throw new ArgumentException("ABV cannot be greater than 67");
            }
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, ABV: {Abv}";
        }

        public void Validate()
        {
            ValidateName();
            ValidateAbv();
        }

    }
}
