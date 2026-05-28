using Martin_Orega.Services;
using System;
using System.Windows.Forms;

namespace Martin_Orega
{
    public partial class Menú : Form
    {
        public Menú()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                // CAPTURAR MENSAJE
                string mensaje = txtMensaje.Text.Trim();

                // VALIDAR VACÍO
                if (string.IsNullOrEmpty(mensaje))
                {
                    MessageBox.Show("Escribe un mensaje");
                    return;
                }

                // CREAR SERVICIO CHATBOT
                ChatService chatService = new ChatService();

                // OBTENER RESPUESTA
                string respuesta = chatService.ObtenerRespuesta(mensaje);

                // VALIDAR SI NO HAY RESPUESTA
                if (string.IsNullOrEmpty(respuesta))
                {
                    respuesta = "Lo siento, no entendí tu mensaje.";
                }

                // MOSTRAR MENSAJE USUARIO
                rtbChat.AppendText(
                    "Tú: " + mensaje + Environment.NewLine
                );

                // MOSTRAR RESPUESTA BOT
                rtbChat.AppendText(
                    "Martin Orega: " + respuesta + Environment.NewLine + Environment.NewLine
                );

                // GUARDAR EN SQL
                chatService.GuardarConversacion(
                    "Andres",
                    mensaje,
                    respuesta
                );

                // LIMPIAR CAJA TEXTO
                txtMensaje.Clear();

                // VOLVER ENFOQUE
                txtMensaje.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}