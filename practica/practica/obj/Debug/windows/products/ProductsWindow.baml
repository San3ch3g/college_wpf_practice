   M S B A M L   `   `   `  ����  practica.    (pracrica.windows.products.ProductsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Продукты��5   	   $	��400��6   $	��800��6'    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � 
������� � RowDefinitions 5      �� 5	      $
��Auto �6   �� 5
      $��* �6   .+�5      o� $��0��6	   .@�5      m� -   5        $��Создать��5      6   m� 5      -   5        $ ��Редактировать��5      6%   m� 5      -   5        $��Удалить��5      6   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ ProductsDataGrid��5      $��1��5         AutoGenerateColumns .  $��10q�5         
IsReadOnly .    SelectionMode$ Single=�5      $��Stretch=�5      $��Stretch=�5         CanUserSortColumns . 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$ 
 Идентификатор��6      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 60   �� *Id+6G     5      $
 Категория��6   $ * 6M    6,   �� *CategoryName+6M     5       $'
 !Название продукта��6   $ * 6M      SortMemberPath$
 Name��6W    64   �� *Name+6W     5"      $
 Цена продукта��6   $ * 6J   $ Price��6T    60   �� *Price+6T   5%      5&      5'      