   M S B A M L   `   `   `  ����I  EWPF Cinema App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF_Cinema_App.Views.UserControls!WPF_Cinema_App.Views.UserControls  5      ;    5WPF_Cinema_App.Views.UserControls.AdminSideCinemaView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:WPF_Cinema_App.Views.UserControls     5      .��5	      � 
�������  � RowDefinitions  5   
   �� 5      $	��80* �6   �� 5      $	��20* �6   .+�5   
   �� $��0��6   $��Disabled=�6   $
��Auto=�5      ��5   U   �� *CinemaHalls+��5      �� 5      .R�5      �  � Orientation$ 
Horizontal=�6    6;   5      ��5      �� 5      .R�5      � $	��333��6   $	��300��6'     5      �� 5      $	��70* �6,   �� 5      $	��30* �6,   .+�5!      ��  � Cursor$
 Hand��6    $
��Fill=�6N   $��0��6]   ��6.   �� *Movie.Poster+6]   � 5#      $��1��6   
�����_� � ColumnDefinitions 5$      �� 5%   "   $	��70* �63   �� 5&   "   $	��30* �63   .+�5)      � $��0��6#   .+�5*   "   �� $��Disabled=�6/   $
��Auto=�6X   .��5+   &   �� $��20(�60    �� Padding$ 
5, 5, 0, 0q�6>   
�������$
��Wrap=�6f   �� 5,   &   $�Title :��6*    �� 5-   &   �6*   �� *Movie.Title+�� 5.   &   �� 5/   &   $�Genre :��6*    �� 50   &   �6*   �� *Movie.Genre+51   '   52   #   53      � 56      $��1��6#     57   "   �� 58   &   $	��30* �64   �� 59   &   $	��70* �64   .+�5<   "   �� $��0��6,   $��	Full Sits��69   $��15(�6J   $��Center=�6X   
�������$
��Bold"�6�   $��Bottom=�5=   ,   �� 5>   "   $��1��6,   $��Center=�69   $��Center=�6V   $��20(�6q   $��Italic$�6   �� 5?   &   �6*   �� *FullSitsCount+ �� 5@   &   $�of��6*    �� 5A   &   $�20��6*   5B   #   5D      5F      5H      5I      5L      �� 5N   
   $��1��6      AddToCinemaButton#��[  6   $��
Add Cinema��6I   ��6^   �� *AddCinemaCommand+5O      5P      