namespace NiceaBurger.Areas.Identity.Data
{
    public class EkstraMalzeme
    {
        public int Id { get; set; }
        public string ?Ad { get; set; }
        public double Fiyat { get; set; }

        public List<SiparisUrun> SiparisUrunler { get; set; } = new List<SiparisUrun>();

    }
}
