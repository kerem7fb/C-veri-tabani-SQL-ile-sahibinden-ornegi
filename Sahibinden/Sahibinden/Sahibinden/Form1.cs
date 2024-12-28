using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Sahibinden
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void görüntüle() 
        {
            yeni.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select* From AracBilgi", yeni);
            DataTable dt = new DataTable();
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            yeni.Close();
        }
        OleDbConnection yeni = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\user\\Desktop\\10-M\\Sahibinden\\Sahibinden.mdb");
        
        private void button1_Click(object sender, EventArgs e)
        {
            görüntüle();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            yeni.Open();
            OleDbCommand komut = new OleDbCommand("Delete From AracBilgi Where Model='"+textBox1.Text+"'", yeni);
            komut.ExecuteNonQuery();
            yeni.Close();
            görüntüle();
          
        }
        private void button3_Click(object sender, EventArgs e)
        {
            yeni.Open();
            OleDbCommand komut = new OleDbCommand("Update AracBilgi Set Marka='" + comboBox1.Text + "',KapiSayisi='" + textBox3.Text + "'Where Model='" + textBox1.Text + "'", yeni);
            komut.ExecuteNonQuery();
            yeni.Close();
            görüntüle();
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            yeni.Open();
            OleDbCommand komut = new OleDbCommand("Insert into AracBilgi(Marka,Model,Yakit,VitesTipi,Kilometre,KapiSayisi)values('" + comboBox1.Text + "','" + textBox1.Text + "','" + comboBox4.Text + "','" + comboBox3.Text + "','" + textBox2.Text + "','"+textBox3.Text+"')", yeni);
            komut.ExecuteNonQuery();
            yeni.Close();
            görüntüle();
         
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
