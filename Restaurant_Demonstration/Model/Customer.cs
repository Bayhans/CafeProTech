namespace Restaurant_Demonstration.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool Ordered { get; set; }
        public double ReservationDate { get; set; }
    }
}
