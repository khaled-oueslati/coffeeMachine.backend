using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.backend.Dto
{
    public class FailureDTO<T> : ResponseDTO<T>
    {
        public FailureDTO(T element) :base(element)
        {
            this.status = DTOStatus.FAILURE;
        }
    }
}
