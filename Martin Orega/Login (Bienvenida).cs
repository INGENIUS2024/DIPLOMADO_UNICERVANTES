using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Martin_Orega
{
    public partial class Login__Bienvenida_ : Form
    {
        public Login__Bienvenida_()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro frmRegistro = new Registro();
            frmRegistro.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menú frmMenu = new Menú();
            frmMenu.Show();
            this.Hide();
        }
    }
}
