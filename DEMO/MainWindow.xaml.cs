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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DEMO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DBcon.db = new DEMOEntities();
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxtLogin.Text != "" && TxtPass.Password != "")
                {
                    using (var db = new DEMOEntities())
                    {
                        var authorization = db.Пользователь.FirstOrDefault(пользователь => пользователь.Логин == TxtLogin.Text && пользователь.Пароль == TxtPass.Password);
                        if (authorization != null)
                        {
                            if(authorization.ID_Роли == 1)// Клиент
                            {
                                int ID = authorization.ID;
                                Client client = new Client(ID);
                                client.Show();
                                this.Hide();
                            }else if(authorization.ID_Роли == 2)// Старый Админ
                            {
                                Admin admin = new Admin();
                                admin.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Неправильный логин или пароль");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля");
                }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

}

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }
    }
}
