   M S B A M L   `   `   `  ����O  KSimple Food Delivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Simple_Food_Delivery.ModalWindows!Simple_Food_Delivery.ModalWindows  5   	   7    1Simple_Food_Delivery.ModalWindows.PersonalAccount   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:Simple_Food_Delivery.ModalWindows     5   	   -   5        $��PersonalAccountWindow��5   !     � Title$  PersonalAccount��6	   $	��600��6>   $	��600��6K   $	��600��5	   	   $	��600��6    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $	��.7* �6   �� 5      �� 5       �� 5!      .+�5#   
   �� $��0��6   $��3��6"    �� Orientation$ 
Horizontal=�62    J� RenderTransformOrigin$ 0.5,0.5&�6K   z�5$      V� 5%      .~�5&      �� �� 5'      �� 5(       �� Angle$	 180Q�6&   T� 5)      5*      .+�5,      �� -   5        $��CloseB��5,   9      
TopButtons#��[  6   $��X��6G   $��15(�6S   $
��Bold"�6a   $��47��6s   6~   �� 5-      -   5        $
��MaxB��5-   9   #��[  6   $	��□��6E   $��15(�6Q   $
��Bold"�6_   $��Right=�6q   $��47��6�   $y�Hidden=�6�   �� 5.      -   5        $
��MinB��5.   9   #��[  6   $	��–��6E   $��15(�6Q   $
��Bold"�6_   $��Right=�6q   $��47��6�   $y�Hidden=�6�   5/      �� 51   
   -   5        $��LoginTextBlock��51      $��
Логин��6*   $
��Bold"�67   $��20(�6I   $��1��6W   $��2��6d   $��2��6t   $��Bottom=�6�   $��Center=�6�   �� 52   
   -   5        $��LoginTB��52      $��2��6!   $��2��6.   $��2��6>   $��1q�6�   $	��200��6�   $��30��6�   $	��Top=�6�   $��Center=�6�   $��0,5,0,0q�6�   $��Center=�53      ��52   R   �� *
FontSize+	 �� ElementName$	 LoginTextBlock��53   $   �� 54   
   $��Пароль��6   $
��Bold"�6"   $��2��64   $��3��6{   $��2��6�   $��Bottom=�6�   $��Center=�6�   ��6H   �� *
FontSize+$	 LoginTB��6�   G� 55   
   -   5        $
��PBox��55      $��4��6"   $��2��6/   $��2��6?   $	��Top=�6  $��0,5,0,0q�6+  $��Center=�56      $��Center=�6#   ��55   S   �� *
FontSize+$	 LoginTB����6�   �� *	Padding+$	 LoginTB����6�   �� *Width+$	 LoginTB����6�   �� *Height+$	 LoginTB��56   @   �� 57   
   $��Телефон��6   $
��Bold"�6#   $��2��65   $��5��6|   $��2��6�   $��Bottom=�6�   $��Center=�6�   ��6I   �� *
FontSize+$	 LoginTB��6�   �� 58   
   -   5        $��PhoneNumber��58      $��6��6%   $��2��62   $��2��6B   $	��Top=�6  $��0,5,0,0q�6.  $��Center=�59      $��Center=�6#   ��58   V   �� *
FontSize+$	 LoginTB����6�   �� *	Padding+$	 LoginTB����6�   �� *Width+$	 LoginTB����6�   �� *Height+$	 LoginTB��59   @   �� 5:   
   $��
Почта��6   $
��Bold"�6!   $��2��63   $��7��6z   $��2��6�   $��Bottom=�6�   $��Center=�6�   ��6G   �� *
FontSize+$	 LoginTB��6�   �� 5;   
   -	   5        $��Email��5;      $��8��6   $��2��6,   $��2��6<   $	��Top=�6  $��0,5,0,0q�6(  $��Center=�5<      $��Center=�6#   ��5;   P   �� *
FontSize+$	 LoginTB����6�   �� *	Padding+$	 LoginTB����6�   �� *Width+$	 LoginTB����6�   �� *Height+$	 LoginTB��5<   @   �� 5=   
   $��
Адрес��6   $
��Bold"�6!   $��2��63   $��9��6z   $��2��6�   $��Bottom=�6�   $��Center=�6�   ��6G   �� *
FontSize+$	 LoginTB��6�   �� 5>   
   -
   5        $��Address��5>      $��10��6!   $��2��6/   $��2��6?   $	��Top=�6  $��0,5,0,0q�6+  $��Center=�5?      $��Center=�6#   ��5>   S   �� *
FontSize+$	 LoginTB����6�   �� *	Padding+$	 LoginTB����6�   �� *Width+$	 LoginTB����6�   �� *Height+$	 LoginTB��5?   @   �� 5A   
   -   5        $��ForImage��5A      $��1��6!   $��3��6.   $��0��6?   $��2��6O   
���� ��$��2q�6x   
 �� CornerRadius$
 10��6�   $��	41,2,41,2q�5B   
   ��5C      �� 5D      -   5        
Avatar�� �� ImageSource$$ ..\Resources\defaultavatar.png��5D   -    j� Stretch$ UniformToFill=�6Z   5F      �� 5G   
   -   5        $��ChangeAvatarButton��5G      $��4��6+   $��2��68   $!��Загрузить фото��6L   $	��Top=�5H   	   $��
35,10,35,0q�6!   65   �� 5J   
   $��Имя��6   $��5��6   $��0��6,   $��2��6<   $
��Bold"�6P   $��Bottom=�6�   $��Center=�6�   ��6b   �� *
FontSize+$	 LoginTB��6�   �� 5K   
   -   5        $��NameTB��5K      $��6��6    $��0��6-   $��2��6=   $	��Top=�6  $��0,5,0,0q�6)  $��Center=�5L      ��5K   Q   �� *
FontSize+$	 LoginTB����6�   �� *	Padding+$	 LoginTB����6�   �� *Width+$	 LoginTB����6�   �� *Height+$	 LoginTB��5L   #   �� 5M   
   $��Фамилия��6   $��7��6#   $��0��60   $��2��6@   $
��Bold"�6T   $��Bottom=�6�   $��Center=�6�   ��6f   �� *
FontSize+$	 LoginTB��6�   �� 5N   
   -   5        $��	SurnameTB��5N      $��8��6#   $��0��60   $��2��6@   $	��Top=�6  $��0,5,0,0q�6,  $��Center=�5O      ��5N   T   �� *
FontSize+$	 LoginTB����6�   �� *	Padding+$	 LoginTB����6�   �� *Width+$	 LoginTB����6�   �� *Height+$	 LoginTB��5O   #   �� 5P   
   $��Отчество��6   $��9��6$   $��0��61   $��2��6A   $
��Bold"�6U   $��Bottom=�6�   $��Center=�6�   ��6g   �� *
FontSize+$	 LoginTB��6�   �� 5Q   
   -   5        $��
LastNameTB��5Q      $��10��6$   $��0��62   $��2��6B   $	��Top=�6  $��0,5,0,0q�6.  $��Center=�5R      ��5Q   V   �� *
FontSize+$	 LoginTB����6�   �� *	Padding+$	 LoginTB����6�   �� *Width+$	 LoginTB����6�   �� *Height+$	 LoginTB��5R   #   �� 5U   
   -   5         ��Name$ ChangeInfoB��5U      $#��Обновить данные��6&   $
��Bold"�6@   $��15(�6R   $��11��6`   $��1��6n   $��2��6~   $��Center=�6�   {�.  ��6�   �� *Height+$	 LoginTB����6�   �� *Width+$	 LoginTB��5V   $   5W      5X      