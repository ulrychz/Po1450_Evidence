namespace Po1450_Evidence.Models
{
    public class Polozky
    {
        public Polozky() 
        { 
            Datum = DateOnly.FromDateTime(DateTime.Now);
        }

        public Polozky(DateOnly datum, double naklady, double vynosy)
        {
            Datum = datum;
            Naklady = naklady;
            Vynosy = vynosy;
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

        public override string ToString()
        {
            return $"Datum: {Datum} - Náklady: {Naklady} - Výnosy: {Vynosy} - Zisk: {Zisk}";
        }
    }
}
