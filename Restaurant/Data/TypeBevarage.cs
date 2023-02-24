namespace Restaurant.Data
{
    public class TypeBevarage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisterON { get; set; }
        public ICollection<Bevarage> Bevarages { get; set; }
    }
}
