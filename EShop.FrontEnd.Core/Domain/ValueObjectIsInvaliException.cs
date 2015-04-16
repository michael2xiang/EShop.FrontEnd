using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Core.Domain
{
     public class ValueObjectIsInvaliException:Exception
    {
         public ValueObjectIsInvaliException(string msg)
             : base(msg)
         { 
         }
    }
}
