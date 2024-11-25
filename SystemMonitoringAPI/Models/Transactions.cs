using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SystemMonitoringAPI.Models
{
    public class Transactions
    {
        [ForeignKey(nameof(Items))]
        public int ItemCode { get; set; }
        [ForeignKey(nameof(Borrowers))]
        public string BrwCode { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateOnly BorrowDate { get; set; }

        public IEnumerable<Items> Items { get; set; }
        public IEnumerable<Borrowers> Borrowers { get; set; }
    }
}
