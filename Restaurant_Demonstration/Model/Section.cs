namespace Restaurant_Demonstration.Model
{
    public class Section
    {
        public int SectionId { get; set; }
        public string? SectionName { get; set; }
        public int SectionTables  { get; set; }
        public int SectionAvalibleTables  { get; set; }
        public int SectionReservations { get; set; }




        public bool Avaliblity { get; set; }
        public int Sections { get; set; }

    }

}
