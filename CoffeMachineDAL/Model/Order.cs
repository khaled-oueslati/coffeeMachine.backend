using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMachineDAL.Model
{
    public class Order
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        public int UserId { get; set; }
        [Range(0,10)]
        [Required]
        public int SugarQuantity { get; set; }
        public bool SelfMug { get; set; }
        [Required]
        public int OrderTypeId { get; set; }

        [ForeignKey("OrderTypeId")]
        public virtual OrderType Type { get; set; }

        public bool ShouldSerializeUserId()
        {
            // don't serialize the UserId property if =0
            return UserId!=0;
        }

    }
}
