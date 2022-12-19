using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace odev5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Load(@"C:\Users\cansu\Desktop\caNsu\algoritma\görsel ödevleri\21015222027_odev5\odev5\lotus-cicegi.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        string cinsiyet;
        string kanGrubu;
        string boy;
        string kilo;
        string kabiliyet;
        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.PasswordChar = '*';
            if (textBox4.Text.Length > 8)
                errorProvider1.SetError(textBox4, "en az 8 karakter olmalıdır.");
            else
                errorProvider1.SetError(textBox4, "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dosya = "";

            OpenFileDialog fd = new OpenFileDialog() { Filter = "Resim Dosyaları|*.jpg;*.png;*.bmp;*.txt" };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                dosya = fd.FileName;
            }

            try
            {
                pictureBox1.Load(dosya);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata oluştu");
                pictureBox1.Image = SystemIcons.Error.ToBitmap();
            }
            finally
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                errorProvider1.SetError(textBox1, "Ad boş bırakılmaz");
            if (textBox2.Text == "")
                errorProvider1.SetError(textBox2, "Soyad boş bırakılamaz");
            if (!maskedTextBox1.MaskCompleted)
                errorProvider1.SetError(maskedTextBox1, "geçerli bir telefon numrası giriniz");
            else
                errorProvider1.SetError(maskedTextBox1, "");
            if (comboBox1.Text == "")
                errorProvider1.SetError(comboBox1, "memleket boş bırakılamaz");
            if (textBox3.Text == "")
                errorProvider1.SetError(textBox3, "Adres boş geçemez");
            if (dateTimePicker1.Text == "")
                errorProvider1.SetError(dateTimePicker1, "Doğum Tarihi giriniz");
            if (textBox4.Text == "")
                errorProvider1.SetError(textBox4, "şifre boş bırakılamaz");

            if (radioButton1.Checked == true)
                cinsiyet = radioButton1.Text;
            if (radioButton2.Checked == true)
                cinsiyet = radioButton2.Text;

            kanGrubu = listBox1.SelectedItem.ToString();
            kabiliyet = checkedListBox1.SelectedItem.ToString();
            boy = numericUpDown1.Value.ToString();
            kilo = numericUpDown2.Value.ToString();

            string mesaj = "Sayın\t" + textBox1.Text + "\t" + textBox2.Text + "\nTelefon no : " + maskedTextBox1.Text + "\nMemleket : " + comboBox1.Text + "\nAdres : " + textBox3.Text + "\nDoğum Tarihi : " 
                + dateTimePicker1.Text + "\nCinsiyet:" + cinsiyet + "\nKan Grubu : " + kanGrubu + "\nExtra Kabiliyet : " + kabiliyet + "\nBoy:" + boy + "\tcm" + "\nKilo:" + kilo + "\tkg"
                ;

            DialogResult dr = MessageBox.Show(mesaj, "kayıt onay", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                textBox1.Clear();
                textBox2.Clear();
                maskedTextBox1.Clear();
                textBox3.Clear();
                listBox1.ClearSelected();
                checkedListBox1.ClearSelected();
                textBox4.Clear();
            }
            else
            {
                Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = checkBox1.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult Dr = MessageBox.Show("Silmek istediğinize emin misiniz", "dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (Dr == DialogResult.Yes)
            {
                Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\cansu\Desktop\caNsu\algoritma\görsel ödevleri\21015222027_odev5\odev5\anlasmaformu.txt");
            linkLabel1.LinkVisited = true;
        }
    }
}
