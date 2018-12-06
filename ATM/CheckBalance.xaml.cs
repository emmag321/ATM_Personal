using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ATM
{
    /// <summary>
    /// Interaction logic for CheckBalance.xaml
    /// </summary>
    public partial class CheckBalance : Window
    {
        
        //Account myAcc = new Account();

        
        
        public CheckBalance()
        {
            //this would be taken from the database
            //Account myAcc = new Account(1001, 12000, 'C', false);

            InitializeComponent();
           //txtBal.Text = myAcc.getBalance().ToString();
        }

        

        private void txtBal_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            //prints receipt
            this.Close();
            System.Windows.Application.Current.Shutdown();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var menuForm = new MainMenu();
            menuForm.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void cboBalance_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();
            ds = Account.getAccountBalance(ds);

            //load combo with Customer and Customer Name for all customers
            for (int i = 0; i < ds.Tables["ss"].Rows.Count; i++)
                cboBalance.Items.Add(ds.Tables[0].Rows[i][0]);
        }
    }
}
