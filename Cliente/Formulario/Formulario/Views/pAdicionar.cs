using Formulario.Controller;
using Formulario.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario
{
    public partial class pAdicionar : Form
    {
        public pAdicionar()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            
            try
            {
              
                Participante participante = new Participante
                {
                    id = Convert.ToInt32(textBox1.Text),
                    apodo = textBox2.Text,
                    fecha_inscripcion = dateTimePicker1.Value,
                    fecha_caducidad = dateTimePicker2.Value
                };


               await ParticipanteControlador.agregar(participante);

                MessageBox.Show("Participante Agregado");

            }
            catch (Exception ex)
            {

                MessageBox.Show("No se pudo Agregar el Particiante");
            }



        }
    }
}
