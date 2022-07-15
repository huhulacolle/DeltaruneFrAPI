namespace DeltaruneFrBackEnd.Models
{
    public class Progression
    {
        public int id { get; set; }
        public int chapitre { get; set; }
        public int textures { get; set; }
        public int modif_code { get; set; }
        public int traduction { get; set; }
        public int beta { get; set; }
        public Boolean fini { get; set; }
    }
}
