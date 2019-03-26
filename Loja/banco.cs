using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace Loja
{
    public class Banco : IDisposable
    {
        public static string connectionstring { get; set; }

        public static NpgsqlConnection connection { get; set; }

        private NpgsqlDataReader datareader { get; set; }

        private NpgsqlCommand _command { get; set; }

        public Dictionary<object, object> parametros { get; set; }

        public string sql { get; set; }

        public Banco()
        {
            connectionstring = "User ID=postgres;Password=1234;Host=localhost;Port=5432;Database=loja;";
            connectarbanco();
            parametros = new Dictionary<object, object>();
            _command = null;
        }

        private static void connectarbanco()
        {
            connection = new NpgsqlConnection(connectionstring);

            connection.Open();
        }

        //enviar valores de dados para o banco de dados usando parâmetros
        public NpgsqlDataReader ExecuteReader()
        {
            if (sql == null) throw new InvalidOperationException();
            using (var cmd = new NpgsqlCommand(sql, connection))
            {
                foreach (var p in parametros)
                {
                    cmd.Parameters.AddWithValue(p.Key.ToString(), p.Value);
                }
                parametros.Clear();
                if (datareader != null) datareader.Close();

                datareader = cmd.ExecuteReader();
                return datareader;
            }
        }

        public DataTable getDataTable()
        {
            DataTable dt = new DataTable();
            if (sql == null) throw new ArgumentNullException();
            using (_command = new NpgsqlCommand(sql, connection))
            {
                foreach (var p in parametros)
                {
                    _command.Parameters.AddWithValue(p.Key.ToString(), p.Value);
                }
                parametros.Clear();

                dt.Load(_command.ExecuteReader());
                return dt;
            }
        }

        public int GetInt()
        {
            return Convert.ToInt32(getDataTable().Rows[0][0]);
        }


        public void addParameters(object s, object p)
        {
            parametros.Add(s, p);
        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
        }
    }
}
