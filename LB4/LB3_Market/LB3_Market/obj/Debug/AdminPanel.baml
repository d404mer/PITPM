   M S B A M L   `   `   `  ����E  ALB3_Market, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:LB3_Market
LB3_Market  5   	       LB3_Market.AdminPanel   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:LB3_Market     5   	     � Title$  
AdminPanel��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��376* �6   �� 5      $	��59* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ProductsDataGrid��5      $��10,10,10,10q�6-      AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5         RowHeaderWidth$ 0Q�5      $��0��5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 6W   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 67   �� *ProductName+6W     5      $ Описание��6%   $
	 Auto 6W   
 67   �� *Description+6W     5      $ Цена��6%   $	 50 6M   
 63   �� *Price+6M     5      $ Фотография��6%   $
	 Auto 6V   
 69   �� *
ImageURL+6V   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��	10,5,10,5q�6.   $��1��6A   .+�5      �� -   5         ��Name$	 Add��5      $8��2Добавить карточку продукта��6"   $��5q�6G   6R   �� 5       -   5        $ Delete��5       $6��0Удалить карточку продукта��6%   $��5q�6J   6U   5!      5"      5#      