using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataManager.CLS
{
    public class Query : Conexion
    {
        public Query()
        {
        }

        private int ExecuteQuery(string queryTxt)   
        {
            var rowsAffected = 0;

            if (base.Connected())
            {
                MySqlCommand command = new MySqlCommand(queryTxt, _connection);
                rowsAffected = command.ExecuteNonQuery();
                base.Disconnected();
            }

            return rowsAffected;
        }

        private DataTable ExecuteSelectQuery(string selectQuery)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            try
            {
                if (Connected())
                {
                    MySqlCommand command = new MySqlCommand(selectQuery, base._connection);
                    command.CommandType = CommandType.Text;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    Disconnected();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }

            return table;
        }

        public int Insert(string queryTxt)
        {
            return ExecuteQuery(queryTxt);
        }

        public int Update(string queryTxt)
        {
            return ExecuteQuery(queryTxt);
        }

        public int Delete(string queryTxt)
        {
            return ExecuteQuery(queryTxt);
        }
        
        
    }
}