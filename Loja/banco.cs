using Npgsql;
using System;
using System.Collections.Generic;

namespace Loja
{
    public class Banco : IDisposable
    {
        public static string connectionstring { get; set; }

        public static NpgsqlConnection connection { get; set; }

        private NpgsqlDataReader datareader { get; set; }

        public Dictionary<string, string> parametros { get; set; }

        public string sql { get; set; }

        public Banco()
        {
            connectionstring = "User ID=postgres;Password=1234;Host=localhost;Port=5432;Database=loja;";
            connectarbanco();
            parametros = new Dictionary<string, string>();
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
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
                parametros.Clear();
                if (datareader != null) datareader.Close();

                datareader = cmd.ExecuteReader();
                return datareader;
            }
        }
        public void addParameters(string s, string p)
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
