   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:HRMS.Login
HRMS.Login  5          HRMS.Login.Window1   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      $localclr-namespace:HRMS.Login  5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      -   5          �Name$  LoginWindow��5
       � Title$ 
MainWindow��5      $	��380��5      $	��450��5       � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�5       � WindowStyle$
 None=�5      .��5      � -   5        .+�5   
   �  � RowDefinitions 5      �� 5      �� 5      .+�5      �� $��2��5      
�������$��3q�5!       �� CornerRadius$ 8��5"      ��5$      �� 5%      .��5&      �  � Offset$	 0.0Q�6'    � Color$ #7be9f6��64   � 5'      $ 1Q�6'   $ #f083da��62   5(      5*      �� 5:      $��Center=�6   .+�5<      �� $	��120��5=      $	��200��5>      $��champagn.png��5?      �� 5@      $��0,-20q�5A      $��Center=�5B      $��	helvetica)�5C      $��22(�5D      $��Light"�5E      
�������$��Human Resource��5G      5H      �� 5K      $��1��6   .+�5M      �� $��1��6   	 �� Orientation$	 
Horizontal=�6*   .+�5O      �� $	��235��5P      $��63,0,0,0q�5Q      $��Center=�5R      $��Center=�5S      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$

 User��5T      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 ���� 
������ $��0q�5W      $��	Helvetica)�5X      $��20(�5Y      $��Light"�5Z      
������� J� Opacity$	 0.7Q�5\      ��5]      �� *
Username+'  !MaterialDesignThemes.Wpf.PackIcon  5_      $��Center=�5`      $��Center=�5a      
�������   Kind$
 User=�5c      5d      �� 5f      $	��250��5g      $��2��5h      
�������$	 0.5Q�5j      �� 5m      $��1��5n      $��0,20,0,0q�5o      $	 
Horizontal=�5p      .+�5r      G� -   5         G�Name$ passwordBox��5s      $	��235��5t      $��63,0,0,0q�5u      $��Center=�5v      $��Center=�5w      $
 Password��5x      
 ���� 
������ $��0q�5{      $��	Helvetica)�5|      $��20(�5}      $��Light"�5~      
�������$	 0.7Q�5�      .  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ PasswordChanged��6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�   "   6  0System.Windows.Interactivity.InvokeCommandAction     Command 68   �� *PasswordChangedCommand+   CommandParameter 6c   ��  �� ElementName$ passwordBox��5�      5�        5�      $��Center=�5�      $��Center=�5�      
�������$ Password=�5�      5�      �� 5�      $	��250��5�      $��2��5�      
�������$	 0.5Q�5�      �� 5�      $��0,50,0,0q�6   $	 
Horizontal=�6/   .+�5�      �� $	��100��5�      $��40��5�      $��	60,0,60,0q�5�      $��LOGIN��5�       �� 	IsDefault .    NormalButton#��[  5�      ��5�      �� *LoginCommand+��5�      �� $ LoginWindow��5�      �� 5�      $	��100��5�      $��40��5�      $��CANCEL��5�      #��[  5�      ��5�      �� *CloseCommand+��5�      �� $ LoginWindow��5�      5�      5�      5�      5�      5�      