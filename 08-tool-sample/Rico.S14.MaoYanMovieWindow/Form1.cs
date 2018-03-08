using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rico.S14.MaoYanMovieWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ColumnHeader ch = new ColumnHeader();

            ch.Text = "列标题1";   //设置列标题

            ch.Width = 120;    //设置列宽度

            ch.TextAlign = HorizontalAlignment.Left;   //设置列的对齐方式

            this.lvMovies.Columns.Add(ch);    //将列头添加到ListView控件。

            //this.lvMovies.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度  

            //for (int i = 0; i < 10; i++)   //添加10行数据  
            //{
            //    ListViewItem lvi = new ListViewItem();
                
            //    lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标  

            //    lvi.Text = "subitem" + i;

            //    lvi.SubItems.Add("第2列,第" + i + "行");

            //    lvi.SubItems.Add("第3列,第" + i + "行");

            //    this.lvMovies.Items.Add(lvi);
            //}

            //this.lvMovies.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        }
    }
}
