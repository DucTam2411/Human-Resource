   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HRMS.Employee.uConHRMS.Employee.uCon  5      A%clr-namespace:HRMS.Director.ViewModelHRMS.Director.ViewModel  5	      '    !HRMS.Employee.uCon.EmployeeWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      .userCon clr-namespace:HRMS.Employee.uCon  5      6
viewmodel1%clr-namespace:HRMS.Director.ViewModel  5	      -   5          �Name$  Employee_Window��5
       � Title$ HR_EmployeeWindow��5      $
��1124��5      $	��620��5       � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��2��5      $��0,2,0,-2q�5      
���   �$��8q�5        �� CornerRadius$ 30��5!      ��5#      �� 5$       �� Color$ White��6"   5&      �� 5'   
   $	��220��5(      $	��170��5)      $��	15,0,15,0q�5*      .+�5,      � 	 � RowDefinitions	 5-      �� 5.      �� 5/      �� 50      .+�55      � -   5        
 �Name$
 
GridCursor��56      $	��230��57      $��50��58      $��0,0,0,0q�59      $
��Left=�5:      
������ 5;      �� 5=      $��0��5>      $	��220��5?      $��50��5@      $��0,5,0,0q�5A      $
��Left=�5B      $
��Left=�5C      $��0q�5E      ��5D      �� *BACKGROUNDINFORMATION+��5F      �� *InformationCommand+.��5H      ��  �� Orientation$ 
Horizontal=�6!   .+�5I      '  !MaterialDesignThemes.Wpf.PackIcon  ��62   �� *FOREGROUNDINFORMATION+   Kind 6_   �� *INFORMATIONTAB.ICONKIND+�� 5J      $��8,-4,0,0q�5K      $��	Tw Cen MT)�5L      $��22(�5M      $��SemiBold"�5N      ��5O      �� *FOREGROUNDINFORMATION+��5P      �� *INFORMATIONTAB.TEXTBLOCKNAME+5Q      5S      �� 5U      $��1��5V      $	��220��5W      $��50��5X      $��0,5,0,0q�5Y      $
��Left=�5Z      $
��Left=�5[      $��0q�5]      ��5\      �� *BACKGROUNDSALARYINFO+��5^      �� *SalaryInfoCommand+.��5`      �� $ 
Horizontal=�6!   .+�5a        ��62   �� *FOREGROUNDSALARYINFO+ 6^   �� *SALARYINFOTAB.ICONKIND+�� 5b      $��8,-4,0,0q�5c      $��	Tw Cen MT)�5d      $��22(�5e      $��SemiBold"�5f      ��5g      �� *FOREGROUNDSALARYINFO+��5h      �� *SALARYINFOTAB.TEXTBLOCKNAME+5i      5j      �� 5k      $��2��5l      $	��220��5m      $��50��5n      $��0,5,0,0q�5o      $
��Left=�5p      $
��Left=�5q      $��0q�5s      ��5r      �� *BACKGROUNDTIMEKEEPING+��5t      �� *TimekeepingCommand+.��5u      �� $ 
Horizontal=�6!   .+�5v        ��62   �� *FOREGROUNDTIMEKEEPING+ 6_   �� *TIMEKEEPINGTAB.ICONKIND+�� 5w      $��8,-4,0,0q�5x      $��	Tw Cen MT)�5y      $��22(�5z      $��SemiBold"�5{      ��5|      �� *FOREGROUNDTIMEKEEPING+��5}      �� *TIMEKEEPINGTAB.TEXTBLOCKNAME+5~      5      5�      5�      ]� 5�   
   $��1��6   .+�5�      �� $
��Left=�6@   ��6   �� *CONTENTCONTROL+6@   5�      �� 5�   
   $	��230��5�      $��50��5�      $��10,100q�5�      $��Bottom=�5�      $ 
Horizontal=�5�      .+�5�      �� $	��100��5�      $��50��5�      $��10,0,0,0q�5�      $��Morning��5�      ��5�      �� *MorningCommand+5�      �� 5�      $	��100��5�      $��50��5�      $��10,0,0,0q�5�      $��	Afternoon��5�      ��5�      �� *AfternoonCommand+5�      5�      �� 5�   
   $	��200��5�      $��50��5�      $��10,20q�5�      $��Bottom=�5�      ��5�      �� *ExitCommand+��5�      ��  �� ElementName$ Employee_Window��.��5�        $��40��5�      $��30��5�      
�������$ 	ExitToApp=�5�       J� RenderTransformOrigin$ 0.46,-0.343&�5�      5�      5�      5�      