   M S B A M L   `   `   `  ���� ^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms D @KGOOS_MUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:KGOOS_MUI.ControlKGOOS_MUI.Control     KGOOS_MUI.Pages.Scan.Weigh   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  YwfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration  Iwf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms  +tbnewclr-namespace:KGOOS_MUI.Control  .���    ContentRoot#��[    � RowDefinitions  �� $��40 ��� $��60 ��� $	��220 ��� $��* �.+��� $��0��$��到件称重扫描��$��2,2,2,2q�$��32(�$��宋体)�$
��Left=�$	��Top=�$
��Bold"��� $��0��$��Bottom=�
�������
�������$��1q��� $��3��$��Bottom=�
�������
�������$��1q��� $��1��$��5��$
��Left=�
�������
�������$��1q��� $��1��$��5��$��Right=�
�������
�������$��1q�� $��1�� � ColumnDefinitions �� $��80 ��� $��70 ��� $��70 ��� $��70 ��� $��70 ��� $	��140 ��� $��70 ��� $��* �.+��� $��0��$��40��$��查 询��$��18(�$��1,1,1,1q�$��
12,10,2,10q�$��Bottom=��� $��1��$��40��$��新 建��$��18(�$��1,1,1,1q�$��	2,10,2,10q��� -   $��	BTNDelete��$��2��$��40��$��删 除��$��18(�$��1,1,1,1q�$��	2,10,2,10q��� -   $��BTNSave��$��3��$��40��$��保 存��$��18(�$��1,1,1,1q�$��	2,10,2,10q��� $��4��$��40��$��取 消��$��18(�$��1,1,1,1q�$��	2,10,2,10q��� -   $��BTNAutoShelf��$��5��$��40��$��自动分配货架��$��18(�$��1,1,1,1q�$��	2,10,2,10q��� -   $��	BTNUpdate��$��6��$��40��$��刷 新��$��18(�$��1,1,1,1q�$��	2,10,2,10q��� $��1��$��Bottom=�
�������
�������$��1q�� $��2�� �� $	��700 ��� $��* �.+�� $��0�� �� $	��20* ��� $��6* ��� $
��254* �  �� $��40 ��� $��60 ��� $��40 ��� $��40 ��� $��40 �.+��� $��80��$��0��$��扫描时间��$��7,6,0,6q�$��18(�$��宋体)�$
��Left=�$��Center=�$��3��7   1System.Windows.Forms.Integration.WindowsFormsHost  $	��220��$��0��$��88,2,2,2q�$
��Left=�$��Center=�   FontSize$ 18Q�   
FontFamily$ 宋体)�   Child. )  #System.Windows.Forms.DateTimePicker  -   
TBsacnTime��"  System.Windows.Forms.Control   Width$	 220��   Height$ 30��   Format$ Custom=�   CustomFormat$ yyyy-MM-dd: HH:mm:ss��	   Enabled	 .  �� $��0��$��件 数��$��	290,6,0,6q�$��18(�$��宋体)�$
��Left=�$��Center=�$��2���� -   $��TBNumber��$��40��$��0��$��1��$��	350,4,0,4q�$��18(�$��宋体)�$
��Left=�$��Center=�$��2���� $��0��$��包装类型��$��	400,6,0,6q�$��18(�$��宋体)�$
��Left=�$��Center=�$��2���� -   $��CBType��$	��100��$��0��
 �� Text$
 1��$��	475,4,0,4q�$��18(�$��宋体)�$
��Left=�$��Center=�$��2���� $��80��$��1��$��运单编号��$��	7,19,0,18q�$��18(�$��宋体)�$
��Left=�$��Center=�$��3���� -   $��TBtranId��$	��325��$��1��$�� ��$��20,8,0,7q�$��30(�$��宋体)�$
��Left=�$��40��$��Center=�$��2��	� -	   $��RBimportWeigh��$��1��$��输入重量��$��	358,7,0,0q�$��18(�$	��Top=�$��宋体)�$��2��	� -
   $��RBdefaultWeig��$��1��$��默认重量��$��	358,0,0,7q�$��18(�$��Bottom=�$��宋体)� d� 	IsChecked$
 TrueY�$��2���� -   $��TBweigh��$	��120��$��1��$�� ��$��	463,8,0,7q�$��30(�$��宋体)�$
��Left=�$��40��$��Center=�$��2���� $��80��$��2��$��	旺旺名��$��7,6,0,6q�$��18(�$��宋体)�$
��Left=�$��Center=�$��3��+  %KGOOS_MUI.Control.AutoCompleteTextBox  -     Name$ TBName��+  %KGOOS_MUI.Control.AutoCompleteTextBox   KeyDown$ TBName_KeyDown��$��30��$	��150��$��2��   Text$  ��$��18,2,0,0q�   FontSize$ 18Q�   
FontFamily$ 宋体)�$
��Left=�$��Center=�$��2���� $��2��$��存放货架��$��	178,6,0,6q�$��18(�$��宋体)�$
��Left=�$��Center=�$��2���� -   $��TBShelf��$	��100��$��2��$�� ��$��	255,0,0,0q�$��18(�$��宋体)�$
��Left=�$��Center=�$��2���� $��2��$��备注��$��	358,6,0,6q�$��18(�$��宋体)�$
��Left=�$��Center=�$��2���� -   $��TBNote��$	��140��$��2��$�� ��$��	403,3,0,0q�$��18(�$��宋体)�$
��Left=�$��Center=�$��2���� $��3��$��长宽高cm��$��7,6,0,6q�$��18(�$��宋体)�$
��Left=�$��Center=�$��3���� -   $��TBLength��$��50��$��3��$�� ��$��18,3,0,3q�$��18(�$��宋体)�$
��Left=�$��Center=�$��2���� $��3��$��×��$��68,6,0,6q�$��22(�$��宋体)�$
��Left=�$��Center=�$��2���� -   $��TBWidth��$��50��$��3��$�� ��$��90,3,0,3q�$��18(�$��宋体)�$
��Left=�$��Center=�$��2���� $��3��$��×��$��	140,6,0,6q�$��22(�$��宋体)�$
��Left=�$��Center=�$��2���� -   $��TBHeight��$��50��$��3��$�� ��$��	162,3,0,3q�$��18(�$��宋体)�$
��Left=�$��Center=�$��2���� $��3��$��=��$��	215,6,0,6q�$��22(�$��宋体)�$
��Left=�$��Center=�$��2���� -   $��TBSize��$��80��$��3��$	��0.0��$��	228,3,0,3q�$��18(�$��宋体)�$
��Left=�$��Center=�$��2�� �� 
IsReadOnly . �� $��3��$��(体积重kg)��$��	308,7,0,7q�$��16(�$��宋体)�$
��Left=�$��Center=�$
��Bold"�$��2���� -   $��CBLong��$��3��$��2��$��超长��$��	398,0,0,4q�$��Center=�$��宋体)�$��18(�$
��Left=�$
��Bold"��� -   $��CBHelf��$��4��$��2��$��超重��$��	398,0,0,4q�$��Center=�$��宋体)�$��18(�$
��Left=�$
��Bold"��� $��3��$��货 架��$��	458,4,0,4q�$��22(�$��宋体)�$
��Left=�$��Center=�$
��Bold"�
���  ��$��2���� $��4��$��票数/容量��$��	458,7,0,7q�$��22(�$��宋体)�$
��Left=�$��Center=�$
��Bold"�
���  ��$��2���� $��4��$��内部备注��$��7,6,0,0q�$��18(�$��宋体)�$
��Left=�$	��Top=�$��3���� -   $��TBNoteStaff��$��2��$	��360��$��4��$�� ��$��18,3,0,3q�$��18(�$��宋体)�$
��Left=�$��Center=�� $��1��.+��� -   $��CBFastInput��$��快速录入��$��0,0,0,4q�$	��Top=�$��宋体)�$��18(��� -   $��
CBlastName��$��默认上一次旺旺名��$��0,20,0,4q�$	��Top=�$��宋体)�$��18(��� -   $��CBAutoShelf��$��自动分配货架��$��0,40,0,4q�$	��Top=�$��宋体)�$��18(��� -   $��CBInputTime��$��手动扫描时间��$��0,60,0,4q�$	��Top=�$��宋体)�$��18(��� -   $��CBEnterPrint��$��备注栏回车打印��$��0,80,0,4q�$	��Top=�$��宋体)�$��18(��� -   $��CBNoZero��$��重量大于0��$��	0,100,0,4q�$	��Top=�$��宋体)�$��18(��� -   $��
CBBeginTwo��$��重量大于0.2��$��	0,120,0,4q�$	��Top=�$��宋体)�$��18(��� -   $��CBLook��$��客人可见��$��	0,140,0,4q�$	��Top=�$��宋体)�$��18(��� -   $��
CBBigShelf��$��	大货区��$��	0,160,0,4q�$	��Top=�$��宋体)�$��18(��� -   $��CBSmallShelf��$��	小货区��$��	0,180,0,4q�$	��Top=�$��宋体)�$��18(�$
 TrueY��� $��记录数：��$��	200,2,2,2q�$��25(�$��宋体)�$
��Left=�$	��Top=��� -    $��TBNum��$��55��$��0��$��300,-11,0,0q�$��66(�$��宋体)�$
��Left=�$	��Top=�
���  ��$
��Bold"��� $��2��$��Bottom=�
�������
�������$��1q��� $��3��$
��Auto=�$
��Auto=�.���� $	��200��.+�&   System.Windows.Controls.DataGrid  -!   $	��DG1��$��1��   AutoGenerateColumns .  $��22(�$��宋体)�$	��200��   CanUserSortColumns .     CanUserResizeColumns . $��1q�����    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 选择��   CellTemplate �� .R��� $��cbStatus�� �� *
IsSelect+
 � Tag �� *ID+0	  *System.Windows.Controls.DataGridTextColumn	  $ 扫描时间��  contentCenterStyle1
  +System.Windows.Controls.DataGridBoundColumn 
  ElementStyle# [  
  Binding �� *Weight_Time+	  $ 运单编号��# [  �� *Weight_ConID+	  $ 件数��# [  �� *
Weight_Num+	  $ 秤重��# [  �� *Weight_Weitgh+	  $ 备注��# [  �� *Weight_Note+	  $ 	上一站��# [  �� *Weight_Last+	  $ 存放货架��# [  �� *Weight_Shelf+	  $ 旺旺编号��# [  �� *Weight_UserId+	  $ 	旺旺名��# [  �� *Weight_UserName+	  $ 	体积重��# [  �� *Weight_Size+	  $ 计费重量��# [  �� *Weight_Helf+	  $ 包装类型��# [  �� *Weight_Pack+	  $ 所在仓库��# [  �� *Weight_Region+	  $ 内部备注��# [  �� *Weight_NoteStaff+	  $ 超长��   
IsReadOnly . # [  �� *Weight_OverLong+	  $ 超重�� . # [  �� *Weight_OverHelf+