   M S B A M L   `   `   `  ����M  ITraidingCompanyWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TraidingCompanyWPF.WindowsTraidingCompanyWPF.Windows  5   	   -    'TraidingCompanyWPF.Windows.OrderDetails   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:TraidingCompanyWPF.Windows     5   	     � Title$  OrderDetails��5   	   $	��450��6   $	��800��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Order number:��6   $��0��6)   $��0��66   $��Center=�6F   �� 5   
   $��Item title:��6   $��1��6'   $��0��64   $��Center=�6D   �� 5   
   $��Amount:��6   $��2��6#   $��0��60   $��Center=�6@   �� 5   
   $��Date:��6   $��3��6!   $��0��6.   $��Center=�6>   �� 5   
   $��Status:��6   $��4��6#   $��0��60   $��Center=�6@   �� 5   
   $��Comment:��6   $��5��6$   $��0��61   $��Center=�6A   �� 5   
   $��20(�6:   $��0��6I   $��1��6V   $��10q�6f   {�.  ��6   ��  �� Path$ Order.Ordernumber�6r   �� 5   
   $��20(�67   $��1��6E   $��1��6R   $��10q�6b   {�.  ��6   �� $ Item.ItemTitle�6n   �� 5    
   $��20(�67   $��2��6F   $��1��6S   $��10q�6c   {�.  ��6   �� $ Ordered.Amount�6o   �� 5!   
   $��20(�63   $��3��6A   $��1��6N   $��10q�6^   {�.  ��6   �� $ 
Order.Date�6j   �� 5"   
   $��20(�64   $��4��6C   $��1��6P   $��10q�6`   {�.  ��6   �� $ Status.Name�6l   �� 5#   
   $��20(�66   $��5��6D   $��1��6Q   $��10q�6a   {�.  ��6   �� $ Order.Comment�6m   5&      5'      