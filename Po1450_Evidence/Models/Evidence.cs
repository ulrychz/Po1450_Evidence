namespace Po1450_Evidence.Models
{
    public class Evidence
    {
        public List<Polozky> Polozky { get; set; } = new List<Polozky>();
        public Polozky Polozka { get; set; } = new Polozky();
    }
}
