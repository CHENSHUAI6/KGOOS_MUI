using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace KGOOS_MUI
{
    /// <summary>
    /// Interaction logic for ModernWindow1.xaml
    /// </summary>
    public partial class ModernWindow1 : ModernWindow
    {
        public ModernWindow1()
        {
            InitializeComponent();
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {
            PrintForm.PrintWeight pw = new PrintForm.PrintWeight();
            //pw.ContentSource = @"/Pages/Print/Test.xaml";
            //pw.ShowInTaskbar = false;
            
            pw.Show();
            //pw.Visibility = Visibility.Hidden;
            //Thread.Sleep(90); 
            pw.Close();
        }
    }
}
