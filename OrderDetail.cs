using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkOrder
{
    public class OrderDetail
    {

        //public OrderDetail(string product, string sel_sugar, string sel_Ice, string sel_size, string price, string quan, string total)
        //{
        //    this.Product = product;
        //    this.Sel_Sugar = sel_sugar;
        //    this.Sel_size = sel_size;
        //    this.getclickprice = price;
        //    this.number = quan;
        //    this.Total1 = total;
        //}

        public OrderDetail()
        {
            // TODO: Complete member initialization
        }


        private string product;

        public string Product
        {
            get { return product; }
            set { product = value; }
        }
        private string sel_Sugar;

        public string Sel_Sugar
        {
            get { return sel_Sugar; }
            set { sel_Sugar = value; }
        }
        private string sel_Ice;

        public string Sel_Ice
        {
            get { return sel_Ice; }
            set { sel_Ice = value; }
        }
        private string sel_size;

        public string Sel_size
        {
            get { return sel_size; }
            set { sel_size = value; }
        }
        private string getclickprice;

        public string Getclickprice
        {
            get { return getclickprice; }
            set { getclickprice = value; }
        }
        private string number;

        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        private string Total;

        public string Total1
        {
            get { return Total; }
            set { Total = value; }
        }
    }
}
