   M S B A M L   `   `   `  ����I  EWPF Cinema App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF_Cinema_App.Views.UserControls!WPF_Cinema_App.Views.UserControls  5      6    0WPF_Cinema_App.Views.UserControls.AdminLoginView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:WPF_Cinema_App.Views.UserControls     5      .��5	      �   � RowDefinitions  5   
   �� 5      $	��15* �6   �� 5      $	��80* �6   �� 5      $	��15* �6   .+�5   
   � $��0��6    K� ZIndex$ 1��6   $��40��6-   $��40��68   $
��Left=�6D   .+�5      �� $-��'/Functional Images/white left arrow.png��6   $
��Left=�6E    � Cursor$
 Hand��6`   $��40��6n   $��40��6y   $
��Fill=�6�    J� InputBindings 5      d� 5       d� Gesture$ 	LeftClicka�6#    �� Command 67   �� *BackCommand+5      5      �� 5   
   $��/Images/maldive.jpg��6   $��3��6-   $
��Fill=�6>    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 15Q�6   5      � 5    
   $��1��6     5"      �� 5#      $	��20* �6    �� 5$      $	��60* �6    �� 5%      $	��20* �6    .+�5(      �� $��0��6   $��30(�6%   
�������$��Center=�6F   $��Center=�6c   $��Verdana)�5)      $��0, 0, 10, 0q�6-   Login6I   � 5+      $��1��6     5,      �� 5-      �� 5.      �� 5/      �� 50      .+�53      �� $��0��6   $��Username : ��6)   
�������$��20(�6O   $��Center=�6]   $��Center=�6z   $
��Bold"�54      
���   � �� Padding$ 5q�6A   	 J� Opacity$		 0.6Q�6M   � 56      $��1��6   
 � ColumnDefinitions
 57      �� 58      �� 59      �� 5:      .+�5=      �� $��1��6    �� CornerRadius$ 5��6-   ���#A2D729$��6q�6T   ._�5>      �� $��0q�6"    �� TextWrapping$
 Wrap=�66   $��18(�6J   $��5, 10, 0 ,0q�6X   ��5?   "   �� *
Username+ �� Mode$ TwoWay=�5@      5B      �� 5D      $��2��6   $��Password : ��6)   
�������$��20(�6O   $��Center=�6]   $��Center=�6z   $
��Bold"�5E      
���   �$		 0.6Q�6A   $ 5q�6O   � 5G      $��3��6   
 5H      �� 5I      �� 5J      �� 5K      .+�5N      �� $��1��6   $ 5��6-   ���#A2D729$��6q�6T   ._�5O      G� -   5         G�Name$ PsswrdBxPassword��5O   ^   $��0q�6&   $��18(�6:   $��5, 10, 0 ,0q�6H   6^   5P      5R      5U      5W      � 5Y   
   $��2��6   
 5Z      �� 5[      �� 5\      �� 5]      �� 5^      .+�5a      �� $��3��6   $��Submit��6%      SubmitButton#��[  66   ��6\   �� *SubmitCommand+��5b      ��  �� ElementName$ PsswrdBxPassword��5d      5f      5g      