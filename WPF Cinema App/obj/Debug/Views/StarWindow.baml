   M S B A M L   `   `   `  ����I  EWPF Cinema App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WPF_Cinema_App.ViewsWPF_Cinema_App.Views  5   	   %    WPF_Cinema_App.Views.StarWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WPF_Cinema_App.Views     5   	     � Title$  
StarWindow��5   	   $	��300��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65    � WindowStyle$
 None=�6Z    � 
ResizeMode$ NoResize=�6m   .��5	      � ��5
   
   �� 5      ��5      �  � Color$ #00416A��6#    � Offset$	 0.3Q�63   � 5      $ #799F0C��6#   $	 0.7Q�63   � 5      $ #FFE000��6#   $ 1Q�63   5       � RowDefinitions 5   
   �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $	��30* �6   �� 5      $	��40* �6   �� 5      $	��30* �6   .+�5    
   � $��1��6   $��1��6   .+�5!      �  � Orientation$ 
Horizontal=�6   $��Center=�61   $��Center=�6N   .+�5"      �� -   5        	 ��Name$	 First��5"   P   $��48��69   $��48��6D   
 � Cursor$

 Hand��6_   ��6   �� *ImagePaths[0]+ J� InputBindings 5#      d� 5$       d� Gesture$ 	LeftClicka�6'    �� Command 6;   �� *OneLeftCommand+ �� CommandParameter 6^   ��  �� ElementName$ First�� �� Path$
 Name�d� 5%      $ LeftDoubleClicka�6'    6A   �� *TwoLeftCommand+ 6d   �� $ First��$
 Name�5'      �� 5)      -   5        $	 Second��5)   e   $��48��69   $��48��6D   $��7, 0, 0 , 0q�6P   $

 Hand��6u   ��6   �� *ImagePaths[1]+ 5*      d� 5+      $ 	LeftClicka�6'    6;   �� *OneLeftCommand+ 6^   �� $ Second��$
 Name�d� 5,      $ LeftDoubleClicka�6'    6A   �� *TwoLeftCommand+ 6d   �� $ Second��$
 Name�5.      �� 50      -   5        $	 Third��50   e   $��48��69   $��48��6D   $��7, 0, 0 , 0q�6P   $

 Hand��6t   ��6   �� *ImagePaths[2]+ 51      d� 52      $ 	LeftClicka�6'    6;   �� *OneLeftCommand+ 6^   �� $ Third��$
 Name�d� 53      $ LeftDoubleClicka�6'    6A   �� *TwoLeftCommand+ 6d   �� $ Third��$
 Name�55      �� 57      -   5        $	 Fourth��57   e   $��48��69   $��48��6D   $��7, 0, 0 , 0q�6P   $

 Hand��6u   ��6   �� *ImagePaths[3]+ 58      d� 59      $ 	LeftClicka�6'    6;   �� *OneLeftCommand+ 6^   �� $ Fourth��$
 Name�d� 5:      $ LeftDoubleClicka�6'    6A   �� *TwoLeftCommand+ 6d   �� $ Fourth��$
 Name�5<      �� 5>      -   5        $	 Fifth��5>   e   $��48��69   $��48��6D   $��7, 0, 0 , 0q�6P   $

 Hand��6t   ��6   �� *ImagePaths[4]+ 5?      d� 5@      $ 	LeftClicka�6'    6;   �� *OneLeftCommand+ 6^   �� $ Fifth��$
 Name�d� 5A      $ LeftDoubleClicka�6'    6A   �� *TwoLeftCommand+ 6d   �� $ Fifth��$
 Name�5C      5E      5F      �� 5H   
   $��2��6   $��0��6!   $��20(�61   $��Center=�6?   $��Center=�6\   $��DemiBold"�6w   
��������� 5J      $�Rating:��6    �� 5K      �6   �� *RatingNumber+5L      �� 5N   
   $��2��6   $��2��6      AddToCinemaButton#��[  6.   $
��Done��6Y   $��16q�6h   ��5O      �� *CloseWindowCommand+��68   ��  �� RelativeSource ��  �� AncestorType" �5Q      5R      