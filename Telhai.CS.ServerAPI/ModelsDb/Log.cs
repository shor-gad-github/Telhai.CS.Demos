using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telhai.CS.ServerAPI.ModelsDb
{
    public class Log
    {
       
        public int Id { get; set; }
        public string  Msg { get; set; }
        public string Level { get; set; }

    }
}

// [Key]
// [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

