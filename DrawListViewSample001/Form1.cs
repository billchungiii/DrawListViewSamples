using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawListViewSample001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitialListView();
        }



        private void InitialListView()
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.LabelEdit = false;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("編號", 100);
            listView1.Columns.Add("測試文字", 100);
            for (int i = 0; i < 10; i++)
            {
                var item = new ListViewItem($"No.{i}");
                item.SubItems.Add($"文字{i}");
                listView1.Items.Add(item);
            }
            listView1.OwnerDraw = true;
            listView1.DrawSubItem += ListView1_DrawSubItem;
            listView1.DrawColumnHeader += ListView1_DrawColumnHeader;
        }

        private void ListView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ListView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                if (((ListView)sender).Focused)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.SkyBlue), e.Bounds);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
                }
                e.Graphics.DrawString(e.Item.Text, listView1.Font, new SolidBrush(Color.White), e.Bounds.Location);
            }
            else
            {
                e.DrawBackground();
                e.Graphics.DrawString(e.Item.Text, listView1.Font, new SolidBrush(Color.Black), e.Bounds.Location);
            }
        }
    }
}
