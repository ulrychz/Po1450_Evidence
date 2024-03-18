using Microsoft.JSInterop;
using System.Globalization;

namespace Po1450_Evidence.Models
{
    public class Evidence
    {
        public Evidence(IJSRuntime jS) 
        { 
            JS = jS;
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("cs-CZ");
        }
        private IJSRuntime JS { get; set; }
        public List<Polozky> Polozky { get; set; } = new List<Polozky>();
        public Polozky Polozka { get; set; } = new Polozky();
        public string Vypis { get; set; } = "";
        public bool IsEditace { get; set; } = false;
        public void Pridat()
        {
            //Polozky.Add(Polozka);
            //Polozka = new Polozky();

            Polozky.Add(new Polozky(datum: Polozka.Datum,Polozka.Naklady, Polozka.Vynosy));
        }
        public void PocetZaznamu()
        {
            Vypis = $"Počet záznamů je {Polozky.Count}";
        }

        public void ZobrazZaznamy()
        {
            Vypis = $"Jednotlivé záznamy: <br> {string.Join("<br>",Polozky)}";
        }

        public void Statistiky()
        {
            Vypis = "";
            Vypis += $"Minimum: {Minimum()} <br>";
            Vypis += $"Maximum: {Maximum()} <br>";
            Vypis += $"Pruměr: {Prumer()}";

        }

        private double Minimum()
        {
            if (Polozky.Count == 0)
            {
                return double.NaN;
            }
            return Polozky.Min(x=>x.Zisk);
        }
        private double Maximum()
        {
            if (Polozky.Count == 0)
            {
                return double.NaN;
            }
            return Polozky.Max(x => x.Zisk);
        }

        private double Prumer()
        {
            if (Polozky.Count == 0)
            {
                return double.NaN;
            }
            return Polozky.Average(x => x.Zisk);
        }

        public async Task SmazatZaznam(Models.Polozky item)
        {
            var zprava = $"Chcete smazat {item.Datum} - Zisk: {item.Zisk} z vašeho seznamu?";
            //JS.InvokeVoidAsync("alert", zprava);
            if (await JS.InvokeAsync<bool>("confirm", zprava))
            {
                Polozky.Remove(item);
            }
        }

        public void Editace(Models.Polozky item)
        {
            Polozka = item;
            IsEditace = true;
        }
        public void UkoncitEditaci()
        {
            IsEditace = false;
            Polozka = new Polozky();
        }
    }
}
