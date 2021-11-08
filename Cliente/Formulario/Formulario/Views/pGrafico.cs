
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
using System.Windows.Forms.DataVisualization.Charting;

namespace Formulario
{
    public partial class pGrafico : Form
    {
        public pGrafico()
        {
            InitializeComponent();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {

            try
            {

                Participante participante;
                var tem = await ParticipanteControlador.buscar(Convert.ToInt32(textBox1.Text));
                participante = tem;

               
                int[] datos = await ParticipanteControlador.estadisticas(participante.id);



                String[] series = { "Blancas", "Negras" };
                chart1.Titles.Add("Jugador");

                for (int i = 0; i < series.Length; i++)
                {
                    Series serie = chart1.Series.Add(series[i]);

                    serie.Label = datos[i].ToString();
                    serie.Points.Add(Convert.ToInt32(datos[i]));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
    }
}
