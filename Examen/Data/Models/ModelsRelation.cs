namespace Examen.Data.Models
{
    public class ModelsRelation
    {
        public Guid AutorId { get; set; }
        public Autor Autor { get; set; }

        public Guid CarteId { get; set; }
        public Carte Carte { get; set; }
    }
}
