using KGOOS_MUI.Pages.Scan;
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

namespace KGOOS_MUI.Pages
{
    /// <summary>
    /// Interaction logic for TranManage.xaml
    /// </summary>
    public partial class TranManage : UserControl
    {
        public TranManage()
        {
            InitializeComponent();
            BitmapImage bi = new BitmapImage();
            // BitmapImage.UriSource must be in a BeginInit/EndInit block.  
            bi.BeginInit();
            bi.UriSource = new Uri(@"C:\1.jpg", UriKind.RelativeOrAbsolute);
            bi.EndInit();
            //image1.Source = bi;  
        }

        private void ConTran_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Weigh tw = new Weigh();
            MainWindow mw = System.Windows.Window.GetWindow(this) as MainWindow;
            mw.ContentSource = new Uri("/Pages/Tran/ConTran.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Arrive_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Weigh tw = new Weigh();
            MainWindow mw = System.Windows.Window.GetWindow(this) as MainWindow;
            mw.ContentSource = new Uri("/Pages/Tran/Arrive.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Addresser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Weigh tw = new Weigh();
            MainWindow mw = System.Windows.Window.GetWindow(this) as MainWindow;
            mw.ContentSource = new Uri("/Pages/Tran/Addresser.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Customs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Weigh tw = new Weigh();
            MainWindow mw = System.Windows.Window.GetWindow(this) as MainWindow;
            mw.ContentSource = new Uri("/Pages/Tran/Customs.xaml", UriKind.RelativeOrAbsolute);
        }       
    }
}
