﻿using InventoryModel.Interfaces;
using InventoryModel.Iterfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryModel
{
    public class FullAuditModel : IIdentityModel, IAuditedModel,IActivatableModel,ISoftDeletable
    
    {
        [Key]
        public int Id { get; set; }
        [StringLength(InventoryModelsConstants.MAX_USERID_LENGTH)]
        public string CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(InventoryModelsConstants.MAX_USERID_LENGTH)]
        public string LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
