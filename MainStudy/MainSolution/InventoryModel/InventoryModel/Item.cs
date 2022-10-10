using System.ComponentModel.DataAnnotations;

namespace InventoryModel
{
    public class Item : FullAuditModel
    {
       
        // REGULAR PROPERTIES
        [StringLength(InventoryModelsConstants.MAX_NAME_LENGTH)]
        [Required]
        public string Name { get; set; }
        [Range(InventoryModelsConstants.MINIMUM_QUANTITY,InventoryModelsConstants.MAXIMUM_QUANTITY)]
        public int Quantity { get; set; }
        [StringLength(InventoryModelsConstants.MAX_DESCRIPTION_LENGTH)]
        [Required]
        public string Description { get; set; }
        [StringLength(InventoryModelsConstants.MAX_NOTES_LENGTH, MinimumLength = 10)]
        public string Notes { get; set; }
        public bool IsOnSale { get; set; }
        public DateTime? PurchasedDate { get; set; }
        public DateTime? SoldDate { get; set; }
        [Range(InventoryModelsConstants.MINIMUM_PRICE, InventoryModelsConstants.MAXIMUM_PRICE)]
        public decimal? PurchasePrice { get; set; }
        [Range(InventoryModelsConstants.MINIMUM_PRICE, InventoryModelsConstants.MAXIMUM_PRICE)]
        public decimal? CurrentOrFinalPrice { get; set; }

        //RELATIONAL ENTITY
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        // Many to Many Relationship with Player table
        public virtual List<Player> Players { get; set; } = new List<Player>();
    }
}