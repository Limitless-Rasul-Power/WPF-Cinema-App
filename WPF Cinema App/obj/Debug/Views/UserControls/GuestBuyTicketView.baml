   M S B A M L   `   `   `  ����I  EWPF Cinema App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF_Cinema_App.Views.UserControls!WPF_Cinema_App.Views.UserControls  5      :    4WPF_Cinema_App.Views.UserControls.GuestBuyTicketView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:WPF_Cinema_App.Views.UserControls     5      .��5	      � 
�������.+�5   
   �� $��0��6   $��Disabled=�6   $
��Auto=�5      ��5   U   �� *CinemaHalls+��5      �� 5      .R�5      �   � Orientation$  
Horizontal=�6    6;   5      ��5      �� 5      .R�5      � $	��480��6   $	��300��6'    � RowDefinitions 5      �� 5      $	��75* �6,   �� 5      $	��25* �6,   .+�5      �� $��0��6     � Cursor$
 Hand��6-   $
��Fill=�6[    � ToolTip$, &Click Left Button Twice to See Trailer��6j   ��6;   �� *Movie.Poster+ J� InputBindings 5      d� 5   "    d� Gesture$ LeftDoubleClicka�6/    �� Command 6I   �� * DataContext.ShowTrailerCommand+ �� RelativeSource ��  �� AncestorType" ��	 �� CommandParameter	 5    _   �� *Movie+5"      � 5$      $��1��6   
���OO/�
 � ColumnDefinitions
 5%      �� 5&   "   $	��50* �63   �� 5'   "   $	��20* �63   �� 5(   "   $	��30* �63   .+�5+      � $��0��6#   .+�5,   "   �� $��Disabled=�6/   $
��Auto=�6X   .��5-   &   �� $��20(�60    �� Padding$ 
5, 5, 0, 0q�6>   
�������$
��Wrap=�6f   �� 5.   &   $�Title :��6*    �� 5/   &   �6*   �� *Movie.Title+�� 50   &   �� 51   &   $�Genre :��6*    �� 52   &   �6*   �� *Movie.Genre+53   '   54   #   55      � 58      $��1��6#    59   "   �� 5:   &   $	��30* �64   �� 5;   &   $	��70* �64   .+�5>   "   �� $��0��6,   $��	Full Sits��69   $��15(�6J   $��Center=�6X   
�������$
��Bold"�6�   $��Bottom=�5?   ,   �� 5@   "   $��1��6,   $��Center=�69   $��Center=�6V   $��20(�6q   $��Italic$�6   
��������� 5B   &   �6*   �� *FullSitsCount+ �� 5C   &   $�of��6*    �� 5D   &   $�20��6*   5E   #   5G      �� 5I      $��2��6%      DashedButton#��[  65   $��
Buy Ticket��6[   ��5J   %   �� *DataContext.BuyTicketCommand+ �� " ����5K   %   �� 5M      5O      5P      5T      5V      5W      