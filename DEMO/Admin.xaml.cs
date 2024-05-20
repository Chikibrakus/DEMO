using System;
using System.Collections.Generic;
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

namespace DEMO
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {

        public Admin()
        {
            InitializeComponent();
            UpdateTable();
        }

        public void UpdateTable()
        {
            try
            {
                using (var db = new DEMOEntities())
                {                    
                    TableOrders.ItemsSource = db.Заявка.Include("Пользователь").ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }       
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
                var addorder = new Заявка
                {
                    Дата = DateTime.Now.ToString(),
                    Оборудование = TxtObor.Text,
                    ID_Пользователя = 1
                };
                DBcon.db.Заявка.Add(addorder);
                DBcon.db.SaveChanges();
                UpdateTable();
        }
    }
}
