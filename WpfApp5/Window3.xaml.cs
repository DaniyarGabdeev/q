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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        int appID = -1;
        bkEntities db = new bkEntities();
        public Window3()
        {
            InitializeComponent();
            foreach(sotrudnic st in db.sotrudnic.ToList())
            {
                cmd1.Items.Add(st.fio);
            }
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            sotrudnic st = db.sotrudnic.FirstOrDefault(s => s.fio == cmd1.SelectedValue.ToString());
            if (appID == -1)
            {
                zakaz zakaz = new zakaz();
                zakaz.title = tb1.Text;
                zakaz.price = Convert.ToInt32(tb2.Text);
                zakaz.id_sotrudnic = st.id_sotrudnic;
                db.zakaz.Add(zakaz);
            }
            else
            {
                zakaz zakaz = db.zakaz.First(z => z.id_zakaz == appID);
                zakaz.title = tb1.Text;
                zakaz.price = Convert.ToInt32(tb2.Text);
                zakaz.id_sotrudnic = st.id_sotrudnic;
            }
            db.SaveChanges();
            Window2 window2 = new Window2();
            window2.Show();
            this.Close();

        }
        public Window3(zakaz app) : this()
        {
            qwerty(app);
        }
        private void qwerty(zakaz app)
        {
            if (app == null) return;
            tb1.SelectedText = app.title;
            tb2.SelectedText = app.price?.ToString();
            cmd1.SelectedItem = app.sotrudnic.fio;
            appID = app.id_zakaz;
        }
    }
}
