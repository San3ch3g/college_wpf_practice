   M S B A M L   `   `   `  ����  practica3    -pracrica.windows.payments.DeletePaymentWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$%  Удаление платежа��5   	   $	��200��6"   $	��400��6/    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � 
������� � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $0��*Идентификатор платежа:��6   $��0��5      $��0��6!   $��Center=�5      $��
20,20,10,0q�5      �� 5   
   -   5         ��Name$ PaymentIdTextBox��5      $��0��5      $��1��6   $	��200��5      $��30��6   $��	0,20,20,0q�5       �� 
IsReadOnly . 5      �� 5   
   $��1��6   $��2��6"    �� Orientation$ 
Horizontal=�5      $��Center=�5      $��	0,20,0,20q�5      .+�5      �� -   5        $��Удалить��5      $	��100��5       $��30��6!   $��10q�5!      5"      �� 5#      -   5        $��Отмена��5#      $	��100��5$      $��30��6!   $��10q�5%      5&      5'      5(      5)      