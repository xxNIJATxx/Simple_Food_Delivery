   M S B A M L   `   `   `  ����O  KSimple Food Delivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Simple_Food_Delivery.PagesSimple_Food_Delivery.Pages  5      -    'Simple_Food_Delivery.Pages.ManagingPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Simple_Food_Delivery.Pages     5        N� Title$  ManagingPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��80 �6   �� 5      �� 5      $��80 �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5        $��ChoiceTable��5      $��0,5,0,0q�6&   $
��Left=�67   $	��150��6R   .@�5      �� Пользователи6&   �� 5      Сотрудники6$   �� 5      
Роли6   �� 5      Продукты6"   �� 5      Типы продуктов6(   �� 5      Заказы6    �� 5      Состав заказов6(   �� 5      Корзины6!   �� 5       
Логи6   �� 5!      Типы действий6'   5"      �� 5#   
   -   5        $��ForTopCB��5#      $��Выбор таблицы��6$   $��5,9,0,0q�69   $��10(�6J   $
��Left=�6X   �� 5%   
   $��0��6    �� Orientation$ 
Horizontal=�6"   $��1��6;    J� RenderTransformOrigin$ 0.5,0.5&�6K   z�5&      V� 5'      .~�5(      �� �� 5)      �� 5*       �� Angle$	 180Q�6&   T� 5+      5,      .+�5.      �� -   5        $��CloseB��5.   9      
TopButtons#��[  6   $��X��6G   $��15(�6S   $
��Bold"�6a   $��47��6s   6~   �� 5/      -   5        $
��MaxB��5/   9   #��[  6   $	��□��6E   $��15(�6Q   $
��Bold"�6_   $��Right=�6q   $��47��6�   6�   �� 50      -   5        $
��MinB��50   9   #��[  6   $	��–��6E   $��15(�6Q   $
��Bold"�6_   $��Right=�6q   $��47��6�   6�   51      �� 53   
   -   5        $��SearchTB��53      $��Поиск...��6"   $��1��62   $��20q�6?   $��Center=�6K   $
��Bold"�54   
   $��4q�6   6I   �� 55   
   -   5        $
��🔍��55      
������ 
���   �$��1��6J   $��Right=�6W   $��0,0,30,0q�56   
   $��Center=�6   67   �� 58   
   -   5        $��SortCB��58      $��1��6!   $��1��6.   $��Center=�6>   $��20q�6Y   
�������.@�5:      �� (&Сначала новые записи6.   �� 5;      *(Сначала старые записи6/   5<      �� 5=   
   -	   5        $��	ForSortCB��5=   &   $��Сортировка��6   $��1��67   $��1��6D   $��Center=�6T   $��Center=�5>   
   �� 5B      -
   5        $��Border1��5B      $��2��6$   $��10q�61   
���� ��$��1q�6R   $��2��6f   ._�5C      &   System.Windows.Controls.DataGrid  -   5        $��DG��5C      $��2��6%   $��0q�62      HorizontalGridLinesBrush
 �� ��   VerticalGridLinesBrush
 �� ��   HeadersVisibility$ Column=�5D      
�������	   GridLinesVisibility$
	 None=�6?   $��2��6Z   
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 5E         
IsReadOnly .    ColumnHeaderStyle 5F      �� 5G       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5H      ��  �� Property � �� �� Value
 ��p��67   �� 5I       � ��
 �����67   �� 5J       � ��$	 0.5q�6<   �� 5K       � ��
 �� ��68   �� 5L       � ��$ 0,0,0,0q�63   5M         RowStyle 5P      �� 5Q      )  #System.Windows.Controls.DataGridRow"  6   .�5R      ��  � ��$ 0,-1,0,0q�63   5S         	CellStyle 5U      �� 5V      *  $System.Windows.Controls.DataGridCell"  6    .�5W      ��  � ��$	 0.5q�6@   �� 5X       � ��
 �� ��68   5Y      5[      5\      � 5^   
   $��3��6   $��2��6    5_      �� 5`      �� 5a      �� 5b      .+�5d      �� -   5        $
��AddB��5d      $��Добавить��6!   $��15q�64   $
��Bold"�6@   6R   �� 5e      -   5        $��ChangeB��5e      $��Изменить��6$   $��1��67   $��15q�6G   ��6S   �� *
FontWeight+ �� ElementName$
 AddB��6�   �� 5f      -   5        $
��DelB��5f      $��Удалить��6!   $��2��63   $��15q�6C   ��6O   �� *
FontWeight+$
 AddB��6�   5g      5i      5j      