   M S B A M L   `   `   `  ����V  RVoetbalProject.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:VoetbalProject.Presentation.Windows#VoetbalProject.Presentation.Windows  5   	   <    6VoetbalProject.Presentation.Windows.SpelerBewerkScherm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:VoetbalProject.Presentation.Windows     5   	     � Title$  SpelerBewerkScherm��5   	   $	��700��6%   $	��350��62   $	��700��6>   $	��350��6O   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      $��3* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��3* �6   .+�5   
   �� -   5        $��SpelerTitel��5   !   $��Speler��6   $��40(�64   $��Center=�6B   $��Center=�6]   $��	UltraBold"�6z   6�   �� 5   
   $��1��6   $��Voornaam��6   $��20(�60   $
��Bold"�6>   $��Center=�6P   6o   �� 5   
   -   5        $��VoornaamTextBox��5      $��2��6   $��10q�66   $��5q�6B   6P   �� 5   
   $��3��6   $��
Achternaam��6   $��20(�62   $
��Bold"�6@   $��Center=�6R   6q   �� 5   
   -   5        $��AchternaamTextBox��5      $��4��6   $��10q�68   $��5q�6D   6R   �� 5   
   $��5��6   $��	Rugnummer��6   $��20(�61   $
��Bold"�6?   $��Center=�6Q   6p   �� 5   
   -   5        $��RugNummerTextBox��5      $��6��6   $��10q�67   $��5q�6C   6Q   �� 5   
   -   5        $��SaveSpelerButton��5   -   $��7��6   $
��Save��6   $��10q�6E   
���"�"�
������� � 	Resources 5       �� 
TargetType �� Property �� Value��%_   '��       �� 5       " ��6   .�5!      ��  �@��CornerRadius$ 10��65   5"      5#      5$      �� 5&   
   -   5        $��8��5&      $��annuleer��6   $��10q�62   
���"�"�
������� 5'      ��%_   '��       �� 5(      " ��6   .�5)      ��  �@��CornerRadius$ 10��65   5*      5+      5,      5-      5.      