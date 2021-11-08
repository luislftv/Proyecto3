
using Formulario.Controller;
using Formulario.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario
{
    public partial class pActualizar : Form
    {
        
        public pActualizar()
        {
            InitializeComponent();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                Participante participante;
                var tem = await ParticipanteControlador.buscar(Convert.ToInt32(textBox1.Text));
                participante = tem;


                textBox1.Text = Convert.ToString(participante.id);
                textBox2.Text=participante.apodo;
                dateTimePicker1.Value= participante.fecha_inscripcion;
                dateTimePicker2.Value= participante.fecha_caducidad;

                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        } 

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                Participante par = new Participante
                {
                    id = Convert.ToInt32(textBox1.Text),
                    apodo = textBox2.Text,
                    fecha_inscripcion = dateTimePicker1.Value,
                    fecha_caducidad = dateTimePicker2.Value
                };

                await ParticipanteControlador.actualizar(par);

                MessageBox.Show("Participante Actualizado");
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se pudo Actualizar el Participante");
            }
        }

        private void pActualizar_Load(object sender, EventArgs e)
        {

        }
    }
}
