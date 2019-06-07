using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaVendas.Uteis
{
    public class DAL
    {
        private static string Server   = "localhost";
        private static string Database = "sistema_venda";
        private static string User = "root";
        private static string Password = "";
        private static string ConnectionString = $"Server={Server};Database={Database};Uid={User};Pwd={Password};Sslmode=none;Charset=utf8;";

        private static MySqlConnection Connection;

        public DAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }

        public DataTable RetornaDataTable(string sql)
        {
            DataTable data = new DataTable();

            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter AdaptadorData = new MySqlDataAdapter(Command);
            AdaptadorData.Fill(data);

            return data;
        }

        public void ExecutaInsertUpdateDelete(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }
    }
}
