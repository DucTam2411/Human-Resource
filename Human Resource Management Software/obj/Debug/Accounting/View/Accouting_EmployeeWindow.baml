   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:HRMS.Accounting.ViewHRMS.Accounting.View  5      ;"clr-namespace:HRMS.Accounting.ViewHRMS.Accounting.View  5	      3    -HRMS.Accounting.View.Accouting_EmployeeWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:HRMS.Accounting.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      0userCon"clr-namespace:HRMS.Accounting.View  5	      -   5          �Name$  AccountingWindow��5
       � Title$ Accouting_EmployeeWindow��5      $
��1150��5      $	��600��5       � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��2��5      
���   �$��8q�5       �� CornerRadius$ 30��5      ��5      �� 5        �� Color$ White��6"   5"      �� 5$   
   $	��200��5%      $	��270��5&      $��15,-50,15,0q�5'      .+�5(      � 	 � RowDefinitions	 5)      �� 5*      �� 5+      �� 5,      �� 5-      �� 5.      .+�51      �� -   5        
 ��Name$
 btnHome��52      $��0��53      $	��200��54      $��50��55      $��0,5,0,0q�56      $
��Left=�57      $��0q�59      ��58      �� *BACKGROUNDHOME+��5:      �� *HomeCommand+.��5;      ��  �� Orientation$ 
Horizontal=�6!   .+�5<      '  !MaterialDesignThemes.Wpf.PackIcon  ��62   �� *FOREGROUNDHOME+   Kind 6X   �� *HOMETAB.ICONKIND+�� 5=      $��8,-4,0,0q�5>      $��	Tw Cen MT)�5?      $��22(�5@      $��SemiBold"�5A      ��5B      �� *FOREGROUNDHOME+��5C      �� *HOMETAB.TEXTBLOCKNAME+5D      5E      �� 5G      -   5        $
 btnReportSalary��5H      $��1��5I      $	��200��5J      $��50��5K      $��0,5,0,0q�5L      $
��Left=�5M      $��0q�5O      ��5N      �� *BACKGROUNDREPORT+��5P      �� *ReportCommand+.��5Q      �� $ 
Horizontal=�6!   .+�5R        ��62   �� *FOREGROUNDREPORT+ 6Z   �� *REPORTTAB.ICONKIND+�� 5S      $��8,-4,0,0q�5T      $
��Left=�5U      $��	Tw Cen MT)�5V      $��22(�5W      $��SemiBold"�5X      ��5Y      �� *FOREGROUNDREPORT+��5Z      �� *REPORTTAB.TEXTBLOCKNAME+5[      5\      �� 5^      -   5        $
 btnInformation��5_      $��2��5`      $	��200��5a      $��50��5b      $��0,5,0,0q�5c      $
��Left=�5d      $��0q�5f      ��5e      �� *BACKGROUNDINFORMATION+��5g      �� *InformationCommand+.��5h      �� $ 
Horizontal=�6!   .+�5i        ��62   �� *FOREGROUNDINFORMATION+ 6_   �� *INFORMATIONTAB.ICONKIND+�� 5j      $��8,-4,0,0q�5k      $��	Tw Cen MT)�5l      $��22(�5m      $��SemiBold"�5n      ��5o      �� *FOREGROUNDINFORMATION+��5p      �� *INFORMATIONTAB.TEXTBLOCKNAME+5q      5r      �� 5t      -   5        $
 btnTimekeeping��5u      $��3��5v      $	��200��5w      $��50��5x      $��0,5,0,0q�5y      $
��Left=�5z      $��0q�5|      ��5{      �� *BACKGROUNDTIMEKEEPING+��5}      �� *TimekeepingCommand+��5~      ��  �� ElementName$ btnTimekeeping��.��5      �� $ 
Horizontal=�6!   .+�5�        ��62   �� *FOREGROUNDTIMEKEEPING+ 6_   �� *TIMEKEEPINGTAB.ICONKIND+�� 5�      $��8,-4,0,0q�5�      $��	Tw Cen MT)�5�      $��22(�5�      $��SemiBold"�5�      ��5�      �� *FOREGROUNDTIMEKEEPING+��5�      �� *TIMEKEEPINGTAB.TEXTBLOCKNAME+5�      5�      �� 5�      -   5        $
 	btnSalary��5�      $��4��5�      $	��200��5�      $��50��5�      $��0,5,0,0q�5�      $
��Left=�5�      $��0q�5�      ��5�      �� *BACKGROUNDSALARY+��5�      �� *SalaryCommand+��5�      �� $ 	btnSalary��.��5�      �� $ 
Horizontal=�6!   .+�5�        ��62   �� *FOREGROUNDSALARY+ 6Z   �� *SALARYINFOTAB.ICONKIND+�� 5�      $��8,-4,0,0q�5�      $��	Tw Cen MT)�5�      $��22(�5�      $��SemiBold"�5�      ��5�      �� *FOREGROUNDSALARY+��5�      �� *SALARYINFOTAB.TEXTBLOCKNAME+5�      5�      5�      5�      ]� 5�   
   $��1��6   .+�5�      �� $
��Left=�6@   ��6   �� *CONTENTCONTROL+6@   5�      �� 5�   
   $	��230��5�      $��50��5�      $��10,100q�5�      $��Bottom=�5�      $ 
Horizontal=�5�      .+�5�      �� $	��100��5�      $��50��5�      $��10,0,0,0q�5�      $��Morning��5�      ��5�      �� *MorningCommand+5�      �� 5�      $	��100��5�      $��50��5�      $��10,0,0,0q�5�      $��	Afternoon��5�      ��5�      �� *AfternoonCommand+5�      5�      �� 5�   
   $	��200��5�      $��50��5�      $��10,20q�5�      $��Bottom=�5�      ��5�      �� *ExitCommand+��5�      �� $ AccountingWindow��.��5�        $��40��5�      $��30��5�      
�������$ 	ExitToApp=�5�       J� RenderTransformOrigin$ 0.46,-0.343&�5�      5�      5�      5�      