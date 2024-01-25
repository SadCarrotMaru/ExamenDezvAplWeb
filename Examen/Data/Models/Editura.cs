
using Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen.Data.Models
{
    [Table("Edituri")]
    public class Editura : BaseEntity
    {
        public string Nume { get; set; } = "";

        public int Vechime { get; set; } = 0;
        public ICollection<Autor>? Autori { get; set; }
    }
}
