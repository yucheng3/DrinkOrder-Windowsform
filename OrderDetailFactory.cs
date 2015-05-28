using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkOrder
{

    public class OrderDetailFactory
    {

       
        public OrderDetail[] orderd = new OrderDetail[0];

        public OrderDetailFactory()
        {

        }



        public OrderDetail[] getAll()
        {
            return orderd;
        }






    }

}
