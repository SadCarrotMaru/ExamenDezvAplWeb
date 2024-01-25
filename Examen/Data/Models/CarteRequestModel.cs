namespace Examen.Data.Models
{
    public class CarteRequestModel
    {
        public string Nume { get; set; }
        public string Subiect { get; set; }
        public int Pret { get; set; }
        public List<Guid> Autori { get; set; }
    }
}
