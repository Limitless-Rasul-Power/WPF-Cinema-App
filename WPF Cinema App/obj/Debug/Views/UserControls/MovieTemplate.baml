   M S B A M L   `   `   `  ����I  EWPF Cinema App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF_Cinema_App.Views.UserControls!WPF_Cinema_App.Views.UserControls  5      5    /WPF_Cinema_App.Views.UserControls.MovieTemplate   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:WPF_Cinema_App.Views.UserControls     5      .��5	      �� 
�������$��4q�6"     �� CornerRadius$  10��66   ._�5
   
   � 
�������$��2q�6"    � RowDefinitions 5      �� 5      $	��12* �6    �� 5      $	��65* �6    �� 5      $��8* �6    �� 5      $	��15* �6    .+�5      �� $��0��6   $��20(�6%   $��Center=�63   $��Center=�6P   $
��Wrap=�5      ��5   k   �� *%#Movie.TitleAndImdbRatingCombination+5      �� 5      $��1��6   $
��Fill=�6A    � Cursor$
 Hand��6P    � ToolTip$ Watch Trailer��6^   ��6!   �� *Movie.Poster+ J� InputBindings 5      d� 5       d� Gesture$ 	LeftClicka�6#    �� Command 67   �� *ImageMouseLeftCommand+5      �� 5      $��2��6   $��20(�6%   $��Center=�63   $��Center=�6P   $��SemiBold"�5      
���z���$
��Wrap=�6_   ��6B   �� *Movie.Genre+6u   � 5      $��3��6    � ColumnDefinitions 5       �� 5!      $	��80* �6'   �� 5"      $	��10* �6'   �� 5#      $	��10* �6'   .+�5&      �� $��Disabled=�6   $
��Auto=�6H   .��5'      �� $��18(�6    $��DemiBold"�6.   $��Italic$�6D    �� Padding$ 10, 10, 0, 0q�6W   $
��Wrap=�6n   ��6�   �� *
Movie.Plot+5(      �� 5*      $��1��6   $��18(�6,   $��Right=�6:   $��Center=�6W   
���   �$��Verdana)�6�   $��	ExtraBold"�5+      $
��Wrap=�63   ��6G   �� *Movie.LikeCount+�� 5-      $��2��6      
LikeButton#��[  6)   $��55��6M   $��55��6X   ��6d   �� *LikeCommand+.��5.      �� $!��/Functional Images/like.png��6   6C   5/      52      54      55      56      