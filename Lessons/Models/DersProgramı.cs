namespace DersProgramiMvc.Models
{
    public class Ders
    {
        public int Id { get; set; }          // Primary key için Id ekledik
        public string DersAdi { get; set; }
        public string Saat { get; set; }
        public string Gun { get; set; }      // Enum yerine string kullanalım SQLite ile uyumlu olsun diye
    }
}