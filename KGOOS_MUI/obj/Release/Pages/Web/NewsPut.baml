   M S B A M L   `   `   `  ����   	KGOOS_MUI     KGOOS_MUI.Pages.Web.NewPut   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  .���    ContentRoot#��[    � RowDefinitions  �� $��40 ��� $��40 ��� $	��200 ��� $��* �.+��� $��0��$��新闻发布��$��2,2,2,2q�$��25(�$��宋体)�$
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
�������$��1q�� $��1�� � ColumnDefinitions �� $��60 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��50 ��� $��* �.+��� $��0��$��25��$��查 询��$��10(�$��1,1,1,1q�$��12,0,2,8q�$��Bottom=��� $��1��$��25��$��新 建��$��10(�$��1,1,1,1q�$��2,2,2,2q��� -   $��	BTNDelete��$��2��$��25��$��删 除��$��10(�$��1,1,1,1q�$��2,2,2,2q��� -   $��BTNSave��$��3��$��25��$��保 存��$��10(�$��1,1,1,1q�$��2,2,2,2q��� $��4��$��25��$��取 消��$��10(�$��1,1,1,1q�$��2,2,2,2q��� $��5��$��25��$��上 传��$��10(�$��1,1,1,1q�$��2,2,2,2q��� $��6��$��25��$��导 入��$��10(�$��1,1,1,1q�$��2,2,2,2q��� $��7��$��25��$��导 出��$��10(�$��1,1,1,1q�$��2,2,2,2q��� $��1��$��Bottom=�
�������
�������$��1q�� $��2��  �� $��* ��� $��5* � �� $	��500 ��� $	��200 ��� $��* �.+��� $��50��$��0��$��新闻标题��$��7,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� $	��430��$��0��$�� ��$��60,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� $��50��$��1��$��	发布人��$��7,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� $	��130��$��1��$�� ��$��60,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� $��0��$��3��$��Bottom=�
�������
�������$��1q��� -   $
��TBID��$��1��$��3�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . " �� VerticalScrollBarVisibility$ Visible=�$�� ��$��5,5,5,5q�$��12(�$��宋体)��� $��3��.���� $	��200��.+�&   System.Windows.Controls.DataGrid  -   $	��DG1��$��1��   AutoGenerateColumns .  $��18(�$��宋体)�$	��200��   CanUserSortColumns .     CanUserResizeColumns . $��1q�����    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 选择��
   CellTemplate
 �� .R��� $��cbStatus�� d� 	IsChecked �� *
IsSelect+
 � Tag �� *ID+0  *System.Windows.Controls.DataGridTextColumn  $	 新闻ID��   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Weight_Time+  $	 新闻标题�� .  �� *Weight_Time+  $	 	发布人�� .  �� *Weight_Time+  $	 发布时间�� .  �� *Weight_Time+  $	 正文�� .  �� *Weight_Time+