
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
    public partial class pListar : Form
    {
      
        public pListar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                List<Participante> participantesLista = await ParticipanteControlador.listarFiltroAsync(textBox1.Text);
                int i = 0;
                DataTable dt;

                dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("Apodo");
                dt.Columns.Add("Fecha Inscripción");
                dt.Columns.Add("Fecha Expiración");
                dataGridView1.DataSource = dt;

                foreach (Participante p in participantesLista)
                {
                    DataRow row = dt.NewRow();

                    row["Id"] = participantesLista[i].id;
                    row["Apodo"] = participantesLista[i].apodo;
                    row["Fecha Inscripción"] = participantesLista[i].fecha_inscripcion.ToString();
                    row["Fecha Expiración"] = participantesLista[i].fecha_caducidad.ToString();

                    dt.Rows.Add(row);
                    i++;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }





        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
          List<Participante> participantesLista = await ParticipanteControlador.listarAsync();
           int i = 0;
            DataTable dt;

            dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Apodo");
            dt.Columns.Add("Fecha Inscripción");
            dt.Columns.Add("Fecha Expiración");
            dataGridView1.DataSource = dt;

            foreach (Participante p in participantesLista)
            {
                DataRow row = dt.NewRow();

                row["Id"] = participantesLista[i].id;
                row["Apodo"] = participantesLista[i].apodo;
                row["Fecha Inscripción"] = participantesLista[i].fecha_inscripcion.ToString();
                row["Fecha Expiración"] = participantesLista[i].fecha_caducidad.ToString();

                dt.Rows.Add(row);
                i++;
            }



        }
    }
}
