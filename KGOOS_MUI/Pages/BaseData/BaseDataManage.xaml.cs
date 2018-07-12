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

namespace KGOOS_MUI.Pages.BaseData
{
    /// <summary>
    /// Interaction logic for BaseDataManage.xaml
    /// </summary>
    public partial class BaseDataManage : UserControl
    {
        public BaseDataManage()
        {
            InitializeComponent();
        }

        private void TBFreight_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = System.Windows.Window.GetWindow(this) as MainWindow;
            mw.ContentSource = new Uri("/Pages/BaseData/FreightCount.xaml", UriKind.RelativeOrAbsolute);
        }

        private void TBStaff_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = System.Windows.Window.GetWindow(this) as MainWindow;
            mw.ContentSource = new Uri("/Pages/BaseData/Straff.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Customs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = System.Windows.Window.GetWindow(this) as MainWindow;
            mw.ContentSource = new Uri("/Pages/BaseData/Shelf.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
