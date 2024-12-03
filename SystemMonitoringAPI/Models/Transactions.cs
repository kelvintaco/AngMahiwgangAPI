using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SystemMonitoringAPI.Models
{
    public class Transactions
    {
        [ForeignKey(nameof(Items))]
        public int ItemCode { get; set; }
        public string ItemName { get; set; }

        [ForeignKey(nameof(Borrowers))]
        public string BrwCode { get; set; }
        public string BrwName { get; set; }
        public string DprName { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TransID { get; set; }
        public DateOnly? BorrowDate { get; set; } = null;

        [JsonIgnore]
        [ValidateNever]
        public Items Items { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public Borrowers Borrowers { get; set; }
    }
}
