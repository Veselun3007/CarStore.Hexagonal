using CarStore.Hexagonal.Domain.Base;
using CarStore.Hexagonal.Domain.ValueObjects;

namespace CarStore.Hexagonal.Domain.Entities
{
    public class Car : Entity<string>
    {
        public string Make { get; private set; }
        public string Model { get; private set; }
        public VinCode Vin { get; private set; }
        public Money Price { get; private set; }

        public Car(string make, string model, VinCode vin, Money price) 
        {
            if(string.IsNullOrWhiteSpace(make))
            {
                throw new ArgumentException("Make cannot be empty.");
            }

            if(string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("Model cannot be empty.");
            }
            Id = Guid.NewGuid().ToString();
            Make = make;
            Model = model;
            Vin = vin;
            Price = price;
        } 

        public Car(string id, string make, string model, VinCode vin, Money price)
        {           
            Id = id;
            Make = make;
            Model = model;
            Vin = vin;
            Price = price;
        }
    }
}
