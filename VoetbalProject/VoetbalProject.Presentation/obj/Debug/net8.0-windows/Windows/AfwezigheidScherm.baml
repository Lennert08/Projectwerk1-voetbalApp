   M S B A M L   `   `   `  ����V  RVoetbalProject.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:VoetbalProject.Presentation.Windows#VoetbalProject.Presentation.Windows  5   	   ;    5VoetbalProject.Presentation.Windows.AfwezigheidScherm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:VoetbalProject.Presentation.Windows     5   	     � Title$  AfwezigheidScherm��5   	   $	��700��6#   $	��350��60   $	��700��6<   $	��700��6L   $	��350��6\   $	��350��6k   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      $	��10* �6   �� 5      $	��90* �6   �� 5      $	��10* �6   .+�5   
   �� $��3q�6   
���2�2�._�5      �� -   5        $��SelectedPlayerText��5      $��Geselecteerde Speler��62   $��Center=�6N   $��30(�6k   $��50��6y   $
��Bold"�6�   5      �� 5   
   -   5        $��Afwezigheiden��5      $��30(�6'   
�������$��0,0,0,0q�6H   $��1��6Y   .@�5      �  5      �� 5      $
��auto �6$   �� 5      $	��20* �6$   �� 5      $	��20* �6$   �� 5      $	��20* �6$   �� 5      $	��20* �6$   �� 5      $	��20* �6$   �� 5      $
��auto �6$   .+�5       �� -   5        $��AanwezigTextBlock��5       $��0��65   $��	0,15,0,35q�6B   $y�	Collapsed=�6U   
Aanwezig6x   	� 5!      -   5        $��AanwezigRadioButton��5!       	� 	GroupName$ 1��69   $��Center=�6G   $��0��6b   $��300,15,0,35q�6o   
 � Tag$ Aanwezig��6�   $y�	Collapsed=�6�   �� 5#      $��1��6   $��	0,15,0,35q�6)   
Geen reden6J   	� 5$      -   5        $ 1��5$      $��Center=�6,   $��1��6G   $��300,15,0,35q�6T   $ 
Geen Reden��6�   �� 5&      $��2��6   $��0,7,0,35q�6)   Ziekte6E   	� 5'      -   5        $ 1��5'      $��Center=�6,   $��2��6G   $��
300,0,0,35q�6T   $ Ziekte��6�   �� 5)      $��3��6   $��0,7,0,35q�6*   
Blessure6F   	� 5*      -   5        $ 1��5*      $��3��6,   $��Center=�69   $��
300,0,0,35q�6U   $ Blessure��6�   �� 5,      $��4��6   $��0,7,0,35q�6)   Dokter Afspraak6L   	� 5-      -   5        $ 1��5-      $��4��6,   $��Center=�69   $��
300,0,0,35q�6U   $ Dokter Afspraak��6�   �� 5/      $��5��6   $��0,7,0,10q�6)   	Overige6D   	� 50      -	   5        $ 1��50      $��5��6-   $��Center=�6:   $��
300,0,0,35q�6V   6j   �� 51      -
   5        $��OtherTextBox��51      $��6��6.   $	��135��6;   $��25(�6H   $	��320��6V    �� AcceptsReturn$
 True��6e   ${�False��6z    �� 	MaxLength$ 15��6�   52      54      �� 55   
   -   5        $��
SaveButton��55      $
��Save��6#   $��2��62   
���2�2�
�������$��15(�6i   ${�False��6w   6�   56      57      