   M S B A M L   `   `   `  ����O  KSimple Food Delivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Simple_Food_Delivery.PagesSimple_Food_Delivery.Pages  5      -    'Simple_Food_Delivery.Pages.OrderDetails   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Simple_Food_Delivery.Pages     5      -   5          N� Title$  OrderDetails��5	      .��5   
   � 
������� � RowDefinitions 5      �� 5      $��30 �6    �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      -   5         �Name$ LastRow��5       $��80 �6/    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6   $��1��6&    �� Orientation$ 
Horizontal=�66    J� RenderTransformOrigin$ 0.5,0.5&�6O   z�5      V� 5      .~�5      �� �� 5       �� 5!       �� Angle$	 180Q�6*   T� 5"      5#      .+�5%      �� -   5        $��CloseB��5%   =      
TopButtons#��[  6   $��X��6K   $��15(�6W   $
��Bold"�6e   $��47��6w   6�   �� 5&      -   5        $
��MaxB��5&   =   #��[  6   $	��□��6I   $��15(�6U   $
��Bold"�6c   $��Right=�6u   $��47��6�   6�   �� 5'      -   5        $
��MinB��5'   =   #��[  6   $	��–��6I   $��15(�6U   $
��Bold"�6c   $��Right=�6u   $��47��6�   6�   5(      �� 5+      -   5        $	��IC1��5+      $��1��6&   $��3��63   $��
30,20,50,0q�6D   $��2��6X   
���������5,      �� 5-      .R�5.      �  � Orientation$ 
Horizontal=�6$   5/      ��51      �� 52      .R�53      (� .��54      �� 
������� �� CornerRadius$ 10��6=   $��2��6O   ._�55   "   � $��40,0,0,0q�6'   $��2��69    56   &   �� 57   *   $	��750��6;   �� 58   *    5:   &   �� 5;   *   �� 5<   *   �� 5=   *   �� 5>   *   �� 5?   *   �� 5@   *   �� 5A   *   .+�5D   &   �� $��OrderId��60   $��10,10,10,10q�6x   $
��Bold"�6�   $��30(�6�   $��0��5E      $��0��6   ��5D   ?   �� 	 �� Path$	 OrderId�
 �� StringFormat$
 Заказ №{0}��5E      �� 5F   &   $��Names��60   $��Имя Фамилия��6=   $��15(�6�   $��1��5G      $��0��6   $
��Bold"�6   ��5F   P   �� *Margin+ �� ElementName$ OrderId��5G      �� 5H   &   $��EmailAndPhone��60   $��Тел Почта��6E   $��15(�6�   $��2��5I      $��0��6   ��5H   V   �� *Margin+$ OrderId��5I      �� 5J   &   $,��&Оплата при получении��60   $��15(�6|   $��3��5K      $��0��6   ��5J   L   �� *Margin+$ OrderId��5K      �� 5L   &   $��15(�6�   $��4��5M      $��0��6   ��5L   0   �� $	 DeliveryDate�$&
  Время доставки: {0}����6w   �� *Margin+$ OrderId��5M      �� 5N   &   $��15(�6�   $
��auto��6�   $��5��5O      $��0��6   ��5N   0   �� $	 UserAddress�$
 Адрес: {0}����6m   �� *Margin+$ OrderId��5O      �� 5Q   &   $��StatusTB��60   $
��Bold"�6�   $��20(�6�   $��0��5R      $��1��6   ��5Q   @   �� $	 OrderStatus�$
 Статус: {0}����6~   �� *Margin+$ OrderId��5R      �� 5S   &   $��AllPrice��60   $��20(�6�   $��3��5T      $��1��6   ��5S   @   �� $	 
FinalPrice�$%
 Общая сумма: {0:0}₽����6�   �� *Margin+$ OrderId��5T      �� 5U   &   $+��%Доставка:  Бесплатно��60   $��20(�6{   $��4��5V      $��1��6   ��5U   L   �� *Margin+$ OrderId��5V      �� 5W   &   $��20(�6�   $
��Bold"�6�   $��5��5X      $��1��6   ��5W   0   �� $	 
FinalPrice�$
 Итого: {0:0}₽����6o   �� *Margin+$ OrderId��5X      5Y   #   5Z      5[      5\      5^      �� 5`      $��СОСТАВ ЗАКАЗА��6   $��4��6-   $
��Bold"�6:   $��25(�6L   $��Bottom=�6Z   $��	60,0,0,10q�5a   
   �� 5c   
   -   5        $��LowSV��5c      $��5��6$   $��2��61   $��2��6E   .��5d      �� -   5         ��Name$	 IC2��5d      $��5��6(   $��2��65   $��2��6F   
�������$��30,20,40,20q�6m   ��5e      �� 5f      .R�5g      � $ 
Horizontal=�6$   5h      ��5j      �� 5k      .R�5l      (� .��5m      � $	��GR1��6#   $��2��6.   $��0��6;   $��
20,20,20,0q�6K   $	��600��6_    5n   "   �� 5o   &   $	��120 �67   �� 5p   &   $	��200 �67   �� 5q   &   $	��285 �67   �� 5r   &   $	��300 �67    5t   "   �� 5u   &   �� 5v   &   .+�5x   "   �� $��ProductImage��6(   $	��100��6<   $	��100��6I   $��UniformToFill=�6U   ��5y      �� $	 OrdersCompositions.Image��� 5z   "    ��Name$ Title��6<   $��1��6,   $��20(�6K   $
��Bold"�6Y   $��	10,0,10,0q�6k   $	��100��6~   $
��Wrap=�6�   ��5{   	   �� $	 Product��� 5|   "   $��CountTB��6,   $��2��6;   $
��Bold"�5}   D   $��Right=�6V   ��5|   K   �� *
FontSize+$ MinusB����6}   �� *Margin+$ Title����5}   	   �� $	 CountOfProduct�$
 {0}шт��6V   �� 5~   "   $��	FoodPrice��6,   $��3��6=   $	��260��6M    �� TextAlignment$ Right=�6\   $��20(�6r   $��Right=�6�   $
��Bold"�6�   ��6�   �� *Margin+$ Title��5�      5�      5�      5�      5�      � 5�   
   -	   5        $��LowGrid��5�      $��7��6   $��2��6+    5�      �� 5�      �� 5�       5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      .+�5�      �� $�� Действия��6   $��0,10,0,0q�6-   $
��Bold"�6?   $��20(�6Q   $��Center=�6_   $��11��6|   �� 5�      -
   5        $��OtmenaB��5�      $��X��6(   $��1��64   $��4��6A   
�������
���  ��  UnderTopButtons#��[ 6u   5�      �� 5�      -   5        $��CallB��5�      $
��📞��6'   $��1��64   $��5��6A   
�������
����  �#��[ 6v   5�      �� 5�      -   5        $��MessageToSupportB��5�      $
��💬��62   $��1��6?   $��6��6L   
�������
��� ���#��[ 6�   5�      �� 5�      -   5        $��AcceptB��5�      $	��✅��6(   $��1��64   $��7��6A   
�������
��� � �#��[ 6w   $y�Hidden=�5�      6&   5�      5�      5�      