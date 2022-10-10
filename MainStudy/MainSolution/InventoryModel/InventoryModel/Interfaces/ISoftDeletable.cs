using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryModel.Interfaces
{
    public interface ISoftDeletable
    {
       
        bool IsDeleted { get; set; }
    }
}
