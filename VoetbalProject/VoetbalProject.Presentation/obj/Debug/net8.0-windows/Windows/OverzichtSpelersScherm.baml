   M S B A M L   `   `   `  ����V  RVoetbalProject.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:VoetbalProject.Presentation.Windows#VoetbalProject.Presentation.Windows  5   	   @    :VoetbalProject.Presentation.Windows.OverzichtSpelersScherm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:VoetbalProject.Presentation.Windows     5   	     � Title$  OverzichtSpelersScherm��5   	   $	��700��6(   $	��350��65   $	��700��6A   $	��350��6R   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      $��7* �6   �� 5      $��8* �6   �� 5      $��8 �6   �� 5      $
��auto �6   �� 5      $	��82* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   .+�5      �� -   5        $
��Home��5      
���"�"�$��0��6=   $��Verdana)�6M   $��0q�6b   
�������$��17(�6�   
 � Tag$ 
HomeScherm��6�   �� 5      -   5        $��	Overzicht��5      
���"�"�$��1��6B   $��Verdana)�6R   $��0q�6g   
���   �$��17(�6�   $ OverzichtScherm��6�   �� 5      -   5        $��Spelers��5      
���"�"�$��2��6@   $��Verdana)�6P   $��0q�6e   
�������$��17(�6�   $ SpelerScherm��6�   �� 5      -   5        $��Groepen��5      
���"�"�$��3��6@   $��Verdana)�6P   $��0q�6e   
�������$��17(�6�   $ GroepScherm��6�   5      � 5"   
   
�������$��1��6"   .+�5#      �� -   5        $��TrainingThemaTitel��5#      $��TrainingTitel��62   $��25(�6G   $
��Bold"�6U   $��Center=�6g   $��0,8,0,0q�6�   �� 5$      -   5        $��	DatumText��5$      $��Verdana)�6)   $��Datum��6>   $��Italic$�6K   $��3,3,7,3q�6^   $��Right=�6o   5%      �� 5'   
   $��2��6   $	��5,0q�6!   
���   �$��2��6A   �� 5)   
   -   5        $��VerwijderButton��5)      ${�False��6(   $��3��6:   $��Verwijder van Training��6G   $��11q�6h   $��18(�6t   $��Verdana)�6�   
����������#E53935 � 	Resources 5*       �� 
TargetType �� Property �� Value��%_   '��       �� 5+      " ��6   .�5,      ��  �@��CornerRadius$ 10��65   5-      5.      5/      � 52   
   $��4��6   
������� 53      �� 54      $��* �6#   �� 55      $
��auto �6#    58      �� 59      $��5* �6    �� 5:      $	��95* �6    .+�5=      �� $��0��6   $��0��6(   $��10,4,4,4q�65   $
��Naam��6G   $��Verdana)�6S   $��16(�6h   $
��Bold"�6v   �� 5>      $��1��6   $��0��6(   $��10,4,4,4q�65   $��Status��6G   $��Verdana)�6U   $��16(�6j   $
��Bold"�6x   �� 5@      -   5        $��NaamScrollViewer��5@   8   $��0��6   $��1��6+   $��Hidden=�6P   $��Hidden=�6u   .��5A      �� -	   5        $��
PlayerList��5A      $��20(�6,   $��0��6:   $��1��6J   
�������$��Disabled=�6j   ��5B      �� 5C      .R�5D      �� $��5q�6C   $��Verdana)�6N   $��Center=�6c   $��Center=�6�   $��14(�6�   ��6$   �� *Key.VolleNaam+6�   5E      5G      5H      �� 5K      -
   5        $��StatusScrollViewer��5K   8   $��1��6   $��1��6+   $��Hidden=�6R   $��Hidden=�6w   .��5L      �� -   5        $��AanwezigheidList��5L      $��20(�6.   $��1��6<   $��1��6L   
���������5M      �� 5N      .R�5O      �� $��3,5,3,5q�6;   $��Verdana)�6L   $��Center=�6a   $��Center=�6~   $��14(�6�   ��6$   �� *Value+6�   5P      5R      5S      5T      5W      5X      