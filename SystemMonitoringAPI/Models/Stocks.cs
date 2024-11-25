using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SystemMonitoringAPI.Models
{
    public class Stocks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey(nameof(Items))]
        public int ItemCode { get; set; }

        public int onBorrow { get; set; }
        public int isnotonBorrow { get; set; }
    }
}
