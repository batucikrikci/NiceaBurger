namespace NiceaBurger.Areas.Identity.Data
{
    public class SiparisUrun
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        public int EkstraMalzemeId { get; set; }
        public EkstraMalzeme ekstraMalzeme { get; set; }

        public string KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }



    }
}
