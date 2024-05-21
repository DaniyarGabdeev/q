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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        bkEntities db = new bkEntities();
        public Window1()
        {
            InitializeComponent();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            var sot = db.sotrudnic.FirstOrDefault(s => s.login == tb1.Text);
            if (sot == null)
            {
                MessageBox.Show("Неправильный логин");
                return;
            }
            if(passwordBox.Password != sot.password)
            {
                MessageBox.Show("Неправильный пароль");
                return;
            }
            if(sot.role == "Admin")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else if(sot.role == "Sotrudnik")
            {
                Window2 window2 = new Window2();
                window2.Show();
            }
            else
            {
                MessageBox.Show("11");
                return;
            }
            this.Close();

        }
    }
}
