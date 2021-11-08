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
    public partial class parListar : Form
    {
        public parListar()
        {
            InitializeComponent();
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {

            List<Partido> partidossLista = await PartidoControlador.listarAsync();
            int i = 0;
            DataTable dt;

            dt = new DataTable();
            dt.Columns.Add("Id Mesa");
            dt.Columns.Add("Apodo Participante 1");
            dt.Columns.Add("Apodo Participante 2");
            dt.Columns.Add("Ganador");
            dt.Columns.Add("Ronda");
            dt.Columns.Add("Fecha Programada");
            dt.Columns.Add("Hora Inicio");
            dt.Columns.Add("Hora Fin");
            dt.Columns.Add("Torneo");
            dataGridView1.DataSource = dt;

            foreach (Partido p in partidossLista)
            {
                DataRow row = dt.NewRow();

                row["Id Mesa"] = partidossLista[i].id.mesa;
                row["Apodo Participante 1"] = partidossLista[i].id.participante;
                row["Apodo Participante 2"] = partidossLista[i].id.participante1;
                row["Ganador"] = partidossLista[i].ganador;
                row["Ronda"] = partidossLista[i].ronda;
                row["Fecha Programada"] = partidossLista[i].fecha_programada.ToString();
                row["Hora Inicio"] = partidossLista[i].hora_inicio.ToString();
                row["Hora Fin"] = partidossLista[i].hora_fin.ToString();
                row["Torneo"] = partidossLista[i].torneo;

                dt.Rows.Add(row);
                i++;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
