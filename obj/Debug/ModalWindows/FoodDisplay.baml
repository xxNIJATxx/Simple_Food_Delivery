   M S B A M L   `   `   `  ����O  KSimple Food Delivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Simple_Food_Delivery.ModalWindows!Simple_Food_Delivery.ModalWindows  5   	   3    -Simple_Food_Delivery.ModalWindows.FoodDisplay   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:Simple_Food_Delivery.ModalWindows     5   	   -   5        $��FoodDisplayWindow��5        � Title$  FoodDisplay��6	   $	��600��66   $	��600��6F   $	��600��5	   	   $	��600��6    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $
��0.7* �6   .+�5   
   �� $��0��6   $��1��6"    �� Orientation$ 
Horizontal=�62    J� RenderTransformOrigin$ 0.5,0.5&�6K   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$	 180Q�6&   T� 5      5      .+�5      �� -   5        $��CloseB��5   9      
TopButtons#��[  6   $��X��6G   $��15(�6S   $
��Bold"�6a   $��47��6s   6~   �� 5       -   5        $
��MaxB��5    9   #��[  6   $	��□��6E   $��15(�6Q   $
��Bold"�6_   $��Right=�6q   $��47��6�   $y�Hidden=�6�   �� 5!      -   5        $
��MinB��5!   9   #��[  6   $	��–��6E   $��15(�6Q   $
��Bold"�6_   $��Right=�6q   $��47��6�   $y�Hidden=�6�   5"      �� 5$   
   -   5        $��	FoodImage��5$      $��	20,0,20,0q�6!   $��1��64   $��2��6A   $��Uniform=�6R   � 5&   
   $��1��6   $��2��6   $��1��6-   
������� 5'      �� 5(      -   5        	 �Name$	 FirstRow��5(       �� 5)      �� 5*      .+�5,      �� -   5        
 ��Name$
 Title��5,   +   $��	10,5,10,5q�6   $��Center=�6:   $��15(�6U   $
��Bold"�6c   $��0��6u   �� 5-      	 �� X1$	 250��6   $��Bottom=�6   
�������$��2��6J   �� 5.      -   5        $
 Description��5.   E   $��1��6Z   $
��Wrap=�6g   ��6   �� *Margin+ �� ElementName$ Title��6g   �� 5/      -	   5         ��Name$ SelectB��5/   B   $(��"Добавить в корзину��6S   $��50��6p   $��2��6|   $��Center=�6�   ��6   �� *Margin+$ Title��50      51      52      53      