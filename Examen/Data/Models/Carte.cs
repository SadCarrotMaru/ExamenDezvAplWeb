
using Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Examen.Data.Models
{
    [Table("Carti")]
    public class Carte : BaseEntity
    {
        public string Nume { get; set; } = "";
        public string Subiect { get; set; } = "";
        public int Pret { get; set; } = 0;
        public ICollection<ModelsRelation> ModelsRelations { get; set; }
    }
}
