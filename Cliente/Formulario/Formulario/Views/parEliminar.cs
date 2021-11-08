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

namespace Formulario.Views
{
    public partial class parEliminar : Form
    {
        public parEliminar()
        {
            InitializeComponent();
        }

       
        private async void button3_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                Id id = new Id
                {

                    mesa = Convert.ToInt32(textBox1.Text),
                    participante = Convert.ToInt32(textBox2.Text),
                    participante1 = Convert.ToInt32(textBox3.Text)

                };

                var tem = await PartidoControlador.buscar(id);
                Partido partido = tem;


                textBox4.Text = Convert.ToString(partido.ganador);
                textBox5.Text = Convert.ToString(partido.ronda);
                dateTimePicker1.Value = partido.fecha_programada;
                dateTimePicker2.Value = partido.hora_inicio;
                dateTimePicker3.Value = partido.hora_fin;
                textBox9.Text = partido.torneo;


                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                Id id = new Id
                {

                    mesa = Convert.ToInt32(textBox1.Text),
                    participante = Convert.ToInt32(textBox2.Text),
                    participante1 = Convert.ToInt32(textBox3.Text)

                };

                var tem = await PartidoControlador.eliminar(id);


                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                dateTimePicker3.Value = DateTime.Now;
                textBox9.Text = "";

                MessageBox.Show("Partido eliminado");


            }
            catch (Exception ex)
            {

                MessageBox.Show("No se pudo eliminar el partido");
            }
        }
    }
}
