using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace SystemMonitoringAPI.Models
{
    public class Borrowers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string BrwCode { get; set; }
        public string BrwName { get; set; }
        public int DprCode { get; set; }
        public string DprName { get; set; }

        public Transactions Transactions { get; set; }

    }
}
