using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMachineDAL.Model
{
    public class OrderType
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Index(IsUnique=true)]
        [Required]
        public string Label { get; set; }

    }
}
