   M S B A M L   `   `   `  ����  practica*    $pracrica.windows.auth.RegisterWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Регистрация��5   	   $	��400��6   $	��400��6*    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � 
������� � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Регистрация��6   $��0��5      $��2��6!   $��Center=�5      $��24(�5      $��	0,20,0,20q�5      �� 5   
   $��Имя:��6   $��1��5      $��0��6!   $��Center=�5      $��	20,0,10,0q�5      �� 5    
   -   5         ��Name$ FirstNameTextBox��5       $��1��5!      $��1��6   $	��200��5"      $��30��6   $��	0,0,20,10q�5#      �� 5%   
   $��Фамилия:��6   $��2��5&      $��0��6!   $��Center=�5'      $��	20,0,10,0q�5(      �� 5)   
   -   5        $ LastNameTextBox��5)      $��2��5*      $��1��6   $	��200��5+      $��30��6   $��	0,0,20,10q�5,      �� 5.   
   $��Логин:��6   $��3��5/      $��0��6!   $��Center=�50      $��	20,0,10,0q�51      �� 52   
   -   5        $ LoginTextBox��52      $��3��53      $��1��6   $	��200��54      $��30��6   $��	0,0,20,10q�55      �� 57   
   $��Пароль:��6   $��4��58      $��0��6!   $��Center=�59      $��	20,0,10,0q�5:      G� 5;   
   -   5         G�Name$ PasswordBox��5;      $��4��5<      $��1��6#   $	��200��5=      $��30��6"   $��	0,0,20,10q�5>      �� 5@   
   $��5��6   $��2��6"    �� Orientation$ 
Horizontal=�5A      $��Center=�5B      $��	0,20,0,20q�5C      .+�5D      �� -   5        $*��$Зарегистрироваться��5D      $	��150��5E      $��30��6!   $��10q�5F      5G      �� 5H      -   5        $��Отмена��5H      $	��100��5I      $��30��6!   $��10q�5J      5K      5L      5M      5N      