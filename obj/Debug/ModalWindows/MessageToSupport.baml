   M S B A M L   `   `   `  ����O  KSimple Food Delivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Simple_Food_Delivery.ModalWindows!Simple_Food_Delivery.ModalWindows  5   	   8    2Simple_Food_Delivery.ModalWindows.MessageToSupport   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:Simple_Food_Delivery.ModalWindows     5   	   -   5        $��MessageToSupportWindow��5   "     � Title$  MessageToSupport��6	   $	��500��6@   $	��400��6M   $	��500��5	   	   $	��400��6    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"    J� RenderTransformOrigin$ 0.5,0.5&�6;   z�5      V� 5      .~�5      �� �� 5      �� 5        �� Angle$	 180Q�6&   T� 5!      5"      .+�5$      �� -   5        $��CloseB��5$   9      
TopButtons#��[  6   $��X��6G   $��15(�6S   $
��Bold"�6a   $��47��6s   6~   �� 5%      -   5        $
��MaxB��5%   9   #��[  6   $	��□��6E   $��15(�6Q   $
��Bold"�6_   $��Right=�6q   $��47��6�   $y�Hidden=�6�   �� 5&      -   5        $
��MinB��5&   9   #��[  6   $	��–��6E   $��15(�6Q   $
��Bold"�6_   $��Right=�6q   $��47��6�   $y�Hidden=�6�   5'      �� 5)   
   $��2��6   $y��sНапишите нам по любому вопросу. Мы оперативно решим ваш вопрос!��6!   $
��Wrap=�6h   $��Center=�5*   
   $��Center=�6'   �� 5,   
   -   5        $��EmailTextBlock��5,      $9��3Электронная почта для связи��6*   $
��Bold"�6M   $��15(�6_   $��3��6m   $��Bottom=�6z   $��Center=�6�   �� 5-   
   -   5        $��EmailTB��5-      $��4��6!   $��3q�6h   $	��200��6t   $��30��6�   $	��Top=�6�   $��Center=�6�   $��0,5,0,0q�6�   $��Center=�5.      ��5-   .   �� *
FontSize+ �� ElementName$ EmailTextBlock��5.      �� 50   
   $!��Ваше сообщение��6   $
��Bold"�6*   $��5��6o   $��Bottom=�6|   $��Center=�6�   ��6<   �� *
FontSize+$ EmailTB��6�   �� 51   
   -   5        $��	MessageTB��51      $��6��6#   $��3q�6c   $	��Top=�6�   $��0,5,0,0q�6�   $��Center=�52      $��Center=�6#   ��51   0   �� *
FontSize+$ EmailTB����6o   �� *Width+$ EmailTB����6�   �� *Height+$ EmailTB��52   #   �� 54   
   -   5        $��
FileNameTB��54      $��
Файлы��6&   $
��Bold"�63   $��7��6x   $��Bottom=�6�   $��Center=�6�   ��6E   �� *
FontSize+$ EmailTB��6�   �� 55   
   -	   5        $��DownloadImages��55      $��📥Загрузить��6'   $��8��6=   $��3q�6}   $	��Top=�6�   $��0,5,0,0q�6�   $��Center=�56      $��Center=�6#   
�������
���   �$��1q�6f   ��55   J   �� *
FontSize+$ EmailTB����6�   �� *Width+$ EmailTB����6�   �� *Height+$ EmailTB��57   	   �� 59   
   -
   5        $��SendMessageB��59      $��Отправить��6%   $��9��69   $��3q�6y   $	��Top=�6�   $��0,5,0,0q�6�   $��Center=�5:      $��Center=�6#   $��1q�6@   ��59   F   �� *
FontSize+$ EmailTB����6�   �� *Width+$ EmailTB����6�   �� *Height+$ EmailTB��5;   	   5<      5=      