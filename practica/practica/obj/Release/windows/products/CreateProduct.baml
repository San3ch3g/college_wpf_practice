   M S B A M L   `   `   `  ����   practica3    -pracrica.windows.products.CreateProductWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$'  !Создание продукта��$	��300��$	��400�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�.��� 
������� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $(��"Название продукта:��$��0��$��0��$��Center=�$��
20,20,10,0q��� -    ��Name$ ProductNameTextBox��$��0��$��1��$	��200��$��30��$��	0,20,20,0q��� $ ��Цена продукта:��$��1��$��0��$��Center=�$��
20,20,10,0q��� -   $ ProductPriceTextBox��$��1��$��1��$	��200��$��30��$��	0,20,20,0q��� $��Категория:��$��2��$��0��$��Center=�$��
20,20,10,0q��� -    ��Name$ CategoryComboBox��$��2��$��1��$	��200��$��30��$��	0,20,20,0q��� $��3��$��2�� �� Orientation$ 
Horizontal=�$��Center=�$��	0,20,0,20q�.+��� -   $��Сохранить��$	��100��$��30��$��10q��� -   $��Отмена��$	��100��$��30��$��10q�