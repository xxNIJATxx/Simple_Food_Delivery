   M S B A M L   `   `   `  ����O  KSimple Food Delivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Simple_Food_Delivery.ServicesSimple_Food_Delivery.Services  5   	   0    *Simple_Food_Delivery.Services.MyMessageBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:Simple_Food_Delivery.Services     5   	     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ MyMessageBox��5   	   $	��250��6   $	��250��6+   $	��600��6:   .��5   
   �� 
���� ��$��3q�6&   ._�5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      �� 5      -   5         �Name$ LastRow��5      $��50 �6+    � ColumnDefinitions 5   
   �� 5      $��80 �6   �� 5      �� 5      $��50 �6   .+�5   
   �� -   5        $��	CaptionTB��5      $��0��6%   $��2��62   $��ЗАГОЛОВОК��6F   $��Center=�6W   $��Center=�6r   $
��Bold"�5   	   $��50,0,0,0q�6   $��15(�6-   �� 5   
   $��0��6   $��2��6"    �� Orientation$ 
Horizontal=�62    J� RenderTransformOrigin$ 0.5,0.5&�6K   z�5      V� 5      .~�5      �� �� 5       �� 5!      	 �� Angle$		 180Q�6&   T� 5"      5#      .+�5%      �� -   5        $��CloseB��5%   9      
TopButtons#��[  6   $��X��6G   $��15(�6S   $
��Bold"�6a   $��47��6s   6~   5&      �� 5(   
   -   5        $��ImageForMessageBox��5(      $��1��6*   $��40��67   $��40��6B   $��Right=�6N   $��0,0,10,0q�6j   $��Uniform=�5)   
   $T��NC:\Users\KDFX Team\source\repos\Simple Food Delivery\Resources\information.png��5*   
   �� 5+   
   -   5        
 ��Name$
 	MessageTB��5+      $��1��6'   $��1��64   $��1��6D   $��Center=�6X   $��Center=�5,      $��Сообщение��6(   $
��Wrap=�69   $��5,0,0,0q�6M   $��15(�6^   �� 5.   
   -   5        $
��YesB��5.      $
��Да��6   $��2��6*   $��2��67   $��Center=�6K   $��Center=�6f   $��60��6�   $��0,0,50,0q�5/   
   $
��Bold"�6   $��40��6/   $��15(�6;   $y�Hidden=�6\   �� 50   
   -   5        $	��NoB��50      $��Нет��6   $��2��6*   $��1��67   $��2��6G   $��Center=�6[   $��60��6v   $
��Bold"�51      $��40��6   $��15(�6)   $y�Hidden=�6I   52      53      54      