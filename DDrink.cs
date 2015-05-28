using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkOrder
{
    public class DDrink
    {

        private int intID;

        public int id
        {
            get { return intID; }
            set { intID = value; }
        }
        private string strName;

        public string name

        {
            get { return strName; }
            set { strName = value; }
        }
        private string Price;

        public string price
        {
            get { return Price; }
            set { Price = value; }
        }
    }
}
