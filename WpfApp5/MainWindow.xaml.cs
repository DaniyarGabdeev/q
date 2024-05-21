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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bkEntities db = new bkEntities();
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = db.sotrudnic.ToList();

            var seart = db.sotrudnic.Select(s=>s.role).Distinct().ToList();
            seart.Insert(0, "All");
            cmd2.ItemsSource = seart;
            cmd2.SelectedIndex = 0;

        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            sotrudnic st = new sotrudnic();
            st.fio = tb1.Text;
            st.login = tb2.Text;
            st.password = tb3.Text;
            st.role = cmd1.Text;
            db.sotrudnic.Add(st);
            db.SaveChanges();
            dataGrid.ItemsSource = db.sotrudnic.ToList();
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            sotrudnic st = (sotrudnic)dataGrid.SelectedItem;
            if(st != null)
            {
                st.fio = tb1.Text;
                st.login = tb2.Text;
                st.password = tb3.Text;
                st.role = cmd1.Text;
                
            }
            else
            {
                MessageBox.Show("Выберите строку для редактирования");
            }
            db.SaveChanges();
            dataGrid.ItemsSource = db.sotrudnic.ToList();

        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            sotrudnic st = (sotrudnic)dataGrid.SelectedItem;
            if (st != null)
            {
                db.sotrudnic.Remove(st);
                db.SaveChanges();
                dataGrid.ItemsSource = db.sotrudnic.ToList();
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления");
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sotrudnic st = (sotrudnic)dataGrid.SelectedItem;
            if (st != null)
            {
                tb1.Text = st.fio;
                tb2.Text = st.login;
                tb3.Text = st.password;
                cmd1.Text = st.role;
            }
        }

        private void tb4_TextChanged(object sender, TextChangedEventArgs e)
        {
            string st = tb4.Text.ToLower();

            var fill = db.sotrudnic.Where(s=>s.fio.ToLower().Contains(st)).ToList();
            dataGrid.ItemsSource = fill;
        }

        private void cmd2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string st = cmd2.SelectedItem.ToString();
            if(st == "All")
            {
                dataGrid.ItemsSource = db.sotrudnic.ToList();
            }
            else
            {
                var filt = db.sotrudnic.Where(s => s.role == st).ToList();
                dataGrid.ItemsSource = filt;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
            {
                pd.PrintVisual(dataGrid, "Project");
            }
        }
    }
}
