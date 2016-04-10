﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetHub.Models
{
    public partial class Loan
    {
        [Column("LoanId")]
        public int Id { get; set; }

        [Column("LoanTimeFrom")]
        public DateTime TimeFrom { get; set; }

        [Column("LoanTimeTo")]
        public DateTime TimeTo { get; set; }

        [Column("LoanAssetId")]
        public int AssetId { get; set; }

        [Column("LoanUserId")]
        public string UserId { get; set; }

        [Column("LoanAssetLocationId")]
        public int AssetLocationId { get; set; }

        public virtual Asset Asset { get; set; }

        public virtual User User { get; set; }

        public virtual AssetLocation AssetLocation { get; set; }
    }
}