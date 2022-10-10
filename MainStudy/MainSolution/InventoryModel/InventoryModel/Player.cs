using System.ComponentModel.DataAnnotations;

namespace InventoryModel
{
    public class Player : FullAuditModel
    {
       
        [Required]
        [StringLength(InventoryModelsConstants.MAX_PLAYERNAME_LENGTH)]
        public string Name { get; set; }
        [StringLength(InventoryModelsConstants.MAX_PLAYERDESCRIPTION_LENGTH)]
        public string Description { get; set; }

        // Many to Many Relationship with Items table
        public virtual List<Item> Items { get; set; } = new List<Item>();
    }
}
