   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:HRMS.Accounting.ViewHRMS.Accounting.View  5      -    'HRMS.Accounting.View.uConEmployeeSalary   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:HRMS.Accounting.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5        $��ucEmployeeDetailed��5	      $	��900��5
      $
��auto��5      
������ .��5      �� -   5          ��Name$  contentControlDetail��5      $	��600��63   .��5   
   � $��70,0,0,0q�6    � ColumnDefinitions 5      �� 5      $
��auto �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      ]� $��0��6   $��0,0,0,0q�6%   .+�5      �� $��	20,10,0,0q�6   $
��Left=�60   .+�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5       $��30��5!      $��Center=�5"      
���iii�   Kind$
 User=�5$      �� 5%      $	��250��5&      $��8,0,0,0q�5'      )  #MaterialDesignThemes.Wpf.HintAssist   
HelperText$ Employee full name.��5(         Hint$
 Name��5)      $��18(�5*       �� 
IsReadOnly . ��5,      �� *EMPLOYEE_NAME+ �� UpdateSourceTrigger$ PropertyChanged=�5-      �� 5/      $��0,20,0,0q�6!   $ 
Horizontal=�63   .+�50        $��30��51      $��30��52      $��Center=�53      
���iii�$ IdCard=�55      �� 56      $	��250��57      $��8,0,0,0q�58      $ ID Card number��59      $ ID��5:      $��18(�5;       . ��5=      �� *EMPLOYEE_ID+$ PropertyChanged=�5>      �� 5@      $��0,20,0,0q�6!   $ 
Horizontal=�63   .+�5A        $��30��5B      $��30��5C      $��Center=�5D      
���iii�$ HomeAccount=�5F      �� 5G      $	��250��5H      $��8,0,0,0q�5I      $ Employee Department��5J      $ 
Department��5K      $��18(�5L       . ��5N      �� *DEPARTMENT_NAME+$ PropertyChanged=�5O      �� 5Q      $��0,20,0,0q�6!   $ 
Horizontal=�63   .+�5R        $��30��5S      $��30��5T      $��Center=�5U      
���iii�$ PeopleGroup=�5W      �� 5X      $	��250��5Y      $��8,0,0,0q�5Z      $ Employee Role��5[      $
 Role��5\      $��18(�5]       . ��5_      �� *	ROLE_NAME+$ PropertyChanged=�5`      5a      �� 5c      $	��220��5d      $	��220��5e      $��
20,10,20,0q�5f      $��Right=�5j      	 J� Opacity$		 100Q�5k      ��5g      �� *BRUSH+��5h      �� *BUTTONTHICKNESS+��5i      �� *AddImageCommand+.��5l      �� -   5        
 ��Name$	
 img��5m      $
��Fill=�5o      ��5n      �� *IMAGE_SOURCE+5o      5p      5q      �� 5s      $��1��5t      $��0,10,0,0q�5u      
���   �$��10q�5w      $		 0.8Q�5x      �� 5z      $��2��5{      $	��750��5|      $	��280��5}      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ Standard=�5~      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5      
������  )  %MaterialDesignNavigatilRailTabControl#��[  5�       �� TabStripPlacement$ Right=�5�      .@�5�      �� 
������  ' #MaterialDesignNavigationRailTabItem#��[ 5�      ��5�      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Money=�   Size$ 24X�.��5�      ]� .+�5�      ]� $��20q�6$   $
��Left=�60   .+�5�      �� $
��Left=�6)   .+�5�   "   �� $��0,0,0,0q�6-   $ 
Horizontal=�6>   .+�5�   &     $��30��5�   )   $��30��5�   )   $��Center=�5�   )   
���iii�$ Globe=�5�   )   �� 5�   &   $	��250��5�   )   $��8,0,0,0q�5�   )   $ Employee Social Insurance��5�   )   $ Social Insurance��5�   )   $��18(�5�   )   ��5�   )   �� *SOCIAL_INSURANCE+$ PropertyChanged=�5�   #   �� 5�   "   $��0,30,0,0q�6-   $ 
Horizontal=�6?   .+�5�   &     $��30��5�   )   $��30��5�   )   $��Center=�5�   )   
���iii�$ HealthPotion=�5�   )   �� 5�   &   $	��250��5�   )   $��8,0,0,0q�5�   )   $ Employee Health Insurance��5�   )   $ Health Insurance��5�   )   $��18(�5�   )   ��5�   )   �� *HEALTH_INSURANCE+$ PropertyChanged=�5�   #   �� 5�   "   $��0,30,0,0q�6-   $ 
Horizontal=�6?   .+�5�   &     $��30��5�   )   $��30��5�   )   $��Center=�5�   )   
���iii�$	 Add=�5�   )   �� 5�   &   $	��250��5�   )   $��8,0,0,0q�5�   )   $ Employee Welfare��5�   )   $ Welfare��5�   )   $��18(�5�   )   ��5�   )   �� *	WELFARE+$ PropertyChanged=�5�   #   �� 5�   "   $��0,30,0,0q�6-   $ 
Horizontal=�6?   .+�5�   &     $��30��5�   )   $��30��5�   )   $��Center=�5�   )   
���iii�$ Numbers=�5�   )   �� 5�   &   $	��250��5�   )   $��8,0,0,0q�5�   )   $ Employee Coefficient��5�   )   $ Coefficient��5�   )   $��18(�5�   )   ��5�   )   �� *COFFEICENT_STRING+$ PropertyChanged=�5�   #   5�      5�      ]� 5�      $��20,20,30,20q�6$   $
��Left=�69   .+�5�      �� $
��Left=�6)   .+�5�   "   �� $��0,0,0,0q�6-   $ 
Horizontal=�6>   .+�5�   &     $��30��5�   )   $��30��5�   )   $��Center=�5�   )   
���iii�$ DecimalIncrease=�5�   )   �� 5�   &   $	��250��5�   )   $��8,0,0,0q�5�   )   $ Employee basic wage��5�   )   $ 
Basic Wage��5�   )   $��18(�5�   )   ��5�   )   �� *
BASIC_WAGE+$ PropertyChanged=�5�   #   �� 5�   "   $��0,30,0,0q�6-   $ 
Horizontal=�6?   .+�5�   &     $��30��5�   )   $��30��5�   )   $��Center=�5�   )   
���iii�$ 	Overboard=�5�   )   �� 5�   &   $	��250��5�   )   $��8,0,0,0q�5�   )   $ Employee overtime salary��5�   )   $ Overtime salary��5�   )   $��18(�5�   )   ��5�   )   �� *OVERTIME_SALARY+$ PropertyChanged=�5�   #   �� 5�   "   $��0,30,0,0q�6-   $ 
Horizontal=�6?   .+�5�   &     $��30��5�   )   $��30��5�   )   $��Center=�5�   )   
���iii�$ Present=�5�   )   �� 5�   &   $	��250��5�   )   $��8,0,0,0q�5�   )   $ Employee bonus��5�   )   $ Bonus��5�   )   $��18(�5�   )   ��5�   )   �� *BONUS+$ PropertyChanged=�5�   #   �� 5  "   $��0,30,0,0q�6-   $ 
Horizontal=�6?   .+�5  &     $��30��5  )   $��30��5  )   $��Center=�5  )   
���iii�$ MoneyOff=�5  )   �� 5  &   $	��250��5	  )   $��8,0,0,0q�5
  )   $ Employee tax��5  )   $	 Tax��5  )   $��18(�5  )   ��5  )   �� *TAX+$ PropertyChanged=�5  #   5     5     5     5     �� 5     
������ #��[ 5     ��5       $ NoteAddOutline=�$ 24X�.��5     ]� .+�5     ]� $	��Top=�6$   .+�5     �� $��30��5  !   $��	20,20,0,0q�5  !   $
��Left=�5  !   $ 
Horizontal=�5   !   .+�5!  "     $��30��5"  %   $��30��5#  %   $��Center=�5$  %   
���iii�$
 Note=�5&  %   �� 5'  "   $	��250��5(  %   $��8,0,0,0q�5)  %   $��18(�5*  %   $
��Note��5+  %   5,     �� 5.     $��30��5/  !   $��	20,20,0,0q�50  !   $
��Left=�51  !   $ 
Horizontal=�52  !   .+�53  "     $��30��54  %   $��30��55  %   $��Center=�56  %   
���iii�$
 Note=�58  %   �� 59  "   $	��250��5:  %   $��8,0,0,0q�5;  %   $ Employee total salary��5<  %   $ Total Salary��5=  %   $��18(�5>  %    . ��5@  %   �� *TOTAL_SALARY+$ PropertyChanged=�5A     5B     �� 5C     $��20q�5D     $
 Note��5E     $
 Note��5F      �� AcceptsReturn . $��18(�5H      ! MaterialDesignOutlinedTextBox#��[ 5I      �� TextAlignment$
 Left=�5K      �� TextWrapping$
 Wrap=�5L     ��5J     �� *NOTE+$ PropertyChanged=� �� Mode$ TwoWay=�5L     5M     5N     5O     �� 5Q     $��3��5R     $
��0,10q�5S     $ 
Horizontal=�5T     .+�5V     �� $	��100��5W     $��50��5X     $��100,0,50,10q�5Y     $��Right=�5Z     $
��Save��5\     $��18(�5]     $��Light"�5^     ��5[     �� *EditCommand+5^     �� 5`     $	��100��5a     $��50��5b     $��
200,0,0,10q�5c     $��Right=�5d     ���	#FFFF745C$��0q�5f     $��Cancel��5i     $��18(�5j     $��Light"�5k     ��5g     �� *BackCommand+��5h     ��  �� ElementName$ contentControlDetail��5k     5l     5r     5s     5u     