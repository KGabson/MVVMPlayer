   M S B A M L   `   `   `  ����M  IWindowsMediaPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WindowsMediaPlayerWindowsMediaPlayer  5      #    WindowsMediaPlayer.PlayerView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:WindowsMediaPlayer     5      .��5
      � $��10q�6     � RowDefinitions  5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� ��6   �� *MediaElementObject+�� 5   
   $��1��6   .+�5      �� $��5q�6]   ��6   ��  �� Path$ 	MediaName� �� UpdateSourceTrigger$ PropertyChanged=�6]   � 5      $��Center=�6   .+�5      �� $��50��69   $��50��6D   
������ $��0q�6i   ��6   �� *prevCommand+.��5      �� $A��;C:\Users\user\Documents\GitHub\MVVMPlayer\Images\left36.png��6   $��50��6a   $
��auto��6l   5      �� 5      $��50��69   $��50��6D   
������ $��0q�6i   ��6   �� *playCommand+.��5      �� $A��;C:\Users\user\Documents\GitHub\MVVMPlayer\Images\play43.png��6   $��50��6a   $
��auto��6l   5      �� 5      $��50��6:   $��50��6E   
������ $��0q�6j   ��6   �� *pauseCommand+.��5      �� $B��<C:\Users\user\Documents\GitHub\MVVMPlayer\Images\pause15.png��6   $��50��6b   $
��auto��6m   5      �� 5      $��50��69   $��50��6D   
������ $��0q�6i   ��6   �� *stopCommand+.��5      �� $C��=C:\Users\user\Documents\GitHub\MVVMPlayer\Images\square64.png��6   $��50��6c   $
��auto��6n   5      �� 5      $��50��69   $��50��6D   
������ $��0q�6i   ��6   �� *playCommand+.��5       �� $A��;C:\Users\user\Documents\GitHub\MVVMPlayer\Images\play44.png��6   $��50��6a   $
��auto��6l   5!      �� 5"      $��50��6>   $��50��6I   
������ $��0q�6n   ��6   �� *loadMediaCommand+.��5#      �� $C��=C:\Users\user\Documents\GitHub\MVVMPlayer\Images\arrow468.png��6   $��50��6c   $
��auto��6n   5$      5%      5&      5'      5(      