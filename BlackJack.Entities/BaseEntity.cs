using System.ComponentModel.DataAnnotations;

namespace BlackJack.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
