namespace Po1450_Evidence.Models
{
    public class Polozky
    {
        public DateOnly Datum { get; set; }
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
                    if(value >= 0)
                        vynosy = value;
                }
            }
        }

        public double Zisk => Vynosy - Naklady;
    }
}
