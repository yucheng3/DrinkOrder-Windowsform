using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrinkOrder
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            FrmOrderSystem f = new FrmOrderSystem();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Normal;
            f.Show();
            toolStripStatusLabel1.Text = "就緒";
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                (this.ActiveMdiChild as Interface1).export();
                toolStripStatusLabel1.Text = "匯出完成";
            }

        }

        private void 水平排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 垂直排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void 關閉目前視窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
        }

        private void 關閉所有視窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
        }

        private void 線上說明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace, HelpNavigator.Index);
        }

        private void 關於CRMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace, HelpNavigator.Index);
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace, HelpNavigator.Index);
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 離開ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "就緒";
            toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd"); 
        }

        private void 列表檢視ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOrderSystem f = new FrmOrderSystem();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Normal;
            f.Show();
            toolStripStatusLabel1.Text = "就緒";
        }
    }
}
