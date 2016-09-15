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
    public partial class Form_project : Form
    {
        string listview1_selectedvalue;
        public Form_project()
        {
            InitializeComponent();
        }

        private void Form_project_Load(object sender, EventArgs e)
        {
            SqlConnection conn = db.Camcon();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Scrollable = true;
            listView1.MultiSelect = false;
            try                                                                                 //连接数据库
            {
                conn.Open();
                string sql = string.Format("SELECT projectName FROM test.dbo.projectInfo");
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();                                                         //清空listview填充数据
                listView1.HeaderStyle = ColumnHeaderStyle.Clickable;                                 //加载listview
                listView1.Columns.Add("项目", 100, HorizontalAlignment.Left);
                da.Fill(ds, "test.projectInfo");
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
            }
            catch (SqlException ex)
            {
                MessageBox.Show("连接错误！");
            }
            finally
            {
                conn.Close();
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listview1_selectedvalue = this.listView1.SelectedItems[0].Text;
            SqlConnection conn = db.Camcon();
            try                                                                                  //连接数据库
            {
                conn.Open();
                string sql = string.Format("SELECT projectDescription FROM test.dbo.projectInfo WHERE projectName='"+listview1_selectedvalue+"'");
                SqlCommand cmd = new SqlCommand(sql, conn);
                textBox3.Clear();
                textBox3.AppendText(cmd.ExecuteScalar().ToString());
                label4.Text = listview1_selectedvalue+"项目信息：";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("连接错误！");
            }
            finally
            {
                conn.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text=textBox3.Text;
            SqlConnection conn = db.Camcon();
            try                                                                                  //连接数据库
            {
                conn.Open();
                string sql = string.Format("UPDATE test.dbo.projectInfo SET projectDescription='" + text + "' WHERE projectName='" + listview1_selectedvalue + "'");
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show(listview1_selectedvalue+"项目信息保存成功！");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("连接错误！");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
