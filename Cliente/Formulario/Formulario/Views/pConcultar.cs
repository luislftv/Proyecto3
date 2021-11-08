
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
    public partial class pConcultar : Form
    {
        public pConcultar()
        {
            InitializeComponent();
        }

        //public static participante p = new participante();
        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            try{
                Participante participante;
                var tem = await ParticipanteControlador.buscar(Convert.ToInt32(textBox1.Text));
                participante = tem;


                textBox1.Text = Convert.ToString(participante.id);
                textBox2.Text = participante.apodo;
                dateTimePicker1.Value = participante.fecha_inscripcion;
                dateTimePicker2.Value = participante.fecha_caducidad;



            }
            catch (Exception ex)
            {

                MessageBox.Show("Participante no encontrado");
            }




        }
    }
}
