
using Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen.Data.Models
{
    [Table("Autori")]
    public class Autor : BaseEntity
    {
        public string Nume { get; set; } = "";
        public int Varsta { get; set; } = 0;
        public string LocNastere { get; set; } = "";
        public Guid IdEditura { get; set; }
        public Editura EdituraCarte { get; set; }
        public ICollection<ModelsRelation> ModelsRelations { get; set; }
    }
}
    