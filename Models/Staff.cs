namespace DeltaruneFrBackEnd.Models
{
    public class Staff
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string photo { get; set; }
        public string? description { get; set; }
        public string? card { get; set; }
        public string? lien { get; set; }
        public string? nomLien { get; set; }
        public int idChapitre { get; set; }

    }
}
