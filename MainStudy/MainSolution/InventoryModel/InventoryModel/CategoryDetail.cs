using InventoryModel.Iterfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryModel
{
    public class CategoryDetail : IIdentityModel
    {
        // One to One Relatioship with the Category table
        [Key, ForeignKey("Category")]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(InventoryModelsConstants.MAX_COLORVALUE_LENGTH)]
        public string ColorValue { get; set; }

        public virtual Category Category { get; set; }
    }
}
