using System.ComponentModel.DataAnnotations;

namespace InventoryModel
{
    public class Genre : FullAuditModel
    {
        [Required]
        [StringLength(InventoryModelsConstants.MAX_NAME_LENGTH)]
        public string Name { get; set; }

        public virtual List<ItemGenre> GenreItems { get; set; } = new List<ItemGenre>();
    }
}
