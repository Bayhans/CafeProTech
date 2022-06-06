using System.Collections.Generic;
using System.Windows.Documents;

namespace Restaurant_Demonstration.Model
{
    public class Layout
    {
        public int LayoutId { get; set; }
        public string? LayoutName { get; set; }
        public int Sections  { get; set; }
        public int Tables  { get; set; }
        public int AvalibleTables  { get; set; }
        public int Reservations { get; set; }
        public bool Avaliblity { get; set; }
    }

}
