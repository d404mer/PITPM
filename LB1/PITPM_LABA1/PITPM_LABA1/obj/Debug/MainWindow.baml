   M S B A M L   `   `   `  ����F  BPITPM_LABA1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PITPM_LABA1PITPM_LABA1  5   	       PITPM_LABA1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PITPM_LABA1     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��	Ввод:��6   $��0��6!   $��10q�6.   $��16(�6:   $
��Bold"�6H   �� 5   
   -   5         ��Name$ 
InputArray��5      $��1��6&   $	��500��63   $��30��6?   $��10q�6K   �� 5   
   $��2��6    �� Orientation$ Vertical=�6"   $��Center=�69   $��10q�6V   .+�5      �� -   5        $��Пузырёк��5      $	��150��6'   $��5q�63   6>   �� 5      -   5        $��Вставка��5      $	��150��6'   $��5q�63   6>   �� 5      -   5        $��Быстрая��5      $	��150��6'   $��5q�63   6>   5      �� 5   
   $��Результат:��6   $��3��6&   $��10q�63   $��16(�6?   $
��Bold"�6M   �� 5   
   -   5         ��Name$ OutputArray��5      $��4��6)   $��10q�66   $��14(�6B   $
��Wrap=�6P   �� 5   
   $��5��6   $ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5       �� -   5        $��Очистить ввод��5       $	��150��6-   $��5q�69   6D   �� 5!      -   5        $)��#Очистить результат��5!      $	��150��62   $��5q�6>   6I   5"      5#      5$      