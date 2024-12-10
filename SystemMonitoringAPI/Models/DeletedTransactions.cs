using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SystemMonitoringAPI.Models
{
    public class DeletedTransactions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DelTransID { get; set; }
        public DateOnly? DateDeleted { get; set; } = null;
        public DateOnly? BorrowDate { get; set; } = null;
        [ForeignKey(nameof(Borrowers))]
        public string BrwCode { get; set; }
        public string BrwName { get; set; }
        public string DprName { get; set; }
        [ForeignKey(nameof(Items))]
        public int ItemCode { get; set; }
        public string ItemName { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public Transactions Transactions { get; set; }
    }
}
