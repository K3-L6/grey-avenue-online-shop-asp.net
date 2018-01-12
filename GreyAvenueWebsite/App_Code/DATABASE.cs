using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace DATABASE
{
    public static class INSERT
    {
        static MySqlConnection con = new MySqlConnection();
        static MySqlCommand cmd = new MySqlCommand();
        static MySqlDataReader rdr;

        static void connectDatabbase()
        {
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = "localhost";
            connectionString.UserID = "root";
            connectionString.Password = "";
            connectionString.Database = "greyavenuedatabase";
            con.ConnectionString = connectionString.ToString();
            cmd.Connection = con;
        }

        public static void everything(string table)
        {
            connectDatabbase();
            try
            {
                con.Open();
                string query = "";
                switch (table)
                {
                    case "tbl_customers":
                        query = "insert into tbl_customers values ('" + INFO.registrationCustomer.id + "', '" + INFO.registrationCustomer.username + "', '" +INFO.registrationCustomer.password+ "', '" +INFO.registrationCustomer.lastname+ "', '" +INFO.registrationCustomer.firstname+ "', '" +INFO.registrationCustomer.contactnumber+ "', '" +INFO.registrationCustomer.email+ "')";
                        break;
                    case "tbl_cart":
                        query = "insert into tbl_cart (customerid, productname) values ('" + INFO.addToCart.customerid + "', '" + INFO.addToCart.productname + "')";
                        break;
                }
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                con.Close();
            }
        }

        public static void orders(string orderid, string customerid, string address, string type, List<string> productname, List<string> productsize)
        {
            connectDatabbase();
            try
            {
                con.Open();
                cmd.CommandText = "insert into tbl_orders values ('"+ orderid +"', '" + customerid + "', '" +address+ "', '" + type + "')";
                cmd.ExecuteNonQuery();

                for (int x = 0; x < productname.Count; x++)
                {
                    cmd.CommandText = "insert into tbl_orderitems values ('"+ orderid +"', '"+ productname[x] +"', '"+ productsize[x] +"')";
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
            catch
            {
                con.Close();
            }
        }
    }

    public static class DELETE
    {
        static MySqlConnection con = new MySqlConnection();
        static MySqlCommand cmd = new MySqlCommand();
        static MySqlDataReader rdr;

        static void connectDatabbase()
        {
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = "localhost";
            connectionString.UserID = "root";
            connectionString.Password = "";
            connectionString.Database = "greyavenuedatabase";
            con.ConnectionString = connectionString.ToString();
            cmd.Connection = con;
        }

        public static void deleteOne(string table, string identifier)
        {
            connectDatabbase();
            try
            {
                con.Open();
                cmd.CommandText = "delete from " + table + " where productname = '" + identifier + "' limit 1";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                con.Close();
            }
        }

        public static void deleteByID(string table, string identifier)
        {
            connectDatabbase();
            try
            {
                con.Open();
                cmd.CommandText = "delete from " + table + " where customerid = '" + identifier + "'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                con.Close();
            }
        }
    }

    
    public static class GETDATA
    {
        static MySqlConnection con = new MySqlConnection();
        static MySqlCommand cmd = new MySqlCommand();
        static MySqlDataReader rdr;

        static void connectDatabbase()
        {
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = "localhost";
            connectionString.UserID = "root";
            connectionString.Password = "";
            connectionString.Database = "greyavenuedatabase";
            con.ConnectionString = connectionString.ToString();
            cmd.Connection = con;
        }

        public static List<string> everything(string table, string field)
        {
            List<string> data = new List<string>();
            connectDatabbase();
            try
            {
                con.Open();
                cmd.CommandText = "select " + field + " from " + table;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        data.Add(rdr[0].ToString());
                    }
                }
                con.Close();
                rdr.Close();
            }
            catch {
                rdr.Close();
                con.Close();
            }
            return data;
        }

        public static List<string> whereFieldAll(string table, string field, string fieldname, string fieldidentifier)
        {
            List<string> data = new List<string>();
            try
            {
                connectDatabbase();
                con.Open();
                cmd.CommandText = "select " + field + " from " + table + " where " + fieldname + " = '" + fieldidentifier + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        data.Add(rdr[0].ToString());
                    }
                }
                con.Close();
                rdr.Close();
            }
            catch
            {
                rdr.Close();
                con.Close();
            }
            return data;
        }

        public static List<string> whereFieldAllAnd(string table, string field, string fieldname, string fieldidentifier, string fieldname2, string fielidentifier2)
        {
            List<string> data = new List<string>();
            try
            {
                connectDatabbase();
                con.Open();
                cmd.CommandText = "select " + field + " from " + table + " where " + fieldname + " = '" + fieldidentifier + "' and " + fieldname2 + " = '" + fielidentifier2 + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        data.Add(rdr[0].ToString());
                    }
                }
                con.Close();
                rdr.Close();
            }
            catch
            {
                rdr.Close();
                con.Close();
            }
            return data;
        }

        public static List<string> whereID(string table, string field, string idfield, string id)
        {
            List<string> data = new List<string>();
            connectDatabbase();
            con.Open();
            cmd.CommandText = "select " + field + " from " + table + " where " + idfield + " = '" + id + "'";
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    data.Add(rdr[0].ToString());
                }
            }
            con.Close();
            rdr.Close();
            return data;
        }

        public static string whereField(string table, string field, string fieldname, string fieldvalue)
        {
            string data = "";
            try
            {
                connectDatabbase();
                con.Open();
                cmd.CommandText = "select " + field + " from " + table + " where " + fieldname + " = '" + fieldvalue + "'";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    data = rdr[0].ToString();
                }

                con.Close();
            }
            catch
            {
                rdr.Close();
                con.Close();
            }
            return data;
        }
    }

    public static class UPDATE
    {
        static MySqlConnection con = new MySqlConnection();
        static MySqlCommand cmd = new MySqlCommand();
        static MySqlDataReader rdr;

        static void connectDatabbase()
        {
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = "localhost";
            connectionString.UserID = "root";
            connectionString.Password = "";
            connectionString.Database = "greyavenuedatabase";
            con.ConnectionString = connectionString.ToString();
            cmd.Connection = con;
        }

        public static void byfield(string table, string field, string id, string newValue)
        {
            connectDatabbase();
            try
            {
                con.Open();
                cmd.CommandText = "update " + table + " set " + field + " = '" + newValue + "' where id ='" + id + "'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                con.Close();
            }
        }

        public static void bymail(string table, string field, string email, string newValue)
        {
            connectDatabbase();
            try
            {
                con.Open();
                cmd.CommandText = "update " + table + " set " + field + " = '" + newValue + "' where email ='" + email + "'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                con.Close();
            }
        }

        public static void cartSize(string customerid, string value, string productname)
        {
            connectDatabbase();
            try
            {
                con.Open();
                cmd.CommandText = "update tbl_cart set size = '" + value + "' where customerid ='" + customerid + "' and productname = '" +productname+ "' and size is null limit 1 ";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                con.Close();
            }
        }
    }


}
