   M S B A M L   `   `   `  ����M  ITraidingCompanyWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TraidingCompanyWPF.WindowsTraidingCompanyWPF.Windows  5   	   *    $TraidingCompanyWPF.Windows.OrderList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:TraidingCompanyWPF.Windows     5   	     � Title$  	OrderList��5   	   $	��450��6   $	��800��6(    � 	Resources 5	         OrderCollection �� Source �� Path��%C   &	        �� 5
   
    5      �� $ 	OrderList�5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��47* �6   �� 5      $
��334* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6$   $��Search:��61   $��10q�6@   �� 5   
   -   5         ��Name$ 	txtFilter��5   W   $��1��6   $��0��6"   $��10q�6/   ��6;   �� *
FilterText+6W   &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ dgOrders��5"      $��1��5!      $��2��6       AutoGenerateColumns .  	   SelectionMode$	 Single=�5$      
   SelectionUnit$
 FullRow=�5%         GridLinesVisibility$ 
Horizontal=�5&         CanUserDeleteRows .     CanUserAddRows .     CanUserResizeRows .  $��2��5*      ��5!   4   ��  �� Source# [   J� InputBindings 5,      d� 5-       d� Gesture$ LeftDoubleClicka�6    �� Command 69   �� *ElementDoubleClickCommand+ �� CommandParameter 6g   ��  �� ElementName$ dgOrders��$ SelectedItem�   Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ Ordernumber��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 6:      
IsReadOnly .    MinWidth$ 40Q�6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6n   �� *Ordernumber+  51      $
 Date��6%   $ SizeToCells 63    . $	 200Q�6Y    6h   �� *Date+  52      $ Comment��6%   $ SizeToCells 66    . $ 40Q�6\    6j   �� *	Comment+   	CellStyle 54      �� 55       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    �� Triggers 56      P� 57       P� Property �@ 
IsSelected P� Value . . �58      ��   �� Property  � ��! �� Value$! 0q�6@   59      5;      5=      5>      5?      