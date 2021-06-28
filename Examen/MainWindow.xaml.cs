using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Examen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseEntities db;
        public MainWindow()
        {
            InitializeComponent();
            db = new DatabaseEntities();
            string summa = "SELECT Money FROM CashBox WHERE Id = 1";
            int mon = 0;
            using (SqlConnection thisConnection = new SqlConnection("data source=(LocalDB)\\MSSQLLocalDB;attachdbfilename=|DataDirectory|\\Database.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;"))
            {
                using (SqlCommand cmdCount = new SqlCommand(summa, thisConnection))
                {
                    thisConnection.Open();
                    cashbox.Text = Convert.ToString(mon);
                    thisConnection.Close();
                }
            }
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            int x = Convert.ToInt32(sum.Text);
            int y = Convert.ToInt32(cashbox.Text);
            int z = x + y;
            cashbox.Text = z.ToString();
        }
    }
}
