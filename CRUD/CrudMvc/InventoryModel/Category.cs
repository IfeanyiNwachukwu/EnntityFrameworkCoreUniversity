using System.ComponentModel.DataAnnotations;

namespace InventoryModel
{
    public class Category : FullAuditModel
    {
        public Category()
        {
            // To avoid null reference exceptions in the cases where the related items are not loaded into the scope.
            Items = new List<Item>();
        }
        [StringLength(InventoryModelsConstants.MAX_NAME_LENGTH)]
        public string Name { get; set; }

        public virtual List<Item> Items { get; set; } 

        public virtual CategoryDetail CategoryDetail { get; set; }
    }
}
