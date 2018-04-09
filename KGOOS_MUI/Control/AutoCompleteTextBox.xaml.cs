using KGOOS_MUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KGOOS_MUI.Control
{
    /// <summary>
    /// AutoCompleteTextBox.xaml 的交互逻辑
    /// </summary>
    public partial class AutoCompleteTextBox : Canvas
    {
        #region 成员变量

        private VisualCollection controls;
        private TextBox textBox;
        private ComboBox comboBox;
        private ObservableCollection<AutoCompleteEntry> autoCompletionList;
        private Timer keypressTimer;
        private delegate void TextChangedCallback();
        private bool insertText;
        private int delayTime;
        private int searchThreshold;
        private int n;
        private int nSize = 10;

        #endregion 成员变量

        #region 构造函数

        public AutoCompleteTextBox()
        {
            controls = new VisualCollection(this);
            InitializeComponent();

            autoCompletionList = new ObservableCollection<AutoCompleteEntry>();
            searchThreshold = 0;        // default threshold to 2 char
            delayTime = 100;

            // set up the key press timer
            keypressTimer = new System.Timers.Timer();
            keypressTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);

            // set up the text box and the combo box
            comboBox = new ComboBox();
            comboBox.IsSynchronizedWithCurrentItem = true;
            comboBox.IsTabStop = false;
            Panel.SetZIndex(comboBox, -1);
            comboBox.SelectionChanged += new SelectionChangedEventHandler(comboBox_SelectionChanged);

            textBox = new TextBox();
            textBox.TextChanged += new TextChangedEventHandler(textBox_TextChanged);
            textBox.GotFocus += new RoutedEventHandler(textBox_GotFocus);
            textBox.KeyUp += new KeyEventHandler(textBox_KeyUp);
            textBox.KeyDown += new KeyEventHandler(textBox_KeyDown);
            textBox.VerticalContentAlignment = VerticalAlignment.Center;

            controls.Add(comboBox);
            controls.Add(textBox);
        }

        #endregion 构造函数

        #region 成员方法

        public string Text
        {
            get { return textBox.Text; }
            set
            {
                insertText = true;
                textBox.Text = value;
            }
        }
        public object Tag
        {
            get { return textBox.Tag; }
            set
            {
                insertText = true;
                textBox.Tag = value;
            }
        }

        public double FontSize
        {
            get { return textBox.FontSize; }
            set
            {
                insertText = true;
                textBox.FontSize = value;
                comboBox.FontSize = value;
            }
        }

        public FontFamily FontFamily
        {
            get { return textBox.FontFamily; }
            set
            {
                insertText = true;
                textBox.FontFamily = value;
                comboBox.FontFamily = value;
            }
        }

        public new void Focus()
        {
            textBox.Focus();
        }

        public int DelayTime
        {
            get { return delayTime; }
            set { delayTime = value; }
        }

        public int Threshold
        {
            get { return searchThreshold; }
            set { searchThreshold = value; }
        }

        /// <summary>
        /// 添加Item
        /// </summary>
        /// <param name="entry"></param>
        public void AddItem(AutoCompleteEntry entry)
        {
            autoCompletionList.Add(entry);
        }

        /// <summary>
        /// 添加源-人工增加部分
        /// </summary>
        public void AddItemSource(List<AutoCompleteEntry> tlist)
        {
            for (int i = 0; i < tlist.Count; i++)
            {
                AddItem(tlist[i]);
            }

        }

        /// <summary>
        /// 清空Item
        /// </summary>
        /// <param name="entry"></param>
        public void ClearItem()
        {
            autoCompletionList.Clear();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (null != comboBox.SelectedItem)
            {
                insertText = true;
                ComboBoxItem cbItem = (ComboBoxItem)comboBox.SelectedItem;
                string Id_Name = cbItem.Content.ToString();
                string[] s = Id_Name.Split(new char[] { ' ' });
                textBox.Text = s[s.Length-1];
                textBox.Tag = s[0];
            }
        }

        private void TextChanged()
        {
            n = 0;
            try
            {
                comboBox.Items.Clear();
                if (textBox.Text.Length >= searchThreshold)
                {
                    foreach (AutoCompleteEntry entry in autoCompletionList)
                    {
                        foreach (string word in entry.KeywordStrings)
                        {
                            //去除大小写
                            string workUP = "";
                            string textUP = "";
                            workUP = word.ToUpper();
                            textUP = textBox.Text.ToUpper();
                            //n 为显示的个数                           
                            //if (word.Contains(textBox.Text) && n < nSize)
                            if (workUP.Contains(textUP) && n < nSize)
                            {
                                n++;
                                ComboBoxItem cbItem = new ComboBoxItem();
                                cbItem.Content = entry.ToString();
                                comboBox.Items.Add(cbItem);
                                break;
                            }
                            //if (word.StartsWith(textBox.Text, StringComparison.CurrentCultureIgnoreCase))
                            //{
                            //    ComboBoxItem cbItem = new ComboBoxItem();
                            //    cbItem.Content = entry.ToString();
                            //    comboBox.Items.Add(cbItem);
                            //    break;
                            //}
                        }
                    }
                    comboBox.IsDropDownOpen = comboBox.HasItems;
                }
                else
                {
                    comboBox.IsDropDownOpen = false;
                }
            }
            catch { }
        }

        private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            keypressTimer.Stop();
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                new TextChangedCallback(this.TextChanged));
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // text was not typed, do nothing and consume the flag
            if (insertText == true) insertText = false;

            // if the delay time is set, delay handling of text changed
            else
            {
                if (delayTime > 0)
                {
                    keypressTimer.Interval = delayTime;
                    keypressTimer.Start();
                }
                else TextChanged();
            }
        }

        //获得焦点时
        public void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // text was not typed, do nothing and consume the flag
            if (insertText == true) insertText = false;

            // if the delay time is set, delay handling of text changed
            else
            {
                if (delayTime > 0)
                {
                    keypressTimer.Interval = delayTime;
                    keypressTimer.Start();
                }
                else TextChanged();
            }
        }

        public void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            ///输入不完整的会员名后回车默认选取弹出的第一个会员名作为结果

            if (e.Key == Key.Enter)
            {
                if (comboBox.SelectedIndex == -1)
                {
                    try
                    {
                        comboBox.SelectedIndex = 0;
                        ComboBoxItem cbItem = (ComboBoxItem)comboBox.SelectedItem;
                        string Id_Name = cbItem.Content.ToString();
                        string[] s = Id_Name.Split(new char[] { ' ' });
                        textBox.Text = s[s.Length - 1];
                        textBox.Tag = s[0];
                    }catch(Exception e1)
                    {

                    }
                    
                }
            }

            if (textBox.IsInputMethodEnabled == true)
            {
                comboBox.IsDropDownOpen = false;
            }
        }

        /// <summary>
        /// 按向下按键时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down && comboBox.IsDropDownOpen == true)
            {
                comboBox.Focus();
            }
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            textBox.Arrange(new Rect(arrangeSize));
            comboBox.Arrange(new Rect(arrangeSize));
            return base.ArrangeOverride(arrangeSize);
        }

        protected override Visual GetVisualChild(int index)
        {
            return controls[index];
        }

        protected override int VisualChildrenCount
        {
            get { return controls.Count; }
        }

        #endregion 成员方法
    }
}
