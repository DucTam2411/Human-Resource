   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HRMS.HR.uConHRMS.HR.uCon  5      5clr-namespace:HRMS.HR.ViewModelHRMS.HR.ViewModel  5	      $    HRMS.HR.uCon.HR_EmployeeWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:HRMS.HR.uCon     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      /	viewmodelclr-namespace:HRMS.HR.ViewModel  5	      -   5          �Name$  HRWindow��5
       � Title$ HR_EmployeeWindow��5      $
��1124��5      $	��620��5       � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��2��5      $��0,2,0,-2q�5      
���   �$��8q�5        �� CornerRadius$ 30��5!      ��5#      �� 5$       �� Color$ White��6"   5&      �� 5'   
   $	��200��5(      $	��350��5)      $��	15,0,15,0q�5*      .+�5,      � 	 � RowDefinitions	 5-      �� 5.      �� 5/      �� 50      �� 51      �� 52      �� 53      .+�58      � -   5        
 �Name$
 
GridCursor��59      $	��190��5:      $��50��5;      $��0,0,0,0q�5<      $
��Left=�5=      
������ 5>      �� 5@      -   5         ��Name$ btnHome��5A      $��0��5B      $	��200��5C      $��50��5D      $��0,5,0,0q�5E      $
��Left=�5F      $
��Left=�5G      $��0q�5I      ��5H      �� *BACKGROUNDHOME+��5J      �� *HomeCommand+.��5L      ��  �� Orientation$ 
Horizontal=�6!   .+�5M      '  !MaterialDesignThemes.Wpf.PackIcon  ��62   �� *FOREGROUNDHOME+   Kind 6X   �� *HOMETAB.ICONKIND+�� 5N      $��8,-4,0,0q�5O      $��	Tw Cen MT)�5P      $��22(�5Q      $��SemiBold"�5R      ��5S      �� *FOREGROUNDHOME+��5T      �� *HOMETAB.TEXTBLOCKNAME+5U      5W      �� 5Y      $��1��5Z      $	��200��5[      $��50��5\      $��0,5,0,0q�5]      $
��Left=�5^      $
��Left=�5_      $��0q�5a      ��5`      �� *BACKGROUNDINFORMATION+��5b      �� *InformationCommand+.��5d      �� $ 
Horizontal=�6!   .+�5e        ��62   �� *FOREGROUNDINFORMATION+ 6_   �� *INFORMATIONTAB.ICONKIND+�� 5f      $��8,-4,0,0q�5g      $��	Tw Cen MT)�5h      $��22(�5i      $��SemiBold"�5j      ��5k      �� *FOREGROUNDINFORMATION+��5l      �� *INFORMATIONTAB.TEXTBLOCKNAME+5m      5n      �� 5o      $��2��5p      $	��200��5q      $��50��5r      $��0,5,0,0q�5s      $
��Left=�5t      $
��Left=�5u      $��0q�5w      ��5v      �� *BACKGROUNDMODIFY+��5x      �� *ModifyCommand+.��5y      �� $ 
Horizontal=�6!   .+�5z        ��62   �� *FOREGROUNDMODIFY+ 6Z   �� *MODIFYTAB.ICONKIND+�� 5{      $��8,-4,0,0q�5|      $��	Tw Cen MT)�5}      $��22(�5~      $��SemiBold"�5      ��5�      �� *FOREGROUNDMODIFY+��5�      �� *MODIFYTAB.TEXTBLOCKNAME+5�      5�      �� 5�      $��3��5�      $	��200��5�      $��50��5�      $��0,5,0,0q�5�      $
��Left=�5�      $
��Left=�5�      $��0q�5�      ��5�      �� *BACKGROUNDREPORT+��5�      �� *ReportCommand+.��5�      �� $ 
Horizontal=�6!   .+�5�        ��62   �� *FOREGROUNDREPORT+ 6Z   �� *REPORTTAB.ICONKIND+�� 5�      $��8,-4,0,0q�5�      $��	Tw Cen MT)�5�      $��22(�5�      $��SemiBold"�5�      ��5�      �� *FOREGROUNDREPORT+��5�      �� *REPORTTAB.TEXTBLOCKNAME+5�      5�      �� 5�      $��4��5�      $	��200��5�      $��50��5�      $��0,5,0,0q�5�      $
��Left=�5�      $
��Left=�5�      $��0q�5�      ��5�      �� *BACKGROUNDTIMEKEEPING+��5�      �� *TimekeepingCommand+.��5�      �� $ 
Horizontal=�6!   .+�5�        ��62   �� *FOREGROUNDTIMEKEEPING+ 6_   �� *TIMEKEEPINGTAB.ICONKIND+�� 5�      $��8,-4,0,0q�5�      $��	Tw Cen MT)�5�      $��22(�5�      $��SemiBold"�5�      ��5�      �� *FOREGROUNDTIMEKEEPING+��5�      �� *TIMEKEEPINGTAB.TEXTBLOCKNAME+5�      5�      �� 5�      $��5��5�      $	��200��5�      $��50��5�      $��0,5,0,0q�5�      $
��Left=�5�      $
��Left=�5�      $��0q�5�      ��5�      �� *BACKGROUNDSALARY+��5�      �� *SalaryCommand+.��5�      �� $ 
Horizontal=�6!   .+�5�        ��62   �� *FOREGROUNDSALARY+ 6Z   �� *SALARYTAB.ICONKIND+�� 5�      $��8,-4,0,0q�5�      $��	Tw Cen MT)�5�      $��22(�5�      $��SemiBold"�5�      ��5�      �� *FOREGROUNDSALARY+��5�      �� *SALARYTAB.TEXTBLOCKNAME+5�      5�      5�      5�      ]� 5�   
   $��1��6   .+�5�      �� $��1��5�      $��
0,15,15,15q�5�      $
��Left=�5�      ��5�      �� *CONTENTCONTROL+5�      5�      �� 5�   
   $	��230��5�      $��50��5�      $��0,0,0,90q�5�      $��Bottom=�5�      $ 
Horizontal=�5�      .+�5�      �� $	��100��5�      $��50��5�      $��12,0,0,0q�5�      $��Morning��5�      ��5�      �� *MorningCommand+5�      �� 5�      $	��100��5�      $��50��5�      $��15,0,0,0q�5�      $��	Afternoon��5�      ��5�      �� *AfternoonCommand+5�      5�      �� 5�   
   $	��212��5�      $��50��5�      $��	12,0,0,20q�5�      $��Bottom=�5�      ��5�      �� *ExitCommand+��5�      ��  �� ElementName$ HRWindow��.��5�        $��40��5�      $��30��5�      
�������$ 	ExitToApp=�5�       J� RenderTransformOrigin$ 0.46,-0.343&�5�      5�      5�      5�      