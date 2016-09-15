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
    public partial class Form_dataversion : Form
    {
        string combobox1_selectedvalue;
        string combobox2_selectedvalue;
        string combobox4_selectedvalue;
        public Form_dataversion()
        {
            InitializeComponent();
        }

        private void Form_dataversion_Load(object sender, EventArgs e)
        {
            SqlConnection conn = db.Camcon();
            try                                                                                 //combobox1连接数据库
            {
                conn.Open();
                string sql = @"SELECT projectID,projectName FROM test.dbo.projectInfo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //创建数据适配器和数据集
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "test.projectInfo");
                comboBox1.DataSource = ds.Tables["test.projectInfo"];
                comboBox1.DisplayMember = "projectName";
                comboBox1.ValueMember = "projectID";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("发生如下错误：" + ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            try                                                                                 //combobox2连接数据库
            {
                conn.Open();
                string sql = @"SELECT projectID,projectName FROM test.dbo.projectInfo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //创建数据适配器和数据集
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "test.projectInfo");
                comboBox4.DataSource = ds.Tables["test.projectInfo"];
                comboBox4.DisplayMember = "projectName";
                comboBox4.ValueMember = "projectID";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("发生如下错误：" + ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }   
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlConnection conn = db.Camcon();
            try
            {
                conn.Open();
                comboBox2.DataSource = null;
                combobox1_selectedvalue = comboBox1.SelectedValue.ToString();
                string sql = string.Format("SELECT dataversionID,dataversionName FROM [test].[dbo].[dataversion] WHERE projectID='" + combobox1_selectedvalue + "'");
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "test.dataversion");
                comboBox2.DataSource = ds.Tables["test.dataversion"];
                comboBox2.DisplayMember = "dataversionName";
                comboBox2.ValueMember = "dataversionID";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("发生如下错误：" + ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
                combobox4_selectedvalue = comboBox1.SelectedValue.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = db.Camcon();
            try
            {
                conn.Open();
                combobox4_selectedvalue = comboBox1.SelectedValue.ToString();
                string sql = string.Format("INSERT INTO [test].[dbo].[dataversion]" +
                                            " (dataversionName,dataversionDescription,projectID)" +
                                            "VALUES ('" + textBox3.Text.ToString() + "','" +
                                            textBox2.Text.ToString() + "','" +
                                            comboBox4.SelectedValue.ToString() + "')");
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("“" + comboBox4.Text.Trim() + "”项目\n“" + textBox3.Text.ToString() + "”提资\n添加成功，请返回前一窗口继续操作！");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("发生如下错误：" + ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox1.Clear();
            SqlConnection conn = db.Camcon();
            try
            {
                conn.Open();
                combobox2_selectedvalue = comboBox2.SelectedValue.ToString();
                string sql = string.Format("SELECT dataversionDescription FROM [test].[dbo].[dataversion] WHERE projectID='" + combobox1_selectedvalue + "'"+
                                            "AND dataversionID='" + combobox2_selectedvalue + "'");
                SqlCommand cmd = new SqlCommand(sql, conn);
                textBox1.Clear();
                textBox1.AppendText(cmd.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            {
                MessageBox.Show("发生如下错误：" + ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = db.Camcon();
            try
            {
                conn.Open();
                string sql = string.Format("UPDATE test.dbo.dataversion SET dataversionDescription='" + textBox1.Text + "'");
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("“" + comboBox1.Text.Trim() + "”项目\n“" + comboBox2.Text.Trim() + "”提资\n更改成功，请返回前一窗口继续操作！");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("发生如下错误：" + ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
