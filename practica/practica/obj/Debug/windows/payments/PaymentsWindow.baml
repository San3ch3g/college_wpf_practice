   M S B A M L   `   `   `  ����C  ?practica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:practica.converterspractica.converters  5   	   .    (pracrica.windows.payments.PaymentsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   8
converters!clr-namespace:practica.converters     5   	     � Title$  Платежи��5   	   $	��400��6   $	��800��6&    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5      '   !practica.converters.DateConverter   DateConverter��%   &	          5
   
   6#   5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   o� $��0��6   .@�5      m� -   5        $��Создать��5      6(   m� 5      -   5        $ ��Редактировать��5      6.   m� 5      -   5        $��Удалить��5      6(   m� 5      -   5        $��
Отчёт��5      6&   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� $'��!Поиск по названию:��6   $��Center=�62   $��0,0,5,0q�6M   �� 5      -   5         ��Name$ SearchTextBox��5      $	��200��6-   69   �� 5      $��Дата от:��6   $��Center=�6(   $��10,0,5,0q�6C   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ StartDatePicker��5      62   �� 5      $��Дата до:��6   $��Center=�6(   $��10,0,5,0q�6C     5       -   5        $ EndDatePicker��5       60   5!      &   System.Windows.Controls.DataGrid  5#   
   -   5          Name$ PaymentsDataGrid��5#      $��2��5$      	   AutoGenerateColumns	 .  $��10q�5&      
   
IsReadOnly
 .    SelectionMode$ Single=�5(      $��Stretch=�5)      $��Stretch=�5*         CanUserSortColumns .    Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn   Header$  Идентификатор��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Id+6S     5.      $% Имя пользователя��6%   $ * 6\    6?   �� *
UserName+6\     5/      $' !Название продукта��6%   $ * 6`    6@   �� *ProductName+6`     50      $ Количество��6%   $ * 6V      SortMemberPath$ Quantity��6`    69   �� *
Quantity+6`     51      $! Итоговая сумма��6%   $ * 6]   $ TotalAmount��6g    6=   �� *TotalAmount+6g     53      $ Дата платежа��6%   $ * 6�   $ PaymentDate��6�    6;   �� *PaymentDate+ �� 	Converter# [  6�   55      56      57      