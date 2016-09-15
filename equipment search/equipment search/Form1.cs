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
    public partial class Form1 : Form
    {
        string combobox1_selectedvalue;
        string combobox2_selectedvalue;
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = db.Camcon();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Scrollable = true;
            listView1.MultiSelect = false;
            listView1.HeaderStyle = ColumnHeaderStyle.Clickable;                                 //加载listview的表头
            listView1.Columns.Add("项目", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("参数", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("厂家", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("单价", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("总价", 50, HorizontalAlignment.Left);
            try                                                                                 //连接数据库
            {
                conn.Open();
                string sql = @"SELECT majorID,majorName FROM test.dbo.major";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //创建数据适配器和数据集
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "test.major");
                comboBox1.DataSource = ds.Tables["test.major"];
                comboBox1.DisplayMember = "majorName";
                comboBox1.ValueMember = "majorID";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("发生如下错误：" + ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }                                                                                //连接数据库完成
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Clear(); 
            SqlConnection conn = db.Camcon();
            conn.Open();
            string button1value = comboBox1.SelectedValue.ToString();
            string button2value = comboBox2.SelectedValue.ToString();
            string sUserId = comboBox1.SelectedValue.ToString();
            string sql = string.Format("SELECT equipmentID,equipmentName FROM test.dbo.equipment WHERE equipmentID='" + combobox2_selectedvalue + "'");
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();                                                         //清空listview填充数据
            listView1.HeaderStyle = ColumnHeaderStyle.Clickable;                                 //加载listview
            listView1.Columns.Add("项目", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("参数", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("厂家", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("单价", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("总价", 50, HorizontalAlignment.Left);
            da.Fill(ds, "test.equipment");                                                        
            int RowCount = ds.Tables[0].Rows.Count;
            int ColumnCount = ds.Tables[0].Columns.Count;
            for (int i= 0; i < RowCount; i++)
            {
                string itemName = ds.Tables[0].Rows[i][0].ToString();
                ListViewItem item = new ListViewItem(itemName);
                for (int j = 1; j < ColumnCount; j++)
                {
                    item.SubItems.Add(ds.Tables[0].Rows[i][j].ToString());
                }
                listView1.Items.Add(item);
            }
            conn.Close();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlConnection conn = db.Camcon();
            conn.Open();
            comboBox2.DataSource = null;
            combobox1_selectedvalue = comboBox1.SelectedValue.ToString();
            string sql = string.Format("SELECT equipmentID,equipmentName FROM [test].[dbo].[equipment] WHERE majorID='" + combobox1_selectedvalue + "'");
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "test.equipment");
            comboBox2.DataSource = ds.Tables["test.equipment"];
            comboBox2.DisplayMember = "equipmentName";
            comboBox2.ValueMember = "equipmentID";
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            combobox2_selectedvalue = comboBox2.SelectedValue.ToString();
            listView1.Clear();
            SqlConnection conn = db.Camcon();
            conn.Open();
            string button1value = comboBox1.SelectedValue.ToString();
            string button2value = comboBox2.SelectedValue.ToString();
            string sUserId = comboBox1.SelectedValue.ToString();
            string sql = string.Format("SELECT equipmentID,equipmentName FROM test.dbo.equipment WHERE equipmentID='" + combobox2_selectedvalue + "'");
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();                                                         //清空listview填充数据
            listView1.HeaderStyle = ColumnHeaderStyle.Clickable;                                 //加载listview
            listView1.Columns.Add("项目", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("参数", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("厂家", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("单价", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("总价", 50, HorizontalAlignment.Left);
            da.Fill(ds, "test.equipment");
            int RowCount = ds.Tables[0].Rows.Count;
            int ColumnCount = ds.Tables[0].Columns.Count;
            for (int i = 0; i < RowCount; i++)
            {
                string itemName = ds.Tables[0].Rows[i][0].ToString();
                ListViewItem item = new ListViewItem(itemName);
                for (int j = 1; j < ColumnCount; j++)
                {
                    item.SubItems.Add(ds.Tables[0].Rows[i][j].ToString());
                }
                listView1.Items.Add(item);
            }
            conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
