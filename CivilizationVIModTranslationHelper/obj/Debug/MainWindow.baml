   M S B A M L   `   `   `  ����]  YCivilizationVIModTranslationHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:CivilizationVIModTranslationHelper"CivilizationVIModTranslationHelper  5   	   3    -CivilizationVIModTranslationHelper.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:CivilizationVIModTranslationHelper     5   	     � Title$,  &Civilization VI Mod Translation Helper��5   	   $	��400��68   $	��800��6E   $
��1000��6Q   $	��500��6a    � WindowStartupLocation$ CenterScreen=�6q   ���	#B2FFFFFF.��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $	��200 �6   .+�5   
   �� -   5         ��Name$ textBoxLeft��5      ���	#7FFFFFFF �� SelectionBrush �	#7F0078D7���	#7F000000���	#E5000000$��0q�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   $�� ��6   �� 	UndoLimit$	 100��6
   �� MaxLines$
 1000��6  	 �� AcceptsReturn	 . $
��Left=�6?  $��14(�6a  $��0��6o  $��0��6|  $	��200��6�  $	��300��6�  $��30q�6�  �� 5   
   -   5        $ textBoxRight��5      ���	#7FFFFFFF �	#7F0078D7���	#7F000000���	#E5000000$��0q�6�   $
 Auto=�6�   $
 Auto=�6�   $�� ��6  $	 100��6  $
 1000��6  	 . $
��Left=�6A  $��14(�6c  $��0��6q  $��1��6~  $	��200��6�  $	��300��6�  $��30q�6�  � 5   
   $��2��6   
 � RowDefinitions
 5      �� 5      �� 5      $��60 �6    �� 5      $��60 �6    �� 5      $��60 �6    �� 5      $��30 �6    .+�5!      �� -   5        $ textBoxInfo��5!       �� 
IsReadOnly .  �� IsReadOnlyCaretVisible .  ���	#7FFFFFFF �	#7F0078D7���	#7F000000���	#E5000000$��0q�6�   $ Hidden=�6�   $ Hidden=�6�   $�� ��6  $
 1000��6  $
��Left=�6-  $��16(�6O  $��0��6]  $��0��6j  $	��100��6z  $��
20,30,20,7q�6�  �� 57      -   5        $��
Choose XML��57      ���	#59000000$��1q�6X   $��0q�6d   $��1��6x   $��32(�6�    � UseLayoutRounding . $��Center=�6�   $��Center=�6�   $��Mistral)�6�    � Cursor$
 Hand��6  ���	#FF898989$
��20,7q�6J  ��6*   Z� 6J  �� 58      -   5        $��Replace��58      ���	#59000000$��1q�6U   $��0q�6a   $��3��6u   $��32(�6�    . $��Center=�6�   $��Center=�6�   $��Mistral)�6�   $
 Hand��6  ���	#FF898989$
��20,7q�6D  ��6'   Z� 6D  �� 59      -   5        $	��Add��59      ���	#59000000$��1q�6Q   $��0q�6]   $��2��6q   $��32(�6~    . $��Center=�6�   $��Center=�6�   $��Mistral)�6�   $
 Hand��6   ���	#FF898989$
��20,7q�6<  ��6#   Z� 6<  5?      5F      5G      