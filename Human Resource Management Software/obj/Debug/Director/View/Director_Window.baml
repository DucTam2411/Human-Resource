   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HRMS.Director.ViewHRMS.Director.View  5      5clr-namespace:HRMS.HR.ViewModelHRMS.HR.ViewModel  5	      A%clr-namespace:HRMS.Director.ViewModelHRMS.Director.ViewModel  5
      (    "HRMS.Director.View.Director_Window   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:HRMS.Director.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      /	viewmodelclr-namespace:HRMS.HR.ViewModel  5	      6
viewmodel1%clr-namespace:HRMS.Director.ViewModel  5
      -   5          �Name$  DirectorWindow��5       � Title$ HR_EmployeeWindow��5      $
��1124��5      $	��620��5       � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��2��5      $��0,2,0,-2q�5      
���   �$��8q�5!       �� CornerRadius$ 30��5"      ��5$      �� 5%       �� Color$ White��6"   5'      �� 5(   
   $	��200��5)      $	��280��5*      $��	15,0,15,0q�5+      .+�5-      � 	 � RowDefinitions	 5.      �� 5/      �� 50      �� 51      �� 52      �� 53      .+�58      � -   5        
 �Name$
 
GridCursor��59      $	��230��5:      $��50��5;      $��0,0,0,0q�5<      $
��Left=�5=      
������ 5>      �� 5@      $��0��5A      $	��230��5B      $��50��5C      $��0,5,0,0q�5D      $
��Left=�5E      $
��Left=�5F      $��0q�5H      ��5G      �� *BACKGROUNDINFORMATION+��5I      �� *InformationCommand+.��5K      ��  �� Orientation$ 
Horizontal=�6!   .+�5L      '  !MaterialDesignThemes.Wpf.PackIcon  ��62   �� *FOREGROUNDINFORMATION+   Kind 6_   �� *INFORMATIONTAB.ICONKIND+�� 5M      $��8,-4,0,0q�5N      $��	Tw Cen MT)�5O      $��22(�5P      $��SemiBold"�5Q      ��5R      �� *FOREGROUNDINFORMATION+��5S      �� *INFORMATIONTAB.TEXTBLOCKNAME+5T      5V      �� 5X      $��1��5Y      $	��230��5Z      $��50��5[      $��0,5,0,0q�5\      $
��Left=�5]      $
��Left=�5^      $��0q�5`      ��5_      �� *BACKGROUNDSALARYINFO+��5a      �� *SalaryInfoCommand+.��5c      �� $ 
Horizontal=�6!   .+�5d        ��62   �� *FOREGROUNDSALARYINFO+ 6^   �� *SALARYINFOTAB.ICONKIND+�� 5e      $��8,-4,0,0q�5f      $��	Tw Cen MT)�5g      $��22(�5h      $��SemiBold"�5i      ��5j      �� *FOREGROUNDSALARYINFO+��5k      �� *SALARYINFOTAB.TEXTBLOCKNAME+5l      5m      �� 5n      $��2��5o      $	��200��5p      $��50��5q      $��0,5,0,0q�5r      $
��Left=�5s      $
��Left=�5t      $��0q�5v      ��5u      �� *BACKGROUNDTIMEKEEPING+��5w      �� *TimekeepingCommand+.��5x      �� $ 
Horizontal=�6!   .+�5y        ��62   �� *FOREGROUNDTIMEKEEPING+ 6_   �� *TIMEKEEPINGTAB.ICONKIND+�� 5z      $��8,-4,0,0q�5{      $��	Tw Cen MT)�5|      $��22(�5}      $��SemiBold"�5~      ��5      �� *FOREGROUNDTIMEKEEPING+��5�      �� *TIMEKEEPINGTAB.TEXTBLOCKNAME+5�      5�      �� 5�      $��3��5�      $	��230��5�      $��50��5�      $��0,5,0,0q�5�      $
��Left=�5�      $
��Left=�5�      $��0q�5�      ��5�      �� *BACKGROUNDHRREPORT+��5�      �� *HRReportCommand+.��5�      �� $ 
Horizontal=�6!   .+�5�        ��62   �� *FOREGROUNDHRREPORT+ 6\   �� *HRREPORTTAB.ICONKIND+�� 5�      $��8,-4,0,0q�5�      $��	Tw Cen MT)�5�      $��22(�5�      $��SemiBold"�5�      ��5�      �� *FOREGROUNDHRREPORT+��5�      �� *HRREPORTTAB.TEXTBLOCKNAME+5�      5�      �� 5�      $��4��5�      $	��230��5�      $��50��5�      $��0,5,0,0q�5�      $
��Left=�5�      $
��Left=�5�      $��0q�5�      ��5�      �� *BACKGROUNDACCOUNTINGREPORT+��5�      �� *AccountingReportCommand+.��5�      �� $ 
Horizontal=�6!   .+�5�        ��62   �� *FOREGROUNDACCOUNTINGREPORT+ 6d   �� *ACCOUNTINGREPORTTAB.ICONKIND+�� 5�      $��8,-4,0,0q�5�      $��	Tw Cen MT)�5�      $��22(�5�      $��SemiBold"�5�      ��5�      �� *FOREGROUNDACCOUNTINGREPORT+��5�      �� *#!ACCOUNTINGREPORTTAB.TEXTBLOCKNAME+5�      5�      5�      5�      ]� 5�   
   $��1��6   .+�5�      �� $
��Left=�6@   ��6   �� *CONTENTCONTROL+6@   5�      �� 5�   
   $	��230��5�      $��50��5�      $��10,90q�5�      $��Bottom=�5�      $ 
Horizontal=�5�      .+�5�      �� $	��100��5�      $��50��5�      $��10,0,0,0q�5�      $��Morning��5�      ��5�      �� *MorningCommand+5�      �� 5�      $	��100��5�      $��50��5�      $��10,0,0,0q�5�      $��	Afternoon��5�      ��5�      �� *AfternoonCommand+5�      5�      �� 5�   
   $	��200��5�      $��50��5�      $��10,20q�5�      $��Bottom=�5�      ��5�      �� *ExitCommand+��5�      ��  �� ElementName$ DirectorWindow��.��5�        $��40��5�      $��30��5�      
�������$ 	ExitToApp=�5�       J� RenderTransformOrigin$ 0.46,-0.343&�5�      5�      5�      5�      