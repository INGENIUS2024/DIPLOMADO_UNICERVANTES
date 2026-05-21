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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login__Bienvenida_ frmLogin = new Login__Bienvenida_();
            frmLogin.Show();
            this.Hide();
        }
    }
}
