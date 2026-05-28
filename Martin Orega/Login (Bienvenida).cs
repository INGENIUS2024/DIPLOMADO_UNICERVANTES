using Martin_Orega.Data;
using System;
using System.Data.SqlClient;
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

        // REGISTRO
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro frmRegistro = new Registro();
            frmRegistro.Show();
            this.Hide();
        }

        // LOGIN REAL SQL
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // CAPTURAR DATOS
                string correo = textBox1.Text.Trim();
                string password = textBox2.Text.Trim();

                // VALIDAR VACÍOS
                if (correo == "" || password == "")
                {
                    MessageBox.Show("Completa todos los campos");
                    return;
                }

                // CONEXIÓN SQL
                SqlConnection conn = Conexion.ObtenerConexion();

                // QUERY LOGIN
                string query = @"SELECT COUNT(*)
                                 FROM usuarios
                                 WHERE correo = @correo
                                 AND password = @password";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@password", password);

                conn.Open();

                int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                // VALIDAR USUARIO
                if (cantidad > 0)
                {
                    MessageBox.Show("Bienvenido a Orega Coffee");

                    Menú frmMenu = new Menú();
                    frmMenu.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Correo o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}