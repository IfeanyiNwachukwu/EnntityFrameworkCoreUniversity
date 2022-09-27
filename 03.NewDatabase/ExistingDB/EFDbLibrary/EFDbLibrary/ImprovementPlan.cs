using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDbLibrary
{
    public class ImprovementPlan
    {
        [Key]
        [ForeignKey("Employee")]
        public int BusinessEntityId { get; set; }
        public virtual Employee Employee { get; set; }
        [Required]
        public DateTime PlanStart { get; set; }
        public DateTime PlanComplete => PlanStart.AddDays(90);
    }
}
