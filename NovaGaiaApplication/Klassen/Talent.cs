namespace NovaGaiaCharaktereditor.Klassen
{
    public class Talent
    {
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public int ChiKosten { get; set; }

        public override string ToString()
        {
            return $"{Name} ({ChiKosten} Chi)";
        }
    }

}
