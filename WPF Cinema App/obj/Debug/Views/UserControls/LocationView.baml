   M S B A M L   `   `   `  ����I  EWPF Cinema App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF_Cinema_App.Views.UserControls!WPF_Cinema_App.Views.UserControls  5      d `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF 6L   4    .WPF_Cinema_App.Views.UserControls.LocationView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:WPF_Cinema_App.Views.UserControls     5      `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     6L   .��5	      �   � RowDefinitions  5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   � $��0��6   $��0��6    K� ZIndex$ 1��6,   
�������$��50��6P   $
��Left=�6[   $��
5, 5, 0, 0q�6v    J� Opacity$	 0.7Q�5       .+�5!      �� $!��/Functional Images/back.png��6   $��5q�69   $
��Left=�6D    � Cursor$
 Hand��5"       J� InputBindings 5#      d� 5$       d� Gesture$ 	LeftClicka�6#    �� Command 67   �� *BackCommand+5&      5'      '  !Microsoft.Maps.MapControl.WPF.Map  5)   
   +  %Microsoft.Maps.MapControl.WPF.MapCore   Center<  6Microsoft.Maps.MapControl.WPF.Design.LocationConverter$ 40.409264, 49.867092 6I   	   	ZoomLevel$	 11Q�6g   
   Mode;  5Microsoft.Maps.MapControl.WPF.Design.MapModeConverter$
 AerialWithLabels 6v   $��7��5*      $��7��6!      CredentialsProvider 5)      �� *BingMapServices.Provider+   Children. 5,      3  -Microsoft.Maps.MapControl.WPF.MapItemsControl  ��6    �� *	Locations+��5.      �� 5/      .R�51      +  %Microsoft.Maps.MapControl.WPF.Pushpin  
���  ��   Location 6$   �� *
Coordinate+ � ToolTip 52      �� 53   "   .+�54   &   �� $��0, 10, 0, 0q�60   $��Center=�6^   $��SemiBold"�6{   $��15(�55   0   $
��Wrap=�6>   
���   ���54   E   �� *	Address+55   h   �� 57   &   $��30��60   
���  ��6O   �� 59   &   $	��350��6I   $	��180��6U   $
��Fill=�6b   ��6,   �� *	ImagePath+6s   �� 5;   &   $��17(�60   $��Center=�6>   $��0, 20, 0, 0q�6[   �� 5<   *   $�Telephone Number :��6.    �� 5=   *   
����  ��6.   �� *TelephoneNumber+6O   5>   '   �� 5@   &   $��17(�60   $��Center=�6>   �� 5A   *   $�
Web Site :��6.    �� 5B   *   
��� ��� �� TextDecorations$ 	Underline{�6W   �6.   �� *Site+6W   5C   '   5E   #   5G      5I      5L      5N      � 5P   
   $��0��6   $��5��6   $��2��6,   $ 1��6@   
���  ��$��70��6b   z�5Q      V� 5R      .~�5S      ��  �� Angle$ 45Q�6&   T� 5T       T� X$	 160Q�6)    T� Y$	 -60Q�61   5U      .+�5Y      �� $��60��6   
�������$��18(�68   $��Center=�6F   $
��Wrap=�5Z       �� Padding$ 5, 10, 5, 0q�6,   $��Center=�6C   �� 5[      $�Total Budget :��6    �� 5\      �6   �� *TotalBudget+ �� 5]      $�$��6   5^      5`      5b      5c      