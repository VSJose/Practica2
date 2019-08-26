using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CRUD_Practica2
{
    public partial class Form1 : Form
    {
        conexion c = new conexion();       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c.personaRegistraadaP(Convert.ToInt32(textBox1.Text)) == 0)
            {
                MessageBox.Show(c.insertar(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text,dateTimePicker1.Text));
            }
            else
            {
                MessageBox.Show("Imposible de regitrar, El registro ya existe");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String texto = textBox1.Text;
            frmReporte f = new frmReporte();
            f.Show();
            this.Hide();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            this.Location = new Point(100,100);
            conexion c = new conexion();
            c.conectar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (c.personaRegistraadaP(Convert.ToInt32(textBox1.Text)) == 1)
            {
                MessageBox.Show(c.actualizar(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Text));
            }
            else
            {
                MessageBox.Show("Imposible de actualizar, El registro no existe");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (c.personaRegistraadaP(Convert.ToInt32(textBox1.Text)) == 1)
            {
                MessageBox.Show(c.eliminar(Convert.ToInt32(textBox1.Text)));
            }
            else
            {
                MessageBox.Show("Imposible eliminar, El registro no existe");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            c.cerrar();
        }
    }
}
