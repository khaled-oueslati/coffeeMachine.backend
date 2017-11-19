using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.backend.Dto
{
    public class SuccessDTO<T> : ResponseDTO <T>
    {
        public SuccessDTO(T element): base(element)
        {
            this.status = DTOStatus.SUCCESS;
        }
    }
}
