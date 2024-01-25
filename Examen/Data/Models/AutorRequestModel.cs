namespace Examen.Data.Models
{
    public class AutorRequestModel
    {
        public string Nume { get; set; }
        public string LocNastere { get; set; }
        public int Varsta { get; set; }
        
        public Guid IdEditura { get; set; }
        public List<Guid> Carti { get; set; }
    }
}
