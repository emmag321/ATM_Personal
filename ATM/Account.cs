using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Account
    {
        private int AccountID;
        private double balance;
        private char Type;
        private bool isBlocked;

        public Account(object getBalance)
        {
            this.AccountID = 0;
            this.balance = 0;
            this.Type = 'N';
            this.isBlocked = false;
        }

        public Account(int accountID, double balance, char type, bool isBlocked)
        {
            AccountID = accountID;
            this.balance = balance;
            Type = type;
            this.isBlocked = isBlocked;
        }

        //This method gets balance 
        public static DataSet getAccountBalance(DataSet ds){
            //create an OracleConnection object using the connection string defined in static class DBConnect
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL Query to retrieve the data
            String strSQL = "SELECT BALANCE FROM ACCOUNT";

            //Create an OracleCommand object and instantiate it
            OracleCommand cmd = new OracleCommand(strSQL, conn);

            //Create an oracleAdapter to hold the result of the executed OracleCommand
            OracleDataAdapter da = new OracleDataAdapter(cmd);

            //Clear Dataset
            ds.Clear();

            //Fill the DataSet DS with the query result
            da.Fill(ds, "ss");

            //close the DB Connection
            conn.Close();

            //Return the Dataset with the required data to the windows form which executed this method
            return ds;

        }


        //This method will get account id 
        public static DataSet getAccountID(DataSet ds)
        {
            //create an OracleConnection object using the connection string defined in static class DBConnect
            OracleConnection conn = new OracleConnection(DBConnect.oradb);

            //Define the SQL Query to retrieve the data
            String strSQL = "SELECT ACCOUNTID FROM ACCOUNT";

            //Create an OracleCommand object and instantiate it
            OracleCommand cmd = new OracleCommand(strSQL, conn);

            //Create an oracleAdapter to hold the result of the executed OracleCommand
            OracleDataAdapter da = new OracleDataAdapter(cmd);

            //Clear Dataset
            ds.Clear();

            //Fill the DataSet DS with the query result
            da.Fill(ds, "ss");

            //close the DB Connection
            conn.Close();

            //Return the Dataset with the required data to the windows form which executed this method
            return ds;

        }

        public int getAccountID()
        {
            return AccountID;
        }

        public double getBalance()
        {
            return balance;
        }

        public char getType()
        {
            return Type;
        }
        public bool returnBlockState()
        {
            return isBlocked;
        }

    }
}
