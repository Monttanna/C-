using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Appname // Here you have to put the application name.
{
    class common {
        SqlConnection con = new SqlConnection("Data Source=PC\\SQLEXPRESS;Initial Catalog=databasename;Trusted_Connection=True;");
        private SqlCommandBuilder cmdb;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;
        public SqlCommand cmd;

        public bool connect(){//Connect to Database
            try {
                con.Open();
                //msn = connection succesfuly
                return true;
            } catch (Exception e) {
                //msn = connection fail.
                return false;
            } finally {
               con.Close();
            }
        }

        public void Query(string sql, string table) {
            ds.Tables.Clear();
            da = new SqlDataAdapter(sql, con);
            cmdb = new SqlCommandBuilder(da);
            da.Fill(ds, table);
            con.Close();
            /*  Show data in forms datagridview
             * con.Query("SELECT * FROM items", "tblitems");
             * datagridview.DataSource = con.ds.Table["tblitems"];
             */
        }

        public bool Insert(string sql) {
            con.Open();
            cmd = new SqlCommand(sql, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0) {
                return true;
            } else {
                return false;
            }
            /*inser data from frm control
             * strin sql = "INSERT INTO items VALUES()";
             * if(con.Insert(sql))
             * { msn =datos agregados; refrescar datagrid con nueva consulta } else {msn = no se agrego };
             */
        }

        public bool Delete(string table, string condition) {
            con.Open();
            string sql = "DELETE FROM " + table + " WHERE " + condition;
            cmd = new SqlCommand(sql, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0) {
                return true;
            } else {
                return false;
            }
            /*
             * if(con.Delete("items", "itemID = 23")){ record deleted; } else { error }
             */
        }

        /*
         * DataGridView dgv = dgvRecord.Rows[e.RwoIndex];
         * txtname.text = dgv.Cell[0].value.toString();
         * txtpart.text = dgv.Cell[1].value.toString();
         * txtcost.text = dgv.Cell[2].value.toString();
         */

        public bool Update(string table, string column, string condition) {
            con.Open();
            string sql = "UPDATE " + table + " SET " + column + " WHERE " + condition;
            cmd = new SqlCommand(sql, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0) {
                return true;
            } else {
                return false;
            }

            /*
             * string colums = "";
             * string table = "";
             * string condition = "";
             * if(con.Update(table, columns,condition) { good } else { fail }
             */
        }

    }
}
