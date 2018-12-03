using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using ZXing;
using ZXing.Common;

namespace KGOOS_MUI.PrintForm
{
    /// <summary>
    /// Interaction logic for SonPage.xaml
    /// </summary>
    public partial class SonPage : ModernWindow
    {
        public SonPage()
        {
            InitializeComponent();

            showPrintData();
        }

        public SonPage(string[] ArrayMainPage)
        {
            InitializeComponent();

            showPrintData();

        }

        public void showPrintData()
        {
            string[] ArrayMainPage;
            ArrayMainPage = new string[8];

            ArrayMainPage[0] = "阿斯顿撒大所大所多";
            ArrayMainPage[1] = "陈帅";
            ArrayMainPage[2] = "18488886666";
            ArrayMainPage[3] = "暗红色的看撒娇的情况我就和清洁温和几千块阿萨德撒大所多撒大所大所大多";
            ArrayMainPage[4] = "20180900000001";
            ArrayMainPage[5] = "k10008";
            ArrayMainPage[6] = "asdqweqwewq";
            ArrayMainPage[7] = "123456712324";

            string time = "";
            TB_Head.Text = ArrayMainPage[0];
            TB_Name.Text = ArrayMainPage[1];
            TB_Phone.Text = ArrayMainPage[2];
            TB_Adress.Text = ArrayMainPage[3];

            TB_Order.Text = ArrayMainPage[4];

            Bitmap bitmap = Generate2(ArrayMainPage[7], 100, 35);
            pictureBox.Image = bitmap;

            time = System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString();
            TB_Time.Text = time;
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
    }
}
