   M S B A M L   `   `   `  ���� ^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms D @KGOOS_MUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:KGOOS_MUI.ControlKGOOS_MUI.Control "   KGOOS_MUI.Pages.Scan.Inquire   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  +tbnewclr-namespace:KGOOS_MUI.Control  .���    ContentRoot#��[    � RowDefinitions  �� $��40 ��� $��50 ��� $	��180 ��� $��50 ��� $��* � � ColumnDefinitions �� $��* ��� $	��200 �.+��� $��0��$��Bottom=�
�������
�������$��1q��� $��5��$��Bottom=�
�������
�������$��1q��� $��1��$��5��$
��Left=�
�������
�������$��1q��� $��1��$��5��$��Right=�
�������
�������$��1q��� $��0��$��到件扫描查询��$��2,2,2,2q�$��25(�$��宋体)�$
��Left=�$	��Top=�$
��Bold"�� $��1��$��5��  �� $��30 ��� $��* �.+��� $��0��$��未查询到的单号��$��2,2,2,2q�$��18(�$��宋体)�$��Center=�$��Center=�
���  ���� -   $
��NoID��$��1�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . " �� VerticalScrollBarVisibility$ Visible=�$��Stretch=�$	��190��$�� ��$��2,2,2,2q�$��18(�$��宋体)�
���  �� �� 
IsReadOnly . � $��1�� �� $��75 ��� $��70 ��� $��* �.+��� -   $��	BtnSelect��$��0��$��45��$��查 询��$��18(�$��1,1,1,1q�$��7,2,2,2q� J� RenderTransformOrigin$ 	0.503,0.5&��� -   $��	BtnOutput��$��1��$��45��$��导 出��$��18(�$��1,1,1,1q�$��2,2,2,2q��� $��1��$��Bottom=�
�������
�������$��1q�� $��2�� �� $	��200 ��� $	��230 ��� $��* �.+�� $��0��  �� $��35 ��� $��* �.+��� -   $
��CBID��$��0��$��按单号查询��$��5,2,2,2q�$��Center=�$��宋体)�$��18(�$
��Left=��� -   $��BtnClear��$��0��$��30��$��清 空��$��16(�$��1,1,1,1q�$��2,2,20,2q�$��Right=�$��Center=��� -   $
��TBID��$
 Wrap=� . $ Visible=�$	��130��$	��190��$��1��$�� ��$��5,5,5,5q�$��12(�$��宋体)�� $��1��  �� $��25 ��� $��* ��� $��* ��� $��10 �.+��� $��0��$	��Top=�
�������
�������$��1q��� $��2��$��Bottom=�
�������
�������$��1q��� $��0��$��3��$
��Left=�
�������
�������$��1q��� $��0��$��3��$��Right=�
�������
�������$��1q��� $��0��$	��200��$(��"扫描日期范围(31天以内)：��$��7,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� $��1��$��55��$��开始��$��20,5,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=�7   1System.Windows.Forms.Integration.WindowsFormsHost  $	��150��$��1��$��60,2,2,2q�$
��Left=�$��Center=�   FontSize$ 12Q�   
FontFamily$ 宋体)�	   Child.	 )  #System.Windows.Forms.DateTimePicker  -   TBStartTime��"  System.Windows.Forms.Control
   Width$	
 150��   Height$ 20��   Format$ Custom=�   CustomFormat$ yyyy-MM-dd: HH:mm:ss���� $��2��$��55��$��结束��$��20,5,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=�  $	��150��$��2��$��60,2,2,2q�$
��Left=�$��Center=�$ 12Q�$ 宋体)�.	   -   	TBEndTime��$	
 150��$ 20��$ Custom=�$ yyyy-MM-dd: HH:mm:ss��� $��2�� �� $	��260 ��� $��* �  �� $��* ��� $��* ��� $��* �.+��� $��0��$��0��$��扫描网点��$��7,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� -	   $��TBPlant��$	��160��$��0��$��0��$�� ��$��85,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� $��1��$��0��$��	旺旺名��$��7,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=�+  %KGOOS_MUI.Control.AutoCompleteTextBox  -
     Name$ TBName��$��30��$	��160��$��1��$��0��   Text$  ��$��85,2,0,0q�   FontSize$ 18Q�   
FontFamily$ 宋体)�$
��Left=�$��Center=��� $��2��$��0��$��返回记录��$��7,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� -   $��TBReturnNum��$	��160��$��2��$��0��$	��300��$��85,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� $��0��$��1��$��	扫描人��$��2,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� -   $��TBScan��$	��160��$��0��$��1��$�� ��$��85,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� $��1��$��1��$��物品类别��$��2,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� -   $��TBType��$	��160��$��1��$��1��$�� ��$��85,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� $��2��$��1��$��过滤重复��$��0,0,0,4q�$��Center=�$��宋体)�$��18(�$
��Left=� d� 	IsChecked$
 TrueY��� $��2��$��Bottom=�
�������
�������$��1q�� $��3��.+��� $��网格背景颜色：��$��7,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=�F� 
���   ����	#FF9FF59F$��1��$��87,10,10,10q�$��Center=�$
��Left=�����  �� Rect$ 	0,0,15,15��� $��	已发件��$��	105,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=�F� 
���   �
��� ���$��1��$��155,10,10,10q�$��Center=�$
��Left=����� $ 	0,0,15,15��� $��有体积重量��$��	175,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� $��网格字体颜色：��$��	255,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=�F� 
���   �
���  ��$��1��$��340,10,10,10q�$��Center=�$
��Left=����� $ 	0,0,15,15��� $��体积重量��$��	360,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� $��单号扫描确认��$��	420,2,2,2q�$��15(�
���  ��$��宋体)�$
��Left=�$��Center=��� -   $��TBtranId��$	��260��$��1��$�� ��$��	520,6,6,6q�$��25(�$��宋体)�$
��Left=�$��36��$��Center=��� $��确认件数：��$��	800,2,2,2q�$��15(�
���  ��$��宋体)�$
��Left=�$��Center=��� $��0��$��	870,2,2,2q�$��25(�
���  ��$��宋体)�$
��Left=�$��Center=�$
��Bold"��� $��4��$
��Auto=�$
��Auto=�.���� $	��200��.+�&   System.Windows.Controls.DataGrid  -   $	��DG1��   AutoGenerateColumns .  $��18(�$��宋体)�   
IsReadOnly . ����    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   HeaderTemplate �� .R��� $��	已核对��   CellTemplate �� .R��� $��Center=�$��Center=� �� *
Checking+0  *System.Windows.Controls.DataGridTextColumn     Header$ 运单编号��  contentCenterStyle1	  +System.Windows.Controls.DataGridBoundColumn 	  ElementStyle# [  	  Binding �� *Weight_ConID+  $ 集运编号��# [  �� *Weight_ConTranId+  $ 集运状态��# [  �� *Weight_Type+  $ 	上一站��# [  �� *Weight_Last+  $ 	扫描人��# [  �� *Weight_WorkderId+  $ 扫描时间��# [  �� *Weight_Time+   �� .R��� $��重量�� �� .R��� $��Center=�$��Center=����� *Weight_Helf+���� *WeightColor+  $ 件数��# [  �� *
Weight_Num+  $ 存货货架��# [  �� *Weight_Shelf+  $ 备注��# [  �� *Weight_Note+  $ 会员编号��# [  �� *Weight_UserId+  $ 	旺旺名��# [  �� *Weight_UserName+  $ 秤重��# [  �� *Weight_Weitgh+  $ 	体积重��# [  �� *Weight_Size+  $ 包装类型��# [  �� *Weight_Pack+  $ 所在仓库��# [  �� *Weight_Region+  $ 内部备注��# [  �� *Weight_NoteStaff+  $ 超长��# [  �� *Weight_OverLong+  $ 超重��# [  �� *Weight_OverHelf+