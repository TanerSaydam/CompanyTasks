namespace RehberWebApi.Models.Entities
{
    public class Rehber
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
        public ICollection<IletisimBilgileri> IletisimBilgileri { get;}
    }
}
