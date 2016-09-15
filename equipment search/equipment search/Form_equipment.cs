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
    public partial class Form_equipment : Form
    {
        string combobox1_selectedvalue;
        string combobox2_selectedvalue;
        string combobox3_selectedvalue;
        public Form_equipment()
        {
            InitializeComponent();
        }

        private void Form_equipment_Load(object sender, EventArgs e)
        {
            SqlConnection conn = db.Camcon(); 
            try                                                                                 //combobox1连接数据库
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
            }
            try                                                                                 //combobox2连接数据库
            {
                conn.Open();
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
                MessageBox.Show("发生如下错误：" + ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }   
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlConnection conn = db.Camcon();
            try
            {
                conn.Open();
                comboBox3.DataSource = null;
                combobox2_selectedvalue = comboBox2.SelectedValue.ToString();
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
                MessageBox.Show("发生如下错误：" + ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlConnection conn = db.Camcon();
            try
            {
                conn.Open();
                combobox3_selectedvalue = comboBox3.SelectedValue.ToString();
                string sql = string.Format("SELECT equipmentIntroduction FROM [test].[dbo].[equipment]"+
                                            " WHERE majorID='" + combobox2_selectedvalue + "'"+
                                            "AND equipmentID='"+combobox3_selectedvalue+"'");
                SqlCommand cmd = new SqlCommand(sql,conn);
                textBox4.Clear();
                textBox4.AppendText(cmd.ExecuteScalar().ToString());
                sql = string.Format("SELECT priceKeyPoint FROM [test].[dbo].[equipment]" +
                                            " WHERE majorID='" + combobox2_selectedvalue + "'" +
                                            "AND equipmentID='" + combobox3_selectedvalue + "'");
                cmd = new SqlCommand(sql, conn);
                textBox5.Clear();
                textBox5.AppendText(cmd.ExecuteScalar().ToString());
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

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = db.Camcon();
            try
            {
                conn.Open();
                string sql = string.Format("UPDATE test.dbo.equipment SET equipmentIntroduction='" + textBox4.Text +"',"
                                            +"priceKeyPoint='" + textBox5.Text +"'"+
                                            " WHERE majorID='" + combobox2_selectedvalue + "'" +
                                            "AND equipmentID='" + combobox3_selectedvalue + "'");
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("“" + comboBox2.Text.Trim() + "”专业\n“" + comboBox3.Text.Trim() + "”设备\n信息保存成功！");
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
                combobox1_selectedvalue = comboBox1.SelectedValue.ToString();
                string sql = string.Format("INSERT INTO [test].[dbo].[equipment]" +
                                            " (equipmentName,equipmentIntroduction,priceKeyPoint,majorID)" + 
                                            "VALUES ('" + textBox1.Text.ToString()+ "','"+
                                            textBox2.Text.ToString()+"','"+
                                            textBox3.Text.ToString() + "','" +
                                            comboBox1.SelectedValue.ToString()+"')");
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("“" + comboBox1.Text.Trim() + "”专业\n“" + textBox1.Text.Trim() + "”设备\n添加成功，请返回前一窗口继续操作！");
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
