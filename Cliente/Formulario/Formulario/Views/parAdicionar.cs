﻿
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
    public partial class parAdicionar : Form
    {
        public parAdicionar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*try
            {
                participante p = new participante();

                SWParticipanteClient servicio = new SWParticipanteClient();

                p.apodo = textBox1.Text;

                participante[] filtrar = servicio.listarParticipantes();

                DataTable dt;

                dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("Apodo");
                dt.Columns.Add("Fecha Inscripción");
                dt.Columns.Add("Fecha Expiración");
                dataGridView1.DataSource = dt;

                for (int i = 0; i < filtrar.Length; i++)
                {
                    DataRow row = dt.NewRow();

                    row["Id"] = filtrar[i].id;
                    row["Apodo"] = filtrar[i].apodo;
                    row["Fecha Inscripción"] = filtrar[i].fechaInscripcion;
                    row["Fecha Expiración"] = filtrar[i].fechaCaducidad;

                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // mesa p = new mesa();

           /* try
            {
                ServiceMesa.SWmesaClient servicio = new ServiceMesa.SWmesaClient();



                ServiceMesa.mesa[] filtrar = servicio.listarMesas();

                DataTable dt;

                dt = new DataTable();
                dt.Columns.Add("Id Mesa");
                dt.Columns.Add("Localidad");
                dt.Columns.Add("Nombre Lugar");
                dataGridView2.DataSource = dt;

                for (int i = 0; i < filtrar.Length; i++)
                {
                    DataRow row = dt.NewRow();

                    row["Id Mesa"] = filtrar[i].idMesa;
                    row["Localidad"] = filtrar[i].localidad;
                    row["Nombre Lugar"] = filtrar[i].idMesa;

                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }*/
        }

        private async void button3_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                

                Partido partido = new Partido
                {
                    id= new Id
                    {

                        mesa = Convert.ToInt32(textBox1.Text),
                        participante = Convert.ToInt32(textBox2.Text),
                        participante1 = Convert.ToInt32(textBox3.Text)

                    },
                    ganador = Convert.ToInt32(textBox4.Text),
                    ronda = Convert.ToInt32(textBox5.Text),
                    fecha_programada = dateTimePicker1.Value,
                    hora_inicio = dateTimePicker2.Value,
                    hora_fin = dateTimePicker3.Value,
                    torneo = textBox9.Text

                };


                await PartidoControlador.agregar(partido);

                MessageBox.Show("Partido Agregado");



            }
            catch (Exception ex)
            {

                MessageBox.Show("No se pudo Agregar el Partido");
            }

        }
    }
}
