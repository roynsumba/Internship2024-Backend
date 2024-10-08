﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AppraisalTracker.Modules.Configurables.Models
{
    public class ConfigMenuItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ItemId { get; set; }

        public string FieldName { get; set; } = string.Empty;

        public string FieldDescription { get; set; } = string.Empty;

        // Foreign key for User
        [ForeignKey("User")]
        public required Guid UserId { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
