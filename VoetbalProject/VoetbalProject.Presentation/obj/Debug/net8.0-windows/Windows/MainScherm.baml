   M S B A M L   `   `   `  ����V  RVoetbalProject.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:VoetbalProject.Presentation.Windows#VoetbalProject.Presentation.Windows  5   	   4    .VoetbalProject.Presentation.Windows.MainScherm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:VoetbalProject.Presentation.Windows     5   	     � Title$  
MainScherm��5   	   $	��700��6   $	��350��6)   $	��700��65   $	��350��6F   .��5	      �  � RowDefinitions 5
   
   �� 5      $��6.25* �6   �� 5      $��6.25* �6   �� 5      $��83.04* �6   �� 5      $��4.46* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $	��25* �6#   �� 5      $	��25* �6#   �� 5      $	��25* �6#   �� 5      $	��25* �6#   .+�5      �� -   5         ��Name$ 
HomeButton��5      $
��Home��6)   
���"�"�$��0��6Q   $��Verdana)�6a   $��0q�6v   
�������$��17(�6�   
 � Tag$ 
HomeScherm��6�   �� 5      -   5        $��	Overzicht��5      
���"�"�$��1��6B   $��Verdana)�6R   $��0q�6g   
�������$��17(�6�   $ OverzichtScherm��6�   �� 5      -   5        $��Spelers��5      
���"�"�$��2��6@   $��Verdana)�6P   $��0q�6e   
�������$��17(�6�   $ SpelerScherm��6�   �� 5      -   5        $��Groepen��5      
���"�"�$��3��6@   $��Verdana)�6P   $��0q�6e   
�������$��17(�6�   $ GroepScherm��6�   5      � 5"   
   
�������$��1��6"   .+�5#      �� -   5        $��	GroupName��5#   V   $	��U18��6   $��Verdana)�6#   $��Italic$�68   $��3q�6K   6V   �� 5$      -   5        $��	ThemaText��5$      $��Thema��6)   $��25(�66   $
��Bold"�6D   $��Center=�6V   $��0,8,0,0q�6s   �� 5%      -   5        $��	DatumText��5%      $��Verdana)�6)   $��Datum��6>   $��Italic$�6K   $��3,3,7,3q�6^   $��Right=�6o   5&      �� 5*   
   -   5        $��
PlayerList��5*      $��20(�6$   $��2��62   $��Disabled=�6?   $��Disabled=�6u   
���������5+      �� 5,      .R�5-      �  5.      �� 5/      $	��150 �6/   �� 50      $��1* �6/   .+�52      �� $��5,10,0,0q�65   $��0��6G   $��Verdana)�6X   $��15(�6m   ��6$   �� 6m   �� 53       �� Orientation$ Vertical=�6%   $��	10,10,0,0q�6<   $��1��6O   .+�54      	� -	   5        $��Aanwezig��54   *   $��5q�6V   $��15(�6a    d� 	IsChecked$
 TrueY�6o   $��Verdana)�6�   
���"�"� 	� 	GroupName 6=   �� *Id+6�   	� 55      -
   5        $��Afwezig��55   *   $��5q�6U   $��15(�6`   $��Verdana)�6�   
���  �� 6<   �� *Id+6�   56      57      58      5:      �� 5<   
   -   5        $��3��5<      $��Opslaan��6   $��15(�60   
���"�"�
�������6j   5=      5>      