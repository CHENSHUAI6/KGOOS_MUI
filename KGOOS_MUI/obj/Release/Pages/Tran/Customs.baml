   M S B A M L   `   `   `  ���� ^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  	KGOOS_MUI"   KGOOS_MUI.Pages.Tran.Customs   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  .���    ContentRoot#��[    � RowDefinitions  �� $��40 ��� $��40 ��� $	��130 ��� $��* �.+��� $��0��$��Bottom=�
�������
�������$��1q��� $��5��$��Bottom=�
�������
�������$��1q��� $��1��$��5��$
��Left=�
�������
�������$��1q��� $��1��$��5��$��Right=�
�������
�������$��1q��� $��0��$��报关明细查询��$��2,2,2,2q�$��25(�$��宋体)�$
��Left=�$	��Top=�$
��Bold"�� $��1�� � ColumnDefinitions �� $��55 ��� $��50 ��� $��* �.+��� -   $��	BtnSelect��$��0��$��25��$��查 询��$��10(�$��1,1,1,1q�$��7,2,2,2q��� -   $��	BtnOutput��$��1��$��25��$��导 出��$��10(�$��1,1,1,1q�$��2,2,2,2q��� $��1��$��Bottom=�
�������
�������$��1q�� $��2�� �� $	��200 ��� $	��230 ��� $��* �.+�� $��0��  �� $��25 ��� $��* �.+��� -   $
��CBID��$��0��$��按单号查询��$��5,2,2,2q�$��Center=�$��宋体)�$��11(�$
��Left=��� -   $��BtnClear��$��0��$��20��$��清 空��$��10(�$��1,1,1,1q�$��2,2,20,2q�$��Right=�$��Center=��� -   $
��TBID�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . " �� VerticalScrollBarVisibility$ Visible=�$	��100��$	��190��$��1��$�� ��$��5,5,5,5q�$��12(�$��宋体)�� $��1��  �� $��25 ��� $��* ��� $��* ��� $��10 �.+��� $��0��$	��Top=�
�������
�������$��1q��� $��2��$��Bottom=�
�������
�������$��1q��� $��0��$��3��$
��Left=�
�������
�������$��1q��� $��0��$��3��$��Right=�
�������
�������$��1q��� $��0��$	��200��$(��"扫描日期范围(31天以内)：��$��7,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� $��1��$��55��$��开始��$��20,5,2,2q�$��15(�$��宋体)�$
��Left=�$��Center=�7   1System.Windows.Forms.Integration.WindowsFormsHost  $	��150��$��1��$��60,2,2,2q�$
��Left=�$��Center=�   FontSize$ 12Q�   
FontFamily$ 宋体)�   Child. )  #System.Windows.Forms.DateTimePicker  -   TBStartTime��"  System.Windows.Forms.Control   Width$	 150��	   Height$	 20��
   Format$
 Custom=�   CustomFormat$ yyyy-MM-dd: HH:mm:ss���� $��2��$��55��$��结束��$��20,5,2,2q�$��15(�$��宋体)�$
��Left=�$��Center=�  $	��150��$��2��$��60,2,2,2q�$
��Left=�$��Center=�$ 12Q�$ 宋体)�.   -   	TBEndTime��$	 150��$	 20��$
 Custom=�$ yyyy-MM-dd: HH:mm:ss��� $��2�� �� $	��200 ��� $��* �  �� $��* ��� $��* ��� $��* �.+��� $��50��$��0��$��0��$��扫描网点��$��7,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� $	��130��$��0��$��0��$�� ��$��60,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� $��50��$��1��$��0��$��	旺旺名��$��7,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� $	��130��$��1��$��0��$�� ��$��60,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� $��50��$��2��$��0��$��返回记录��$��7,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� -   $��TBReturnNum��$	��130��$��2��$��0��$	��300��$��60,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� $��50��$��0��$��1��$��	承运商��$��2,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� $	��130��$��0��$��1��$�� ��$��55,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� $��50��$��1��$��1��$��	目的地��$��2,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� $	��130��$��1��$��1��$�� ��$��55,2,2,2q�$��12(�$��宋体)�$
��Left=�$��Center=��� $��3��.���� $	��200��.+�&   System.Windows.Controls.DataGrid  -	   $	��DG1��   AutoGenerateColumns .  $��18(�$��宋体)�   
IsReadOnly . ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 寄件日期��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Weight_ConID+  $ 	承运商�� �� *Weight_ConID+  $ 运单编号�� �� *Weight_ConID+  $ 总重量(kg)�� �� *Weight_ConID+  $ 	子单号�� �� *Weight_ConID+  $ 物品名称�� �� *Weight_ConID+  $ 件数�� �� *Weight_ConID+  $ 
重量(kg)�� �� *Weight_ConID+  $ 备注�� �� *Weight_ConID+  $ 客户名称�� �� *Weight_ConID+  $ 	收件人�� �� *Weight_ConID+  $ 收件人电话�� �� *Weight_ConID+  $ 	目的地�� �� *Weight_ConID+  $ 运费�� �� *Weight_ConID+  $ 收件人公司�� �� *Weight_ConID+  $ 收件人地址�� �� *Weight_ConID+  $ 录入时间�� �� *Weight_ConID+