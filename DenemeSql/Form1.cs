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
using System.Reflection.Emit;

namespace DenemeSql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N25E59O;Initial Catalog=PersonelVeriTabanı;Integrated Security=True");
        void clear()
        {
            txtad.Text = "";
            txtsoyad.Text = "";
            txtid.Text = "";
            txtmeslek.Text = "";
            cmdsehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtad.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabanıDataSet.Personel' table. You can move, or remove it, as needed.
            this.personelTableAdapter.Fill(this.personelVeriTabanıDataSet.Personel);
            durum.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.personelTableAdapter.Fill(this.personelVeriTabanıDataSet.Personel);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("insert into Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek) values (@p1,@p2,@p3,@p4,@p5)",connection);
            sqlCommand.Parameters.AddWithValue("@p1", txtad.Text);
            sqlCommand.Parameters.AddWithValue("@p2", txtsoyad.Text);
            sqlCommand.Parameters.AddWithValue("@p3", cmdsehir.Text);
            sqlCommand.Parameters.AddWithValue("@p4", mskmaas.Text);
            sqlCommand.Parameters.AddWithValue("@p5", txtmeslek.Text);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            txtıd.Text = dataGridView1.Rows[selected].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[selected].Cells[2].Value.ToString();
            cmdsehir.Text = dataGridView1.Rows[selected].Cells[3].Value.ToString();
            mskmaas.Text = dataGridView1.Rows[selected].Cells[4].Value.ToString();
            durum.Text = dataGridView1.Rows[selected].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[selected].Cells[6].Value.ToString();
        }

        private void durum_TextChanged(object sender, EventArgs e)
        {
            if (durum.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (durum.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                durum.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                durum.Text = "False";
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand delete = new SqlCommand("Delete From Personel Where Personelid=@p1", connection);
            delete.Parameters.AddWithValue("@p1", txtıd.Text);
            delete.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand update = new SqlCommand("Update Personel set PerAd = @p1, PerSoyad = @p2, Persehir = @p3, Permaas = @p4, PerDurum = @p5, PerMeslek = @p6 where personelid =@p7", connection); // bu komut dıkkat edılmesı gerekenb bır komut
            update.Parameters.AddWithValue("p1", txtad.Text);
            update.Parameters.AddWithValue("p2", txtsoyad.Text);
            update.Parameters.AddWithValue("p3", cmdsehir.Text);
            update.Parameters.AddWithValue("p4", mskmaas.Text);
            update.Parameters.AddWithValue("p5", durum.Text);
            update.Parameters.AddWithValue("p6", txtmeslek.Text);
            update.Parameters.AddWithValue("p7", txtıd.Text);
            update.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Personel Güncellemesi Yapıldı");
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
