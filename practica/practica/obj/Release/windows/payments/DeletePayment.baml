   M S B A M L   `   `   `  ����   practica3    -pracrica.windows.payments.DeletePaymentWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$%  Удаление платежа��$	��200��$	��400�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�.��� 
������� � RowDefinitions �� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $0��*Идентификатор платежа:��$��0��$��0��$��Center=�$��
20,20,10,0q��� -    ��Name$ PaymentIdTextBox��$��0��$��1��$	��200��$��30��$��	0,20,20,0q� �� 
IsReadOnly . �� $��1��$��2�� �� Orientation$ 
Horizontal=�$��Center=�$��	0,20,0,20q�.+��� -   $��Удалить��$	��100��$��30��$��10q��� -   $��Отмена��$	��100��$��30��$��10q�