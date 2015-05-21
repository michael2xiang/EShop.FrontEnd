using System;

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
