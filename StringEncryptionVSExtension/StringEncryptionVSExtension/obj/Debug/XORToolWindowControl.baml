   M S B A M L   `   `   `  ����i  eMicrosoft.VisualStudio.Shell.15.0, Version=17.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3avUclr-namespace:Microsoft.VisualStudio.Shell;assembly=Microsoft.VisualStudio.Shell.15.0Microsoft.VisualStudio.Shell  5       StringEncryptionVSExtension6   0StringEncryptionVSExtension.XORToolWindowControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ivsshellUclr-namespace:Microsoft.VisualStudio.Shell;assembly=Microsoft.VisualStudio.Shell.15.0     5      -   5        $��MyToolWindow��5      ,   &Microsoft.VisualStudio.Shell.VsBrushes    	WindowKey#���   5         WindowTextKey#���  5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��String To Encrypt��6   
�������$��14(�6?   $
��Bold"�6M   $��Center=�6_   $��0��6|   $	��0,5q�6�   �� 5   
   -   5         ��Name$ 	stringEnc��5      $��1��6%   $	��300��62   $��30��6>   $��Center=�6J    �� TextWrapping$
 Wrap=�6g   $	��0,5q�6{   
�������$��1q�5   *   $��5q�6>   $��14(�6J   �� 5   
   $	��Key��6   
�������$��14(�61   $
��Bold"�6?   $��Center=�6Q   $��2��6n   $	��0,5q�6{   �� 5   
   -   5        $ keyBox��5      $��3��6"   $	��200��6/   $��30��6;   $��Center=�6G   $
 Wrap=�6d   $	��0,5q�6x   
�������$��1q�5   *   $��5q�6>   $��14(�6J   �� 5!   
   -   5        $��4��5!      $��Encrypt��6   $	��120��60   $��35��6<   ���#FFA500$��Center=�6]   $
��0,10q�6z   $��14(�6�   $
��Bold"�6�   6�   �� 5$   
   $��5��6    �� Orientation$ Vertical=�6"   $��10q�69   .+�5%      �� $��Plain Text Result��6   
�������$��14(�6C   $
��Bold"�6Q   $��Center=�6c   $	��0,5q�6�   �� 5&      -   5        $ plainTextBox��5&      $	��300��6,   $��50��68   $
 Wrap=�6D   $	��0,5q�6X   
�������$��1q�6}   $��5q�6�   $��14(�6�   �� 5(      $��
Hex Result��6   
�������$��14(�6<   $
��Bold"�6J   $��Center=�6\   $	��0,5q�6y   �� 5)      -   5        $ 	hexResult��5)      $	��300��6)   $��50��65   $
 Wrap=�6A   $	��0,5q�6U   
�������$��1q�6z   $��5q�6�   $��14(�6�   �� 5+      $��Decryption C++ Code��6   
�������$��14(�6E   $
��Bold"�6S   $��Center=�6e   $	��0,5q�6�   �� 5,      -   5         ��Name$
 code��5,      $	��300��6(   $	��330��64   $	��0,5q�6A   
�������$��1q�6f   $��5q�6z   $��14(�6�   $��Consolas)�6�   ���#2E2E2E
�������. �5-      /� .T�5.      J� .*�6    .*�5/      �� $� ��6   50      51      52      54      55      56      