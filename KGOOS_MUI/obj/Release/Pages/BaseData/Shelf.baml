   M S B A M L   `   `   `  ���� ^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms D @KGOOS_MUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:KGOOS_MUI.ControlKGOOS_MUI.Control $   KGOOS_MUI.Pages.BaseData.Shelf   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     1tbnewclr-namespace:KGOOS_MUI.Control     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  .���    ContentRoot#��[    � RowDefinitions  �� $��40 ��� $��40 ��� $��60 ��� $��* �.+��� $��0��$��货架维护��$��2,2,2,2q�$��30(�$��宋体)�$
��Left=�$	��Top=�$
��Bold"��� $��0��$��Bottom=�
�������
�������$��1q��� $��5��$��Bottom=�
�������
�������$��1q��� $��1��$��5��$
��Left=�
�������
�������$��1q��� $��1��$��5��$��Right=�
�������
�������$��1q�� $��1�� � ColumnDefinitions �� $��65 ��� $��60 ��� $��60 ��� $��60 ��� $	��120 ��� $��* �.+��� -   $��
Btn_Select��$��0��$��30��$��查 询��$��18(�$��1,1,1,1q�$��7,2,2,2q��� -   $��Btn_Del��$��1��$��删 除��$��18(�$��1,1,1,1q�$��1.667,5,2.333,5q��� -   $��
Btn_Insert��$��2��$��30��$��新 建��$��18(�$��1,1,1,1q�$��2,2,2,2q��� -   $��Btn_Save��$��3��$��30��$��保 存��$��18(�$��1,1,1,1q�$��1.667,5,0,5q�$
��Left=�$��56���� -   $��
Btn_Cancel��$��4��$��30��$��取 消��$��18(�$��1,1,1,1q�$��1.667,5,2.333,0q�$	��Top=��� -   $��Btn_Select_Null��$��4��$��30��$��查询空货架��$��18(�$��1,1,1,1q�$��1.667,5,2.333,0q�$	��Top=��� $��1��$��Bottom=�
�������
�������$��1q�� $��2�� �� $
��1200 ��� $��* �.+�� $��0�� �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��0��$��区域��$��7,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� -   $��	CB_Region��$	��150��$��0�� �� Text$  ��$��85,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� $��0��$��1��$��类型��$��2,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� -   $��CB_Type��$	��150��$��1��$  ��$��85,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� $��2��$��货架名称��$��7,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� -	   $��TB_Shelf��$	��150��$��0��$��2��$�� ��$��85,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� $��0��$��3��$��	旺旺名��$��2,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=�+  %KGOOS_MUI.Control.AutoCompleteTextBox  -
     Name$ TBName��+  %KGOOS_MUI.Control.AutoCompleteTextBox   KeyDown$ TBName_KeyDown��$��30��$	��150��$��3��   Text$  ��$��85,2,2,2q�   FontSize$ 18Q�   
FontFamily$ 宋体)�$
��Left=�$��Center=��� $��0��$��4��$��备注��$��2,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� -   $��TB_Note��$	��150��$��0��$��4��$�� ��$��85,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� $��2��$��Bottom=�
�������
�������$��1q��� $��3��$
��Auto=�$
��Auto=�.���� $	��200��.+�&   System.Windows.Controls.DataGrid  -   $	��DG1��   AutoGenerateColumns .  $��18(�$��宋体)�	   
IsReadOnly	 . ���� 
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 序号��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *num+  $ 编号�� �� *
shelf_id+  $ 区域�� �� *shelf_region+  $ 类型�� �� *
shelf_type+  $ 货架名称�� �� *
shelf_name+  $ 	旺旺名�� �� *shelf_tb_user+  $ 现存货量�� �� *Region_Name+  $ 备注�� �� *
shelf_note+�� $��3��$��Bottom=�
�������
�������$��1q��� $��4��$��1��$��Stretch=�$��Bottom=�