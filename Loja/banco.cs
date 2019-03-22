using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    public class Banco : IDisposable
    {
        public string connectionstring { get; set; }

        public NpgsqlConnection connection { get; set; }

        public Dictionary<string, string> parametros { get; set; }

        public string sql { get; set; }

        public Banco()
        {
            connectionstring = "User ID=postgres;Password=1234;Host=localhost;Port=5432;Database=loja;";
            connectarbanco();
            parametros = new Dictionary<string, string>();
        }

        private void connectarbanco()
        {
            connection = new NpgsqlConnection(connectionstring);

            connection.Open();
        }

        public NpgsqlDataReader ExecuteReader()
        {
            if (sql == null) throw new InvalidOperationException();
            using (var cmd = new NpgsqlCommand(sql, connection))
            {
                foreach(var p in parametros)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
                return cmd.ExecuteReader();
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
