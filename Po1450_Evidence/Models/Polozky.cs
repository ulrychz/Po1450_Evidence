namespace Po1450_Evidence.Models
{
    public class Polozky
    {
        public Polozky() 
        { 
            Datum = DateOnly.FromDateTime(DateTime.Now);
        }
        public DateOnly Datum { get; set; }// = DateOnly.FromDateTime(DateTime.Now);
        public double Naklady
        {
            get => naklady; set
            {
                if (naklady != value)
                {
                    if (value >= 0)
                        naklady = value;
                }
            }
        }
        private double vynosy;
        private double naklady;

        public double Vynosy
        {
            get { return vynosy; }
            set 
            {
                if (vynosy != value)
                {
                    vynosy = Math.Abs(value);

                }
            }
        }

        public double Zisk => Vynosy - Naklady;
    }
}
