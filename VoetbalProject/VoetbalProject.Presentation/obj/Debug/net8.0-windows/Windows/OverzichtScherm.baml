   M S B A M L   `   `   `  ����V  RVoetbalProject.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:VoetbalProject.Presentation.Windows#VoetbalProject.Presentation.Windows  5   	   9    3VoetbalProject.Presentation.Windows.OverzichtScherm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:VoetbalProject.Presentation.Windows     5   	     � Title$  OverzichtScherm��5   	   $	��700��6!   $	��350��6.   $	��700��6:   $	��350��6K   .��5	      �  � RowDefinitions 5
   
   �� 5      $��7* �6   �� 5      $��8* �6   �� 5      $	��90* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   .+�5      �� -   5        $
��Home��5      
���"�"�$��0��6=   $��Verdana)�6M   $��0q�6b   
�������$��17(�6�   
 � Tag$ 
HomeScherm��6�   �� 5      $��	Overzicht��6   
���"�"�$��1��6B   $��Verdana)�6R   $��0q�6g   
���   �$��17(�6�   �� 5      -   5        $��Spelers��5      
���"�"�$��2��6@   $��Verdana)�6P   $��0q�6e   
�������$��17(�6�   $ SpelerScherm��6�   �� 5      -   5        $��Groepen��5      
���"�"�$��3��6@   $��Verdana)�6P   $��0q�6e   
�������$��17(�6�   $ GroepScherm��6�   5      � 5    
   $��1��6   
�������.+�5"      �� -   5        $��VerwijderButton��5"      ${�False��6,   $��Verwijder Training��6>   $��30,10,30,10q�6[   $��18(�6p   $��Verdana)�6~   
����������#E53935 � 	Resources 5#       �� 
TargetType �� Property �� Value��%_   '��       �� 5$      " ��6   .�5%      ��  �@��CornerRadius$ 10��69   5&      5'      5(      5)      � 5,   
   $��2��6   
������� 5-      �� 5.      $
��auto �6#   �� 5/      $��* �6#    52      �� 53      $��5* �6    �� 54      $	��95* �6    .+�57      �� $��0��6   $��0��6(   $��10,4,4,4q�65   $��Datum��6G   $��Verdana)�6T   $��16(�6i   $
��Bold"�6w   �� 58      $��1��6   $��0��6(   $��10,4,4,4q�65   $��Thema��6G   $��Verdana)�6T   $��16(�6i   $
��Bold"�6w   �� 5:      -   5        $��DatumScrollViewer��5:   8   $��0��6   $��1��6+   $��Hidden=�6Q   $��Hidden=�6v   .��5;      �� -   5        $��TrainingenDatumList��5;      $��0��66   $��1��6F   
�������$��Disabled=�6f    J� IsHitTestVisible$ False��6�   $��Disabled=�6�   ��5<      �� 5=      .R�5>      �� $��	2,10,2,10q�6I   $��Verdana)�6\   $��Center=�6q   $��Center=�6�   $��16(�6�   ��6$   �� *GeformatteerdeDatum+6�   5?      5A      5B      �� 5D      -   5        $��ThemaScrollViewer��5D   9   $��1��6   $��1��6,   $��Hidden=�6R   $��Hidden=�6w   .��5E      �� -   5        $��TrainingInfoList��5E      
�������$��Disabled=�6�   $��Disabled=�6�   ��5F      �� 5G      .R�5H      �� $��	5,10,2,10q�65   $��Verdana)�6H   $��Center=�6]   $��Center=�6z   $��16(�6�   ��6$   �� 6�   5I      5K      5L      5M      5P      5Q      