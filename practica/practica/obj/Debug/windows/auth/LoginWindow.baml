   M S B A M L   `   `   `  ����C  ?practica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:pracrica.windows.authpracrica.windows.auth  5   	   '    !pracrica.windows.auth.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:pracrica.windows.auth     5   	     � Title$  LoginWindow��5   	   $	��300��6   $	��350��6*   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $ ��Вход в систему��6   $��0��5      $��2��6!   $��Center=�5      $��24(�5      $��	0,20,0,20q�5      �� 5   
   $��Логин:��6   $��1��5      $��0��6!   $��Center=�5      $��	20,0,10,0q�5      �� 5    
   -   5         ��Name$ LoginTextBox��5       $��1��5!      $��1��6   $	��200��5"      $��30��6   $��	0,0,20,10q�5#      �� 5%   
   $��Пароль:��6   $��2��5&      $��0��6!   $��Center=�5'      $��	20,0,10,0q�5(      G� 5)   
   -   5         G�Name$ PasswordBox��5)      $��2��5*      $��1��6#   $	��200��5+      $��30��6"   $��	0,0,20,10q�5,      �� 5.   
   $��3��6   $��2��6"    �� Orientation$ 
Horizontal=�5/      $��Center=�50      $��	0,20,0,20q�51      .+�52      �� -   5        $��
Войти��52      $	��100��53      $��30��6!   $��10q�54      55      �� 56      -   5        $��Отмена��56      $	��100��57      $��30��6!   $��10q�58      59      5:      5;      5<      