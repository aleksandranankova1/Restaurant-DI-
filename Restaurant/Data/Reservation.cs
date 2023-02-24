namespace Restaurant.Data
{
    public class Reservation
    {
        public int Id { get; set; }
        public int NumberOfPeople { get; set; }
   
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public DateTime RegisterON { get; set; }
        public int TableId { get; set; }
        public Table Tables { get; set; }
        public string ClientId { get; set; }
        public Client Clients { get; set; }
    }
}
