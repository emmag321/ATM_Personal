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
        public void getAccountBalance(){
            //Connect to DB
            OracleConnection conn = new OracleConnection(DBConnect.oradb);
            conn.Open();

            //Define SQL Query
            String strSQL = "SELECT FROM Account WHERE('" + this.car_Class + "','" + this.description + "'," + this.rate + ")";

            //Execute SQL Query
            OracleCommand cmd = new OracleCommand(strSQL, conn);
            cmd.ExecuteNonQuery();

            //Close DB Connection
            conn.Close();

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
