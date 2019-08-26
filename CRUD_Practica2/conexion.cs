using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace CRUD_Practica2
{
    class conexion
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dataR;
        SqlDataAdapter adaP;
        DataTable dataT;
        
        public conexion()
        {
           try
           {
               con = new SqlConnection("Data Source=.;Initial Catalog=CRUD;Integrated Security=True");
               con.Open();
           }
            catch(Exception ex)
           {
               MessageBox.Show("No se conecto con la base de datos: "+ex.ToString());
           }
        }

        public void cerrar()
        {
            con.Close();
        }

        public void conectar()
        {
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=CRUD;Integrated Security=True");
                con.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto con la base de datos: " + ex.ToString());
            }
        }
        public string insertar(int id,string nombre,string apellidos,string correo,string fecha)
        {
            string salida = "Se inserto";
            try
            {
                cmd = new SqlCommand("Insert into usuario(id,nombre,apellido,correo,fecha_nac) values("+id+",'"+nombre+"','"+apellidos+"','"+correo+"','"+fecha+"')",con);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                salida = "No se conecto: " + ex.ToString();
            }
            return salida;
        }

        public string actualizar(int id, string nombre, string apellidos, string correo, string fecha)
        {
            string salida = "Actualizado";
            try
            {
                cmd = new SqlCommand("update usuario set nombre='"+nombre+"',apellido='"+apellidos+"',correo='"+correo+"',fecha_nac='"+fecha+"' where id="+id, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se conecto: " + ex.ToString();
            }
            return salida;
        }

        public string eliminar(int id)
        {
            string salida = "Eliminado";
            try
            {
                cmd = new SqlCommand("delete from usuario where id="+id,con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se puede Eliminar" + ex.ToString();
            }
            return salida;
        }
       

        public int personaRegistraadaP(int id)
        {
            int contador = 0;
            try
            {
                cmd = new SqlCommand("Select * from usuario where Id="+id+"", con);
                dataR = cmd.ExecuteReader();
                while(dataR.Read())
                {
                    contador++;
                }
                dataR.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo consultar bien: "+ex.ToString());
            }
            return contador;
        }

        public void reporte(DataGridView dataGridView1)
        {
            try
            {
                adaP = new SqlDataAdapter("Select * from usuario",con);
                dataT = new DataTable();
                adaP.Fill(dataT);
                dataGridView1.DataSource = dataT;
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se pudo llenar el datagridview: "+ex.ToString());
            }
        }
    }
}
