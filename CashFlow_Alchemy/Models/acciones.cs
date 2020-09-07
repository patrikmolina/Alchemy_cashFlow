using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mvc;

namespace CashFlow_Alchemy.Models
{
    public class acciones
    {

        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["context_registros"].ToString();
            con = new SqlConnection(constr);
        }





        public int Alta(Operaciones op)
        {
            
            Conectar();
            SqlCommand comando = new SqlCommand("insert into operaciones(Concepto, Monto, Fecha, Tipo) values (@Concepto, @Monto, @Fecha, @Tipo)", con);
            comando.Parameters.Add("@Concepto", SqlDbType.VarChar);
            comando.Parameters.Add("@Monto", SqlDbType.Int);
            comando.Parameters.Add("@Fecha", SqlDbType.Date);
            comando.Parameters.Add("@Tipo", SqlDbType.VarChar);
            comando.Parameters["@Concepto"].Value = op.Concepto;
            comando.Parameters["@Monto"].Value = op.Monto;
            comando.Parameters["@Fecha"].Value = op.Fecha;
            comando.Parameters["@Tipo"].Value = op.Tipo;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public operaciones_montos RecuperarTodos()
        {
            Conectar();
            List<Operaciones> all_the_transactions = new List<Operaciones>();
            operaciones_montos op_montos = new operaciones_montos();

            SqlCommand com = new SqlCommand("select Id, Concepto, Monto, Fecha, Tipo from operaciones", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Operaciones op = new Operaciones
                {
                    Id = int.Parse(registros["Id"].ToString()),
                    Concepto = registros["Concepto"].ToString(),
                    Monto = double.Parse(registros["Monto"].ToString()),
                    Fecha = DateTime.Parse(registros["Fecha"].ToString()),
                    Tipo = registros["Tipo"].ToString()
                };
                all_the_transactions.Add(op);
            }
            con.Close();

            foreach (var item in all_the_transactions)
            {
                if (item.Tipo == "Ingreso")
                {
                    op_montos.Total_ingreso += float.Parse(item.Monto.ToString());
                }
                else
                { op_montos.Total_egreso += float.Parse(item.Monto.ToString()); }


            }

            op_montos.Total = op_montos.Total_ingreso - op_montos.Total_egreso;
            op_montos.Lista_operaciones = all_the_transactions;

            return op_montos;
        }

        public Operaciones Recuperar(int Id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select Id, Concepto, Monto, Fecha from operaciones where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = Id;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Operaciones op = new Operaciones();
            if (registros.Read())
            {
                op.Id = int.Parse(registros["Id"].ToString());
                op.Monto = float.Parse(registros["Monto"].ToString());
                op.Concepto = registros["Concepto"].ToString();
                op.Fecha = DateTime.Parse(registros["Fecha"].ToString());
            }
            con.Close();
            return op;
        }

        public int Modificar(Operaciones op)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update operaciones set Concepto=@Concepto, Monto=@Monto, Fecha=@Fecha where id=@id", con);
            comando.Parameters.Add("@Concepto", SqlDbType.VarChar);
            comando.Parameters["@Concepto"].Value = op.Concepto;
            comando.Parameters.Add("@Monto", SqlDbType.Float);
            comando.Parameters["@Monto"].Value = op.Monto;
            comando.Parameters.Add("@Fecha", SqlDbType.Date);
            comando.Parameters["@Fecha"].Value = op.Fecha;
            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value = op.Id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(int id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from operaciones where id=@id", con);
            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value = id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        
    }
}