using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUD_Practica2
{
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            this.Location = new Point(100, 100);
            conexion c = new conexion();
            c.conectar();
            try
            {
                c.reporte(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto con la base de datos: " + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 c = new Form1();
            c.Show();
            this.Close();
        }

        private void frmReporte_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
        }

        private void frmReporte_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 c = new Form1();
            c.Show();
        }
    }
}
