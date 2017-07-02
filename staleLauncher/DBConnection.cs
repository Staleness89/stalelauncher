using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace sqlTools
{
    class DBConnection
    {
        public static string connectionString;
        public static bool sqlProcessOpen = false;

        public static bool Connect(string user, string password, string address, string port)
        {
            connectionString = "user id=" + user + ";" +
            "password=" + password + "; " +
            "server=" + address + ";" +
            "database=auth;" +
            "port=" + port + ";" +
            "Convert Zero Datetime=True";

            try
            {
                MySqlConnection testConnection = new MySqlConnection(connectionString);
                testConnection.Open();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static void GetAccountData(DataGridView dataGridView)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string accountSelect = "SELECT account.id, account.username, account.expansion, account_access.gmlevel, realmcharacters.numchars FROM account " +
                "LEFT OUTER JOIN account_access ON account.id = account_access.id " +
                "LEFT OUTER JOIN realmcharacters ON account.id = realmcharacters.acctid";
            MyDA.SelectCommand = new MySqlCommand(accountSelect, connection);

            DataTable mainTable = new DataTable();
            MyDA.Fill(mainTable);


            BindingSource bSource = new BindingSource();
            bSource.DataSource = mainTable;

            dataGridView.DataSource = bSource;
            dataGridView.Sort(dataGridView.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

            dataGridView.Columns[4].HeaderText = "characters";
        }

        public static bool CreateAccount(string accountName, string accountPassword, string expansion, string gmLevel)
        {
            if (accountName == "" || accountPassword == "")
                return false;

            try
            {
                int expansionInt = 0;
                Int32.TryParse(expansion, out expansionInt);

                string query = "INSERT INTO account(`username`, `sha_pass_hash`, `expansion`) VALUES" +
                    "('" + accountName + "', SHA1(CONCAT(UPPER('" + accountName + "'),':',UPPER('" + accountPassword + "')))," + expansionInt + ");";

                MySqlConnection queryConnection = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(query, queryConnection);

                queryConnection.Open();


                if (cmd.ExecuteNonQuery() == 0)
                    return false;

                string queryTwo = "INSERT INTO account_access(`id`, `gmlevel`, `realmId`)" +
                "VALUES((SELECT `id` FROM account WHERE username ='" + accountName + "')," + gmLevel + ", -1);";

                MySqlCommand cmdTwo = new MySqlCommand(queryTwo, queryConnection);

                if (cmdTwo.ExecuteNonQuery() == 0)
                    return false;

                queryConnection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static bool SetAccountPassword(string accountName, string newPassword)
        {
            if (accountName == "" || newPassword == "")
                return false;

            try
            {
                string query = "UPDATE account SET sha_pass_hash = SHA1(CONCAT(UPPER('" + accountName + "'),':',UPPER('" + newPassword + "'))) WHERE username='" + accountName + "';";

                MySqlConnection queryConnection = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(query, queryConnection);

                queryConnection.Open();

                if (cmd.ExecuteNonQuery() == 0)
                    return false;

                queryConnection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static bool DeleteAccount(string accountName)
        {
            if (accountName == "")
                return false;

            try
            {
                string query = "DELETE FROM account_access WHERE id=(SELECT `id` FROM account WHERE username ='" + accountName + "'); " +
                    "DELETE FROM account WHERE username='" + accountName + "';";

                MySqlConnection queryConnection = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(query, queryConnection);

                queryConnection.Open();

                if (cmd.ExecuteNonQuery() == 0)
                    return false;

                queryConnection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static bool SetAccountExpansion(string accountName, string expansion)
        {
            if (accountName == "")
                return false;

            try
            {
                string query = "UPDATE account SET expansion =" + expansion + " WHERE username='" + accountName + "';";


                MySqlConnection queryConnection = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(query, queryConnection);

                queryConnection.Open();

                if (cmd.ExecuteNonQuery() == 0)
                    return false;

                queryConnection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static bool SetAccountGmLevel(string accountName, string gmLevel)
        {
            if (accountName == "")
                return false;

            try
            {
                string query = "REPLACE INTO account_access(`id`, `gmlevel`, `realmId`)" +
                "VALUES((SELECT `id` FROM account WHERE username ='" + accountName + "')," + gmLevel + ", -1);";

                MySqlConnection queryConnection = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(query, queryConnection);

                queryConnection.Open();

                if (cmd.ExecuteNonQuery() == 0)
                {
                    string queryTwo = "INSERT INTO account_access(`id`, `gmlevel`, `realmId`)" +
                    "VALUES((SELECT `id` FROM account WHERE username ='" + accountName + "')," + gmLevel + ", -1);";

                    MySqlCommand cmdTwo = new MySqlCommand(queryTwo, queryConnection);

                    if (cmdTwo.ExecuteNonQuery() == 0)
                        return false;
                }

                queryConnection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
