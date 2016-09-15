using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace equipment_search
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = ofd.FileName.ToString();
            }
        }

        private void test_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“testDataSet1.major”中。您可以根据需要移动或删除它。
            this.majorTableAdapter.Fill(this.testDataSet1.major);
            // TODO: 这行代码将数据加载到表“testDataSet1.equipment”中。您可以根据需要移动或删除它。
            this.equipmentTableAdapter.Fill(this.testDataSet1.equipment);

        }
    }
}
