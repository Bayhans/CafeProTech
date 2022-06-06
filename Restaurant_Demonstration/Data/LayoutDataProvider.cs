using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_Demonstration.Model;

namespace Restaurant_Demonstration.Data
{
    public interface ILayoutDataProvider 
    {
        Task<IEnumerable<Layout>?> GetAllAsync();
       
        public class LayoutDataProvider : ILayoutDataProvider
        {
            public async Task<IEnumerable<Layout>?> GetAllAsync()
            {
                await Task.Delay(100); // Simulate a bit of server work

                return new List<Layout>
                {
                    new Layout{LayoutId=1,LayoutName = "First layout",Sections=2, Tables = 5, AvalibleTables = 4, Reservations = 1},
                    new Layout{LayoutId=2,LayoutName = "Second layout",Sections=3, Tables = 10, AvalibleTables = 4, Reservations = 6},
                    new Layout{LayoutId=3,LayoutName = "Third layout",Sections=2, Tables = 5, AvalibleTables = 2, Reservations = 3},
                };
            }
        }
    }
}