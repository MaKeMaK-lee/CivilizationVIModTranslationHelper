   M S B A M L   `   `   `  ����]  YCivilizationVIModTranslationHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:CivilizationVIModTranslationHelper"CivilizationVIModTranslationHelper  5   	   =    7CivilizationVIModTranslationHelper.LanguagePickerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:CivilizationVIModTranslationHelper     5   	     � WindowStyle$  
ToolWindow=�5       � Title$ LanguagePickerWindow��5   	   $	��200��6&   $	��200��63   $	��400��6?   $	��500��6N    � WindowStartupLocation$ CenterScreen=�6^   ���	#B2FFFFFF.��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��en_US��5      ���	#59000000$��1q�6O   $��0q�6[   $��0��6o   $��0��6|   $��50��6�   $��26(�6�    � UseLayoutRounding . $��Center=�6�   $��Verdana)�6�   $��Center=�6�    � Cursor$
 Hand��6  ���	#FF898989$��20,20q�6V  ��6!   Z� 6V  �� 5   
   -   5        $��ru_RU��5      ���	#59000000$��1q�6O   $��0q�6[   $��0��6o   $��1��6|   $��50��6�   $��26(�6�    . $��Center=�6�   $��Verdana)�6�   $��Center=�6�   $
 Hand��6  ���	#FF898989$��20,20q�6V  ��6!   Z� 6V  �� 5   
   -   5        $��
zh_Hans_CN��5      ���	#59000000$��1q�6T   $��0q�6`   $��1��6t   $��0��6�   $��50��6�   $��26(�6�    . $��Center=�6�   $��Verdana)�6�   $��Center=�6�   $
 Hand��6  ���	#FF898989$��20,20q�6[  ��6&   Z� 6[  �� 5   
   -   5        $��ko_KR��5      ���	#59000000$��1q�6O   $��0q�6[   $��1��6o   $��1��6|   $��50��6�   $��26(�6�    . $��Center=�6�   $��Verdana)�6�   $��Center=�6�   $
 Hand��6  ���	#FF898989$��20,20q�6V  ��6!   Z� 6V  �� 5   
   -   5        $��ja_JP��5      ���	#59000000$��1q�6O   $��0q�6[   $��2��6o   $��0��6|   $��50��6�   $��26(�6�    . $��Center=�6�   $��Verdana)�6�   $��Center=�6�   $
 Hand��6  ���	#FF898989$��20,20q�6V  ��6!   Z� 6V  � 5   
   $��2��6   $��1��6    5      �� 5      $�� * �6    �� 5      $�� * �6    .+�5      �� -   5         ��Name$ textBoxPickLang��5      ���	#7FFFFFFF �� SelectionBrush �	#7F0078D7���	#7F000000���	#E5000000$��0q�6�   "	 �� VerticalScrollBarVisibility$	 Hidden=�6�   $
 �� HorizontalScrollBarVisibility$

 Auto=�6�   $�� ��6�    �� 	UndoLimit$	 100��6�    �� MaxLines$ 1��6�    �� AcceptsReturn .  $��Center=�6!  $��12(�6E  $��0��6S  $��0��6`  $	��180��6p  $��36��6  $��
10,20,10,0q�6�  �� 5       -   5        $��*click*��5       ���	#59000000$��1q�6U   $��0q�6a   $��1��6u   $��0��6�   $��36��6�   $��26(�6�    . $��Center=�6�   $��Verdana)�6�   $��Center=�6�   $
 Hand��6   ���	#FF898989$��
10,0,10,20q�6]  ��6'   Z� 6]  5$      5%      5&      