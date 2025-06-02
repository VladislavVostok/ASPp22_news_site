using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blogp22AspNetCore.Models
{
    [Table("CNTR_EM133")]
    public class CntrEm133
    {
        [Key]
        public int Id { get; set; }
        public int IdEkg { get; set; }
        public int BrigadaId { get; set; }
        public long kWh_im { get; set; }
        public long kWh_ex { get; set; }
        public long kWArh_im { get; set; }
        public long TimestampOnServer { get; set; }
        public long TimestampFromEkg { get; set; }
    }
}
