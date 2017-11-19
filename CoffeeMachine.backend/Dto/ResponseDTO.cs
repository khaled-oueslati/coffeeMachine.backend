using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.backend.Dto
{
    public class ResponseDTO <T>
    {
        public ResponseDTO(T element)
        {
            this.Response = element;
        }
        public int status { get; set; }
        public T Response { get; set; }
    }
}
