using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemMonitoringAPI.Models
{
    public class Items
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public int onBorrow { get; set; }
        public int isnotonBorrow { get; set; }
    }
}
