using Martin_Orega.Data;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Martin_Orega
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        // BOTÓN REGISTRAR
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                string correo = txtCorreo.Text.Trim();
                string password = txtPassword.Text.Trim();
                string validar = txtValidarPassword.Text.Trim();

                // VALIDAR CAMPOS
                if (nombre == "" ||
                    correo == "" ||
                    password == "" ||
                    validar == "")
                {
                    MessageBox.Show("Completa todos los campos");
                    return;
                }

                // VALIDAR CONTRASEÑAS
                if (password != validar)
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                    return;
                }

                SqlConnection conn = Conexion.ObtenerConexion();

                string query = @"INSERT INTO usuarios
                                (nombre, correo, password, rol, estado)
                                VALUES
                                (@nombre, @correo, @password, 'Cliente', 1)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@password", password);

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Usuario registrado correctamente");

                Login__Bienvenida_ frmLogin = new Login__Bienvenida_();
                frmLogin.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // BOTÓN VOLVER
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Login__Bienvenida_ frmLogin = new Login__Bienvenida_();
            frmLogin.Show();

            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}