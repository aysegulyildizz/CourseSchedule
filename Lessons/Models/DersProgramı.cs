namespace DersProgramiMvc.Models
{
    public class DersProgrami
    {
        public string DersAdi { get; set; }
        public string Saat { get; set; }
    }

    public enum Gun
    {
        Pazartesi,
        Sali,
        Carsamba,
        Persembe,
        Cuma
    }
}