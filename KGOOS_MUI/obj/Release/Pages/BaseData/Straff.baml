   M S B A M L   `   `   `  ���� ^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  	KGOOS_MUI%   KGOOS_MUI.Pages.BaseData.Straff   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  .���    ContentRoot#��[    � RowDefinitions  �� $��40 ��� $��40 ��� $��60 ��� $��* �.+��� $��0��$��员工维护��$��2,2,2,2q�$��30(�$��宋体)�$
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
�������$��1q�� $��1�� � ColumnDefinitions �� $��65 ��� $��60 ��� $��60 ��� $��60 ��� $��60 ��� $��* �.+��� -   $��
Btn_Select��$��0��$��30��$��查 询��$��18(�$��1,1,1,1q�$��7,2,2,2q��� -   $��Btn_Del��$��1��$��30��$��删 除��$��18(�$��1,1,1,1q�$��2,2,2,2q��� -   $��Btn_Save��$��2��$��30��$��保 存��$��18(�$��1,1,1,1q�$��2,2,2,2q��� -   $��
Btn_Cancel��$��3��$��30��$��取 消��$��18(�$��1,1,1,1q�$��2,2,2,2q��� $��4��$��30��$��导 出��$��18(�$��1,1,1,1q�$��2,2,2,2q��� $��1��$��Bottom=�
�������
�������$��1q�� $��2�� �� $
��1000 ��� $��* �.+�� $��0�� �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��0��$��员工编号��$��7,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� -   $
��TBid��$	��160��$��0��$��0��$�� ��$��85,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� $��0��$��1��$��员工姓名��$��2,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� -   $��TBname��$	��160��$��0��$��1��$�� ��$��85,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� $��2��$��网点名称��$��7,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� -   $��Region��$	��160��$��2�� �� Text$  ��$��85,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� $��0��$��3��$��登录密码��$��2,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� -   $��TBPass��$	��160��$��0��$��3��$�� ��$��85,2,2,2q�$��18(�$��宋体)�$
��Left=�$��Center=��� $��2��$��Bottom=�
�������
�������$��1q��� $��3��$
��Auto=�$
��Auto=�.���� $	��200��.+�&   System.Windows.Controls.DataGrid  -	   $	��DG1��   AutoGenerateColumns .  $��18(�$��宋体)�   
IsReadOnly . ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	员工号��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
id_staff+  $ 姓名�� �� *
name_staff+  $ 登录密码�� �� *
pass_staff+  $ 用户权限�� �� *
role_staff+  $ 网点编号�� �� *	Region_Id+  $ 网点名称�� �� *Region_Name+�� $��3��$��Bottom=�
�������
�������$��1q��� $��4��$��1��$��Stretch=�$��Bottom=�