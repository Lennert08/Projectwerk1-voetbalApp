   M S B A M L   `   `   `  ����V  RVoetbalProject.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:VoetbalProject.Presentation.Windows#VoetbalProject.Presentation.Windows  5   	   4    .VoetbalProject.Presentation.Windows.HomeScherm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:VoetbalProject.Presentation.Windows     5   	     � Title$  
HomeScherm��5   	   $	��700��6   $	��350��6)   $	��700��65   $	��350��6F   
�������.��5	      � 
������� � RowDefinitions 5
   
   �� 5      $��7* �6   �� 5      $	��98* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   .+�5      �� $
��Home��6   
���"�"�$��0��6=   $��Verdana)�6M   $��0q�6b   
���   �$��17(�6�   
 � Tag$ 
HomeWindow��6�   �� 5      -   5        $��	Overzicht��5      
���"�"�$��1��6B   $��Verdana)�6R   $��0q�6g   
�������$��17(�6�   $ OverzichtScherm��6�   �� 5      -   5        $��Spelers��5      
���"�"�$��2��6@   $��Verdana)�6P   $��0q�6e   
�������$��17(�6�   $ SpelerScherm��6�   �� 5      -   5        $��Groepen��5      
���"�"�$��3��6@   $��Verdana)�6P   $��0q�6e   
�������$��17(�6�   $ GroepScherm��6�   5      � 5   
   $��1��6    5       �� 5!      $
��auto �6    �� 5"      $��2* �6    �� 5#      $
��1.1* �6    �� 5$      $��2* �6    �� 5%      $
��1.1* �6    �� 5&      $��2* �6    �� 5'      $
��1.1* �6    .+�5+      �� -   5        $��
groeplabel��5+      $��0��6'   $��CurrentGroep��64   $��Right=�6K   �� 5-      -   5        $��1��5-      $��Center=�6?   
�������$��0q�6o   $ DatumTrainingScherm��6�   .��5.      �� $��5��6   $��Images/TrainingImage.png��6%   $	��125��6G   5/      �� 51      -   5         ��Name$ TrainingButton��51      $��Training aanmaken��6-   $��2��6I   $	��190��6V   $ DatumTrainingScherm��6   $��Verdana)�6�   
�������
���"�"�$��0 0 0 10q�6�    � 	Resources 52       �� 
TargetType �� Property �� Value��%_   '��       �� 53      " ��6   .�54      ��  �@��CornerRadius$ 10��69   55      56      57      �� 59      -   5        $��3��59      $��Center=�6?   
�������$��0q�6o   $ SpelerAanmakenScherm��6�   .��5:      �� $��3��6   $��Images/AddPlayerImage.png��6%   $	��125��6H   5;      �� 5<      -   5        $ CreateButton��5<      $��Speler aanmaken��6+   $��4��6E   $	��190��6R   $ SpelerAanmakenScherm��6{   $��Verdana)�6�   
�������
���"�"�$��0 0 0 10q�6�    5=      ��%_   '��       �� 5>      " ��6   .�5?      ��  �@��CornerRadius$ 10��69   5@      5A      5B      �� 5D      -	   5        $��5��5D      $��Center=�6B   
�������$��0q�6r   $ TrainingWindow��6�   .��5E      �� $��5��6   $��Images/ExcelImage.png��6%   $	��125��6D   5F      �� 5I      -
   5        $ Export��5I      $��Export��6%   $��6��66   $	��190��6C   $��0 0 0 10q�6O   $��Verdana)�6b   
�������
���"�"� 5J      ��%_   '��       �� 5K      " ��6   .�5L      ��  �@��CornerRadius$ 10��69   5M      5N      5O      5P      5Q      5R      