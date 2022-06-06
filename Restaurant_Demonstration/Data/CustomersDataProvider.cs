using Restaurant_Demonstration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant_Demonstration.Data
{
    public interface ICustomersDataProvider
    {
        Task<IEnumerable<Customer>?> GetAllAsync();
    }

    public class CustomersDataProvider : ICustomersDataProvider
    {
        public async Task<IEnumerable<Customer>?> GetAllAsync()
        {
            await Task.Delay(100); // Simulate a bit of server work, it needs the DB Info

            return new List<Customer>
          {
            new Customer{Id=1,FirstName="Julia",LastName="Developer",ReservationDate = 01.20, Ordered=true},
            new Customer{Id=2,FirstName="Alex",LastName="Rider"},
            new Customer{Id=3, FirstName="Thomas",LastName="Huber",ReservationDate = 03.30,Ordered=true},
            new Customer{Id=4,FirstName="Anna",LastName="Rockstar"},
            new Customer{Id=5,FirstName="Sara",LastName="Metroid"},
            new Customer{Id=6,FirstName="Ben",LastName="Ronaldo"}
          };
        }
    }
}
