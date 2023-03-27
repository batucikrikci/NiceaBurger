namespace NiceaBurger.Areas.Identity.Data
{
    public class Menu
    {
        public int Id { get; set; }
        public string ?MenuAdi { get; set; }
        public double Fiyat { get; set; }


        public List<SiparisUrun> SiparisUrunler { get; set; } =new List<SiparisUrun>();

    }
}
