   M S B A M L   `   `   `  ����  practica2    ,practica.windows.categories.CategoriesWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Категории��5   	   $	��400��6   $	��600��6(    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � 
������� � RowDefinitions 5      �� 5	      $
��Auto �6   �� 5
      $��* �6   .+�5      o� $��0��6	   .@�5      m� -   5        $��Создать��5      6   m� 5      -   5        $ ��Редактировать��5      6%   m� 5      -   5        $��Удалить��5      6   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ CategoriesDataGrid��5      $��1��5         AutoGenerateColumns .  $��10q�5         
IsReadOnly .    SelectionMode$ Single=�5      $��Stretch=�5      $��Stretch=�5         CanUserSortColumns . 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$ 
 Идентификатор��6      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 60   �� *Id+6G     5      $)
 #Название категории��6   $ * 6N      SortMemberPath$
 Name��6X    65   �� *Name+6X   5"      5#      5$      