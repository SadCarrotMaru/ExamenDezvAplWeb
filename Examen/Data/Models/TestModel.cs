
using Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen.Data.Models
{
    [Table("TestModels")]
    public class TestModel: BaseEntity
    {
        public string Data { get; set; } = "";
        public int Price { get; set; } = 0;

        public int Nota { get; set; } = 5;
    }
}
