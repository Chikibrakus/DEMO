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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            FillCombo();        
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Пользователь пользователь = new Пользователь();
                пользователь.Логин = TxtLogin.Text;
                пользователь.Пароль = TxtPass.Password;
                var post = DBcon.db.Роль.FirstOrDefault(роль => роль.Наименование == ComboPost.SelectedItem.ToString());
                пользователь.ID_Роли = post.ID_Роли;
                DBcon.db.Пользователь.Add(пользователь);
                DBcon.db.SaveChanges();
                MessageBox.Show("Пользователь добавлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillCombo()
        {
            //var PostToList = DBcon.db.Роль.ToList();
            //ComboPost.DisplayMemberPath = "Наименование";
            //ComboPost.ItemsSource = PostToList;
            var roles = DBcon.db.Роль.ToList();
            foreach (var role in roles)
            {
                ComboPost.Items.Add(role.Наименование);
            }
        }
    }
}
