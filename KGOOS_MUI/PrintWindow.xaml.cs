using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
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
using ZXing;
using ZXing.Common;

namespace KGOOS_MUI
{
    /// <summary>
    /// Interaction logic for PrintWindow.xaml
    /// </summary>
    public partial class PrintWindow : ModernWindow
    {
        public PrintWindow()
        {
            InitializeComponent();
            showPrintData();
        }

        [DllImport("winspool.drv")]
        public static extern bool SetDefaultPrinter(String Name);

        private void print_Click(object sender, RoutedEventArgs e)
        {
            print();
        }

        public void print()
        {
            btn_print.IsEnabled = false;
            PrintDocument print = new PrintDocument();
            string sDefault = print.PrinterSettings.PrinterName;
            SetDefaultPrinter(sDefault);
            //foreach (string sPrint in PrinterSettings.InstalledPrinters)//获取所有打印机名称
            //{
            //    if (sPrint.Equals(print))
            //    {
            //        SetDefaultPrinter(sPrint); //设置默认打印机，可以把所有数据做成下拉框然后选取，此处设计有毒，仅供参考
            //    }
            //}

            PrintDialog dialog = new PrintDialog();
            dialog.PrintVisual(printGrid, "Print Test");
            //if (dialog.ShowDialog() == true)
            //{
            //    dialog.PrintVisual(printGrid, "Print Test");
            //}
        }

        public void showPrintData()
        {
            Bitmap bitmap = Generate2("1234567890", 200, 30);
            pictureBox.Image = bitmap;
        }

        public static Bitmap Generate2(string text, int width, int height)
        {
            BarcodeWriter writer = new BarcodeWriter();
            //使用ITF 格式，不能被现在常用的支付宝、微信扫出来
            //如果想生成可识别的可以使用 CODE_128 格式
            //writer.Format = BarcodeFormat.ITF;
            writer.Format = BarcodeFormat.CODE_128;
            EncodingOptions options = new EncodingOptions()
            {
                Width = width,
                Height = height,
                PureBarcode = true,
                Margin = 2
            };
            writer.Options = options;
            Bitmap map = writer.Write(text);
            return map;
        }

        private void ModernWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void ModernWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            print();
        }
    }
}
