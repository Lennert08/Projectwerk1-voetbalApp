   M S B A M L   `   `   `  ����V  RVoetbalProject.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:VoetbalProject.Presentation.Windows#VoetbalProject.Presentation.Windows  5   	   >    8VoetbalProject.Presentation.Windows.SpelerAanmakenScherm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:VoetbalProject.Presentation.Windows     5   	     � Title$  SpelerAanmakenScherm��5   	   $	��700��6&   $	��350��63   $	��700��6?   $	��350��6P   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      $��4* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��1* �6   �� 5      $��4* �6   .+�5   
   �� $��Nieuwe Speler��6   $��40(�6(   $��Center=�66   $��Center=�6Q   $��	UltraBold"�6n   6�   �� 5   
   $��1��6   $��Voornaam��6   $��20(�60   $
��Bold"�6>   $��Center=�6P   6o   �� 5   
   -   5        $��IngegevenVoornaam��5      $��2��6   $��10q�68   $��5q�6D    �� 	MaxLength$ 15��6P   6a   �� 5   
   $��3��6   $��
Achternaam��6   $��20(�62   $
��Bold"�6@   $��Center=�6R   6q   �� 5   
   -   5        $��IngegevenAchternaam��5      $��4��6   $��10q�6:   $��5q�6F   6T   �� 5   
   $��5��6   $��	Rugnummer��6   $��20(�61   $
��Bold"�6?   $��Center=�6Q   6p   �� 5   
   -   5        $��IngegevenRugnummer��5      $��6��6   $��10q�69   $��5q�6E   $ 2��6Q   6a   �� 5   
   -   5        $��
SaveSpeler��5   -   $��7��6   $
��Save��6   $��10q�6?   
���"�"�
������� � 	Resources 5       �� 
TargetType �� Property �� Value��%_   '��       �� 5      " ��6   .�5       ��  �@��CornerRadius$ 10��65   5!      5"      5#      5$      5%      