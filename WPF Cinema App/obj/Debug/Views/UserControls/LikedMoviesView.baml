   M S B A M L   `   `   `  ����I  EWPF Cinema App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF_Cinema_App.Views.UserControls!WPF_Cinema_App.Views.UserControls  5      7    1WPF_Cinema_App.Views.UserControls.LikedMoviesView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:WPF_Cinema_App.Views.UserControls     5      .��5	      � 
�������.+�5   
   �� -   5          ��Name$  
LstVwFirst��5      $��20(�5   2   $��Disabled=�6@   ��6   �� *Movies+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ Stretch=�6C   6U   5      ��5      �� 5      .R�5      �  � Orientation$ Vertical=�6    69   5       �� View 5      �� 5      .P�5      �� $��Movie Image��6%    �� Width$	 240��6:    �� CellTemplate 5       �� 5!      .R�5"   "   �� $
��Fill=�6(   ��67   �� *Poster+5#      5%      �� 5'      $��Movie Title��6%   $	 190��6:    5(      �� 5)      .R�5*   "   �� $��20(�6[   $
��Wrap=�6i    �� TextAlignment$ Center=�6}   ��6,   �� *TitleAndImdbRatingCombination+6}   5+      5-      �� 5/      $��Movie Genre��6%   $	 190��6:    50      �� 51      .R�52   "   �� $��20(�6C   $
��Wrap=�6Q   $ Center=�6e   ��6,   �� *Genre+6e   53      55      �� 57      $��
Like Count��6%   $	 190��69    58      �� 59      .R�5:   "   �� $��20(�6G   $
��Wrap=�6U   $ Center=�6i   
���  ��$
��Bold"�5;   =   ��5:   ,   �� *	LikeCount+5;   =   5<      5>      �� 5@      $��
Put Cinema��6%   $	 190��69    5A      �� 5B      .R�5C   "   �� $��Add to Cinema��6�      AddToCinemaButton#��[  5D   )   $��50��6T   ��5C   )   �� 	 �� ElementName$	 
LstVwFirst��
 �� Path$)
 #DataContext.PutMovieToCinemaCommand���6~   �� 5D   T   5E      5G      5J      5N      5P      5Q      