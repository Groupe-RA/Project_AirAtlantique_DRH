   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5       AirAtlantique   AirAtlantique.Formations   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5      ���	#FF181818���	#FF00AADE$��1,1,1,1q�5   f   .��5      � $��0,0,0,0q�6   .+�5    
   �� -   5          ��Name$  ListFormations��5       $
��Left=�6*   $	��250��6E   $��533,122,0,0q�6R   $	��Top=�6g   $	��140��6   �� 5!   
   -   5         ��Name$ DeleteButton��5!      $��	Supprimer��6'   $
��Left=�6;   $��715,122,0,0q�6V   $	��Top=�6k   $	��100��6�   $��25��6�   6�   �� 5"   
   -   5        $ Ajouter��5"      $��Ajouter��6"   $
��Left=�64   $��204,386,0,0q�6O   $	��Top=�6d   $	��120��6|   $��31��6�   6�   �� 5#   
   -   5         ��Name$ NameBox��5#      $
��Left=�6#   $��21��6>   $��
84,126,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��183��6�   �� 5$   
   -   5        $	��←��5$       � ToolTip$ Retour menu��6   $
��Left=�63   $��	10,10,0,0q�6N   $	��Top=�6a   $��35��6y   $��35��6�   $��36(�6�   $��	1,-11,1,1q�6�   
���������6�   Z� 6�   �� 5%   
   $
��Left=�6   $��
100,10,0,0q�6/   $
��Wrap=�6C   $��Gérer les formations��6W   $	��Top=�6s   $��45��6�   $	��356��6�   $��34(�6�   ���	#FF00AADE6�   �� 5&   
   $��Ajouter une formation��6   $
��Left=�62   $��	62,68,0,0q�6M   $	��Top=�6`   $	��390��6x   $	��394��6�   
�������.��5'      �� -   5         ��Name$ result��5'      $��Center=�6(   $
��Wrap=�6E   $�� ��6Y   $��Bottom=�6a   $��0,0,0,0q�6|   5(      �� 5)   
   -   5        $  
ListPostes��5)       �� SelectionMode$ Multiple=�6&   $
��Left=�6?   $	��246��6Z   $��295,126,0,0q�6g   $	��Top=�6|   $	��129��6�   �� 5*   
   $
��Left=�6   $��295,102,0,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $��24��6p   $	��119��6|   
��������� 6�    � Language$ fr-fr�6�   $�Obligatoire pour��6�   6�   �� 5+   
   -   5        $ DescriptionBox��5+       �� AcceptsReturn . $
��Left=�6?   $	��127��6Z   $��
84,197,0,0q�6g   $
 Wrap=�6{   $	��Top=�6�   $	��183��6�   �� 5,   
   $
��Left=�6   $��
84,173,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��24��6o   $��77��6{   
��������� 6�   $ fr-fr�6�   $�Description��6�   6�   �� 5-   
   $
��Left=�6   $��
84,102,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��24��6o   $��77��6{   
��������� 6�   $ fr-fr�6�   $	�Nom��6�   6�   �� 5.   
   $��Supprimer une formation��6   $
��Left=�64   $��
498,68,0,0q�6O   $	��Top=�6c   $	��362��6{   $	��333��6�   
�������6�   $   Xceed.Wpf.Toolkit.SingleUpDown  5/   
   -	   5        	  Name$	 DurationBox��5/      $
��Left=�64   $��23��6O   $��164,349,0,0q�6[   ,   &Xceed.Wpf.Toolkit.Primitives.InputBase
   Text$
  ��6q   $	��Top=�6y   $��63��6�   ���	#FF181818���	#FF555555���	#FF838383 J� RenderTransformOrigin$ 0.444,0.435&�6�   ��50      �� 51       �� 
TargetType"  6    �� 	Resources 52      ��%    54      55      57      �� 58   
   $
��Left=�6   $��
84,352,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��24��6o   $��80��6{   
��������� 6�   $ fr-fr�6�   $�Durée validité��6�   6�   �� 59   
   $
��Left=�6   $��237,352,0,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $��24��6p   $	��120��6|   
��������� 6�   $ fr-fr�6�   $
�mois��6�   6�   5:      5;      