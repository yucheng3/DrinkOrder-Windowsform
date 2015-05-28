using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrinkOrder
{
    public partial class FrmOrderSystem : Form,Interface1
    {
        public FrmOrderSystem()
        {
            InitializeComponent();
        }


        Button btn;
        int Total;
        string getclickprice;
        string number = "";
        string sel_Sugar = "";
        string sel_Ice = "";
        string sel_size = "";
        Boolean click = false;
        public string product = ""; string showmessage;
        protected OrderDetailFactory od = new OrderDetailFactory();
        DDrinkFactory factory = new DDrinkFactory();



        private void FrmOrderSystem_Load(object sender, EventArgs e)
        {


            Loaddrink(); //動態生成飲料button.
            setgridview();
        }

        private void setgridview()
        {
            dataGridView1.Columns[0].Width = 90;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].Width = 50;
            dataGridView1.Columns[7].Width = 50;

            bool blnColorCahnge = false;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                blnColorCahnge = !blnColorCahnge;
                if (blnColorCahnge)
                    r.DefaultCellStyle.BackColor = Color.LightBlue;
                else
                    r.DefaultCellStyle.BackColor = Color.White;
            }

        }


        private void clickMe(object sender, EventArgs e) //飲料按鈕事件
        {
            click = false;
            number = "";
            Total = 0;
            Button btn = (Button)sender;
            DDrink customer = factory.getname(btn.Text);
            getclickprice = customer.price.ToString();
            lblMessage.Text = customer.name.ToString() + " 單價 " + getclickprice + "$";
            product = customer.name.ToString();

        }
        private void calculateSubTotal() //r計算總金額
        {
            Total += Convert.ToInt32(getclickprice) * Convert.ToInt32(number);
        }

        private void button1_Click(object sender, EventArgs e) //送出訂單
        {
            if (product == "")
            {
                MessageBox.Show("請選擇您要的飲料。");
                return;
            }
            else if

               (sel_Ice == "" || sel_size == "" || sel_Sugar == "")
            {
                MessageBox.Show("請選擇甜度、冰塊、大小。");
                return;
            }
            else if (number == "")
            {
                MessageBox.Show("請選擇數量。");
                return;
            }

            calculateSubTotal();
            DataGridViewRowCollection rows = dataGridView1.Rows;
            rows.Add(new Object[] { product, sel_Sugar, sel_Ice, sel_size, getclickprice, number, Total, DateTime.Now.ToString("yyyy/MM/dd") });
            reSet();

        }
        private void numberclick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (click)
            {
                textBox1.Text += btn.Text;
            }
            else
            {
                
                number += btn.Text;
                showmessage = product + " 單價 " + getclickprice + "$" + "     " + number.ToString() + "杯";
                lblMessage.Text = showmessage;
            }
        }

        private void Loaddrink()
        {

            DDrink[] customers = factory.getAll();
            Dictionary<string, TreeNode> table = getdrink(customers);

        }


        private Dictionary<string, TreeNode> getdrink(DDrink[] customers)
        {
            Dictionary<string, TreeNode> table = new Dictionary<string, TreeNode>();
            int topa = 30;
            int b = 40;
            int count = 0;
            foreach (DDrink c in customers)
            {

                btn = new Button();
                btn.Click += clickMe;
                //btn.Font = new Font("微軟正黑體", 9);
                btn.BackColor = Color.SkyBlue;
                btn.Text = c.name;
                btn.Height = 38;
                btn.Width = 82;
                btn.Left = b;
                btn.Top = topa;
                b += 90;
                this.Controls.Add(btn);
                count++;
                if (count % 3 == 0)
                {
                    int i = 1;
                    topa = topa + 60;
                    b = 40;
                    i += 1;
                }



            }
            return table;
        }

        private void button13_Click(object sender, EventArgs e) //結帳按鈕
        {
            




            int cup = 0;
            double total = 0.0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                if (row.Cells[0].Value != null)
                {
                    cup += Convert.ToInt32(row.Cells[5].Value);
                    total += Convert.ToInt32(row.Cells[6].Value);
                    Array.Resize(ref od.orderd, od.orderd.Length + 1);
                    od.orderd[od.orderd.Length - 1] = new OrderDetail()
                    {
                        Product = row.Cells[0].Value.ToString(),
                        Sel_Sugar = row.Cells[1].Value.ToString(),
                        Sel_Ice = row.Cells[2].Value.ToString(),
                        Sel_size = row.Cells[3].Value.ToString(),
                        Getclickprice = row.Cells[4].Value.ToString(),
                        Number = row.Cells[5].Value.ToString(),
                        Total1 = row.Cells[6].Value.ToString()
                    };
                }
            }
            textBoxCup.Text = cup.ToString();
            textBoxTotal.Text = total.ToString();
            txtTotal.Text = total.ToString();
            textBox1.ReadOnly = false;
        }

        private void listBoxsugar_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (product != "")
                sel_Sugar = listBoxsugar.SelectedItem.ToString();
        }

        private void listBox2ice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (product != "")
                sel_Ice = listBox2ice.SelectedItem.ToString();
        }

        private void listBox3size_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (product != "")
                sel_size = listBox3size.SelectedItem.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            reSet2();
        }

        private void reSet()
        {
            product = "";
            lblMessage.Text = "";
            number = "";
            listBox2ice.ClearSelected();
            listBox3size.ClearSelected();
            listBoxsugar.ClearSelected();
            sel_Sugar = "";
            sel_size = "";
            sel_Ice = "";
            Total = 0;
            textBoxCup.Text = "";
            textBoxTotal.Text = "";
            txtTotal.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void reSet2()
        {
            reSet();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }
        private void button13_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                int a = Convert.ToInt32(textBox1.Text);
                int b = Convert.ToInt32(textBoxTotal.Text);
                int res = a - b;
                if (res>0)
                     textBox2.Text = res.ToString();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;



            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            click = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            

        }

        public void export()
        {
            StreamWriter writer = new StreamWriter(@"C:\Users\iii\Desktop\1.txt", false, Encoding.Default);



            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    writer.Write("" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "" + "|");
                }
                writer.WriteLine("");
                writer.WriteLine("____________________________________________________________________");

            }

            writer.Close();
        }

    }
}
