   M S B A M L   `   `   `  ����  SolstatProjectUI.    (SolstatProjectUI.Pages.arrays.arraysPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  5      .��5	      �    ContentRoot#��[  6   .+�5
   
   �� -   5          ��Name$  groupBox��5
      $��GroupBox��6%   $
��Left=�67   $��	10,10,0,0q�6R   $	��Top=�6e   $	��353��6}   $	��663��6�   .��5      �� -   5         ��Name$ componentList��5      $
��Left=�6.   $��10,10,0,69.2q�6I   $	��611��6_    �� View 5      �� 5      .P�5      �� $��ID��6)    �� Width$ 40��6Y    �� DisplayMemberBinding 65   �� *id+6Y   �� 5      $
��Name��6)   $	 140��6]    67   �� *name+6]   �� 5      $��Price��6)   $ 40��6_    68   �� *price+6_   �� 5      $��Cantidad��6)   $	 300��6;    �� CellTemplate 5      �� 5   "   .R�5   &   ]� $��Center=�60   $��10q�6K   .+�5   *   �� $��Right=�6�    �� TextAlignment$ Right=�6�   $��40��6�   ��62   ��  �� ElementName$ quantitySlider�� �� Path$ Value�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5   *   
 ��Name$
 quantitySlider��62   -   5         � Maximum$	 150Q�5   e    �� TickPlacement$ BottomRight=�6s    �� TickFrequency$ 5Q�6�    �� IsSnapToTickEnabled .  � Value 6J   �� *
quantity+6�   5   '   5   #   5      5      5      5      �� 5   
   -   5         ��Name$ calculateBtn��5      $��Calcular��6'   $#��mui:LinkCommands.NavigateLink��6:   $!��/Pages/costs/costsPage.xaml��6b   $
��Left=�6�   $��643,431,0,0q�6�   $	��Top=�6�   $	��139��6�   $��35��6�   6�   �� 5    
   -   5         ��Name$ 
totalLabel��5       $��TOTAL:��6$   $
��Left=�65   $��190,439,0,0q�6P   $	��Top=�6e   $��27��6}   $��41��6�   �� 5!   
   -   5         ��Name$ totalBox��5!      $
��0.00��6$   {�.  $
��Left=�6B   $��23��6]   $��236,437,0,0q�6i    �� TextWrapping$
 Wrap=�6~   $	��Top=�6�   $	��166��6�   5"      5#      