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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        bkEntities db = new bkEntities();
        public Window2()
        {
            InitializeComponent();
            dataGrid.ItemsSource = db.zakaz.ToList();

            //foreach (sotrudnic st in db.sotrudnic.ToList())
            //{
            //    cmd1.Items.Add(st.fio);
            //}

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //sotrudnic st = db.sotrudnic.FirstOrDefault(s => s.fio == cmd1.SelectedValue.ToString());
            //zakaz zakaz = new zakaz();
            //zakaz.title = tb1.Text;
            //zakaz.price = Convert.ToInt32(tb2.Text);
            //zakaz.id_sotrudnic = st.id_sotrudnic;
            //db.zakaz.Add(zakaz);
            //db.SaveChanges();
            //dataGrid.ItemsSource = db.zakaz.ToList();
            Window3 window3 = new Window3();
            window3.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            zakaz zakaz = (zakaz)dataGrid.SelectedItem;
            if (zakaz != null)
            {
                Window3 window3 = new Window3(zakaz);
                window3.Show();
                this.Close();
                //sotrudnic st = db.sotrudnic.FirstOrDefault(s => s.fio == cmd1.SelectedValue.ToString());
                //zakaz.title = tb1.Text;
                //zakaz.price = Convert.ToInt32(tb2.Text);
                //zakaz.id_sotrudnic = st.id_sotrudnic;
            }
            else
            {
                MessageBox.Show("");
            }
            //db.SaveChanges();
            //dataGrid.ItemsSource = db.zakaz.ToList();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            zakaz zakaz = (zakaz)dataGrid.SelectedItem;
            if (zakaz != null)
            {
                db.zakaz.Remove(zakaz);
                db.SaveChanges();
                dataGrid.ItemsSource = db.zakaz.ToList();
            }
            else
            {
                MessageBox.Show("");
            }
        }

        //private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    zakaz zakaz = (zakaz)dataGrid.SelectedItem;
        //    if (zakaz != null)
        //    {
        //        tb1.Text = zakaz.title;
        //        tb2.Text = zakaz.price?.ToString();
        //        cmd1.Text = zakaz.sotrudnic.fio;
        //    }
        //}
    }
}
