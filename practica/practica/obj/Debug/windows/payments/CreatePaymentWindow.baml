   M S B A M L   `   `   `  ����  practica3    -pracrica.windows.payments.CreatePaymentWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$%  Создание платежа��5   	   $	��300��6"   $	��400��6/    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � 
������� � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Пользователь:��6   $��0��5      $��0��6!   $��Center=�5      $��
20,20,10,0q�5      �� 5   
   -   5         ��Name$ UserComboBox��5      $��0��5      $��1��6    $	��200��5      $��30��6   $��	0,20,20,0q�5      �� 5   
   $��Продукт:��6   $��1��5      $��0��6!   $��Center=�5      $��
20,20,10,0q�5       �� 5!   
   -   5        $ ProductComboBox��5!      $��1��5"      $��1��6    $	��200��5#      $��30��6   $��	0,20,20,0q�5$      �� 5&   
   $��Количество:��6   $��2��5'      $��0��6!   $��Center=�5(      $��
20,20,10,0q�5)      �� 5*   
   -   5         ��Name$ QuantityTextBox��5*      $��2��5+      $��1��6   $	��200��5,      $��30��6   $��	0,20,20,0q�5-      �� 5/   
   $��3��6   $��2��6"    �� Orientation$ 
Horizontal=�50      $��Center=�51      $��	0,20,0,20q�52      .+�53      �� -   5        $��Сохранить��53      $	��100��54      $��30��6!   $��10q�55      56      �� 57      -   5        $��Отмена��57      $	��100��58      $��30��6!   $��10q�59      5:      5;      5<      5=      