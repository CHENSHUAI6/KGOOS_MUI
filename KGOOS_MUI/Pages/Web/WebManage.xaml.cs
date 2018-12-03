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

namespace KGOOS_MUI.Pages.Web
{
    /// <summary>
    /// Interaction logic for WenManage.xaml
    /// </summary>
    public partial class WenManage : UserControl
    {
        public WenManage()
        {
            InitializeComponent();
        }

        private void Entering_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Weigh tw = new Weigh();
            MainWindow mw = System.Windows.Window.GetWindow(this) as MainWindow;
            mw.ContentSource = new Uri("/Pages/Web/Entering.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Select_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Weigh tw = new Weigh();
            MainWindow mw = System.Windows.Window.GetWindow(this) as MainWindow;
            mw.ContentSource = new Uri("/Pages/Web/Select.xaml", UriKind.RelativeOrAbsolute);
        }

        private void NewSPut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = System.Windows.Window.GetWindow(this) as MainWindow;
            mw.ContentSource = new Uri("/Pages/Web/NewSPut.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
