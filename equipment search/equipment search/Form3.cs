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
    public partial class Form3 : Form
    {
        string combobox1_selectedvalue;
        string combobox2_selectedvalue;
        string combobox3_selectedvalue;
        string combobox4_selectedvalue;
        string combobox5_selectedvalue;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_project form = new Form_project();
            form.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true;                                                     //加载listview的表头
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Scrollable = true;
            listView1.MultiSelect = false;
            listView1.HeaderStyle = ColumnHeaderStyle.Clickable; 
            listView1.Columns.Add("项目", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("参数", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("厂家", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("单价", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("总价", 50, HorizontalAlignment.Left);
            SqlConnection conn = db.Camcon();
            try                                                                                 //连接数据库
            {
                conn.Open();
                string project = @"SELECT projectID,projectName FROM test.dbo.projectInfo";                   //加载项目名称
                SqlCommand project_cmd = new SqlCommand(project, conn);
                SqlDataAdapter project_da = new SqlDataAdapter(project, conn);
                DataSet project_ds = new DataSet();
                project_da.Fill(project_ds, "test.projectInfo");
                comboBox1.DataSource = project_ds.Tables["test.projectInfo"];
                comboBox1.DisplayMember = "projectName";
                comboBox1.ValueMember = "projectID";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("项目数据库连接错误！");
            }
            finally
            {
                conn.Close();
            }                                                                                //连接数据库完成
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("保存成功，按“确定”返回！");
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlConnection conn = db.Camcon();
            try                                                                                 //连接项目数据库
            {
                conn.Open();
                string combobox1_selectedvalue = comboBox1.SelectedValue.ToString();
                string sql = @"SELECT majorID,majorName FROM test.dbo.major";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //创建数据适配器和数据集
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "test.major");
                comboBox2.DataSource = ds.Tables["test.major"];
                comboBox2.DisplayMember = "majorName";
                comboBox2.ValueMember = "majorID";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("专业数据库连接错误！");
            }
            finally
            {
                conn.Close();
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlConnection conn = db.Camcon();
            try                                                                                 //连接设备数据库
            {                                                    
            conn.Open();
            string combobox2_selectedvalue = comboBox2.SelectedValue.ToString();
            string sql = string.Format("SELECT equipmentID,equipmentName FROM [test].[dbo].[equipment] WHERE majorID='" + combobox2_selectedvalue + "'");
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "test.equipment");
            comboBox3.DataSource = ds.Tables["test.equipment"];
            comboBox3.DisplayMember = "equipmentName";
            comboBox3.ValueMember = "equipmentID";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("设备数据库连接错误！");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_searchvendor form = new Form_searchvendor();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_equipment form = new Form_equipment();
            form.ShowDialog();
        }
    }
}
