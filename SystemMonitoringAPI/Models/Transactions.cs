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
        public string TransID { get; set; }
        public DateOnly BorrowDate { get; set; }

        public Items Items { get; set; }
        public Borrowers Borrowers { get; set; }  
    }
}
