   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:HRMS.Accounting.ViewHRMS.Accounting.View  5      :    4HRMS.Accounting.View.uConAccountingSalaryInformation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:HRMS.Accounting.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      $
��auto��5	      $
��auto��5
      .��5      �� -   5          ��Name$  contentControlMain��5      $	��600��61   .��5   
   � $��0,20,0,0q�6    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��* �6'   .+�5      ]� $��0��5      $��20q�5      $��Center=�5      .+�5       �� $��0,0,0,0q�6!    �� Orientation$ 
Horizontal=�62   .+�5!      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5"      $��30��5#      $��Center=�5$      
���iii�   Kind$ CalendarAlert=�5&      �� 5'      $	��250��5(      )  #MaterialDesignThemes.Wpf.HintAssist   
HelperText$ The Month Payroll��5)         HelperTextFontSize$ 12Q�5*         Hint$ Month��5+      $��24(�5,      ��5-      �� *	MONTHLIST+ �� Mode$ TwoWay=�	 �� SelectedValue	 5.      �� *SELECTMONTHTYPE+��5/      �� 50   "   .R�51   &   �� $ 
Horizontal=�61   .+�52   *   �� ��64   �� *MONTH+�� 53   *   $	�� / ��64   �� 54   *   ��64   �� *YEAR+55   '   56   #   ��58      �� 59   "   
 �� 
TargetType"
 ��6(   .�5:   &   ��  �� Property �@��
IsSelected �� Value 6C   �� *
ISSELECTED+5;   #   5=      5>      5?      ]� 5A      $��1��5B      $��20q�5C      $��Center=�5D      .+�5E      �� $��0,0,0,0q�5F      $��Right=�5G      $��Bottom=�5H      $ 
Horizontal=�5I      .+�5J        $��30��5K      $��30��5L      $��Center=�5M      
���iii�$ Money=�5O      �� 5P      $	��250��5Q      $��8,0,0,0q�5R      $ Total salary in a month��5S      $ 12Q�5T      $ Total Salary��5U      $��24(�5V       �� 
IsReadOnly . ��5X      �� *TOTAL_SALARY+ �� UpdateSourceTrigger$ PropertyChanged=�$ TwoWay=�5Y      5Z      5[      � 5^      $��1��6   $��0,20,0,0q�6     5_      �� 5`      $��* �6'   �� 5a      $��* �6'   .+�5c      ]� $��0��5d      $��20q�5e      $��Center=�5f      .+�5g      �� $
��Left=�6!   .+�5h      �� $��0,0,0,0q�6%   $ 
Horizontal=�66   .+�5i        $��30��5j   !   $��30��5k   !   $��Center=�5l   !   
���iii�$ CalendarDay=�5n   !   �� 5o      $	��250��5p   !   $��8,0,0,0q�5q   !   $ Total work day in a month��5r   !   $ 12Q�5s   !   $ Number Of Work Day��5t   !   $��18(�5u   !    . ��5w   !   �� *NUMBER_OF_WORK_DAY+$ PropertyChanged=�$ TwoWay=�5x      �� 5z      $��0,30,0,0q�6%   $ 
Horizontal=�67   .+�5{        $��30��5|   !   $��30��5}   !   $��Center=�5~   !   
���iii�$ Calendar=�5�   !   �� 5�      $	��250��5�   !   $��8,0,0,0q�5�   !   $# Total overtime day in a month��5�   !   $ 12Q�5�   !   $ Number of Overtime Day��5�   !   $��18(�5�   !    . ��5�   !   �� *NUMBER_OF_OVERTIME_DAY+$ PropertyChanged=�$ TwoWay=�5�      �� 5�      $��0,30,0,0q�6%   $ 
Horizontal=�67   .+�5�        $��30��5�   !   $��30��5�   !   $��Center=�5�   !   
���iii�$ 	Overboard=�5�   !   �� 5�      $	��250��5�   !   $��8,0,0,0q�5�   !   $ Overtime salary in a day��5�   !   $ 12Q�5�   !   $ Overtime salary��5�   !   $��18(�5�   !    . ��5�   !   �� *OVERTIME_SALARY+$ PropertyChanged=�$ TwoWay=�5�      �� 5�      $��0,30,0,0q�6%   $ 
Horizontal=�67   .+�5�        $��30��5�   !   $��30��5�   !   $��Center=�5�   !   
���iii�$ MoneyOff=�5�   !   �� 5�      $	��250��5�   !   $��8,0,0,0q�5�   !   $! Total absent day in a month��5�   !   $ 12Q�5�   !   $ Number Of Absent Day��5�   !   $��18(�5�   !    . ��5�   !   �� *NUMBER_OF_ABSENT_DAY+$ PropertyChanged=�$ TwoWay=�5�      5�      5�      ]� 5�      $��1��5�      $��20q�5�      $��Center=�5�      .+�5�      �� $
��Left=�6!   .+�5�      �� $��0,0,0,0q�6%   $ 
Horizontal=�66   .+�5�        $��30��5�   !   $��30��5�   !   $��Center=�5�   !   
���iii�$ Numbers=�5�   !   �� 5�      $	��250��5�   !   $��8,0,0,0q�5�   !   $ Coefficient��5�   !   $ 12Q�5�   !   $ Coefficient��5�   !   $��18(�5�   !    . ��5�   !   �� *COEFFICIENT+$ PropertyChanged=�$ TwoWay=�5�      �� 5�      $��0,30,0,0q�6%   $ 
Horizontal=�67   .+�5�        $��30��5�   !   $��30��5�   !   $��Center=�5�   !   
���iii�$ DecimalIncrease=�5�   !   �� 5�      $	��250��5�   !   $��8,0,0,0q�5�   !   $ Basic Wage in day��5�   !   $ 12Q�5�   !   $ 
Basic Wage��5�   !   $��18(�5�   !    . ��5�   !   �� *
BASIC_WAGE+$ PropertyChanged=�$ TwoWay=�5�      �� 5�      $��0,30,0,0q�6%   $ 
Horizontal=�67   .+�5�        $��30��5�   !   $��30��5�   !   $��Center=�5�   !   
���iii�$	 Add=�5�   !   �� 5�      $	��250��5�   !   $��8,0,0,0q�5�   !   $ Welfare��5�   !   $ 12Q�5�   !   $ Welfare��5�   !   $��18(�5�   !    . ��5�   !   �� *	WELFARE+$ PropertyChanged=�$ TwoWay=�5�      �� 5�      $��0,30,0,0q�6%   $ 
Horizontal=�67   .+�5�        $��30��5�   !   $��30��5�   !   $��Center=�5�   !   
���iii�$ Present=�5�   !   �� 5�      $	��250��5�   !   $��8,0,0,0q�5�   !   $ Bonus��5�   !   $ 12Q�5�   !   $ Bonus��5�   !   $��18(�5�   !    . ��5�   !   �� *BONUS+$ PropertyChanged=�$ TwoWay=�5�      5�      5�      5      �� 5     $��2��5     $	��500��5     $��
50,20,0,10q�5     
���   �$��15q�5      J� Opacity$ 1Q�5     � 5
     $��3��6   $	��0,0q�6     5     �� 5     $��* �6'   �� 5     $��* �6'   .+�5     ]� $��0��5     $��20q�5     $��Center=�5     .+�5     �� $
��Left=�6!   .+�5     �� $��0,0,0,0q�6%   $ 
Horizontal=�66   .+�5       $��30��5  !   $��30��5  !   $��Center=�5  !   
���iii�$ Globe=�5  !   �� 5     $	��250��5  !   $��8,0,0,0q�5  !   $ Health Insurance Tax��5  !   $ 12Q�5  !   $ Health Insurance��5   !   $��18(�5!  !    . ��5#  !   �� *HEALTH_INSURANCE+$ PropertyChanged=�$ TwoWay=�5$     �� 5&     $��0,30,0,0q�6%   $ 
Horizontal=�67   .+�5'       $��30��5(  !   $��30��5)  !   $��Center=�5*  !   
���iii�$ HealthPotion=�5,  !   �� 5-     $	��250��5.  !   $��8,0,0,0q�5/  !   $ Social Insurance Tax��50  !   $ 12Q�51  !   $ Social Insurance��52  !   $��18(�53  !    . ��55  !   �� *SOCIAL_INSURANCE+$ PropertyChanged=�$ TwoWay=�56     57     58     ]� 5:     $��1��5;     $��20q�5<     $��Center=�5=     .+�5>     �� $
��Left=�6!   .+�5?     �� $��0,0,0,0q�6%   $ 
Horizontal=�66   .+�5@       $��30��5A  !   $��30��5B  !   $��Center=�5C  !   
���iii�$ MoneyOff=�5E  !   �� 5F     $	��250��5G  !   $��8,0,0,0q�5H  !   $ 
Income Tax��5I  !   $ 12Q�5J  !   $ 
Income Tax��5K  !   $��18(�5L  !    . ��5N  !   �� *TAX+$ PropertyChanged=�$ TwoWay=�5O     �� 5Q     $��0,30,0,0q�6%   $ 
Horizontal=�67   .+�5R       $��30��5S  !   $��30��5T  !   $��Center=�5U  !   
���iii�$ MoneyOff=�5W  !   �� 5X     $	��250��5Y  !   $��8,0,0,0q�5Z  !   $ Total tax in a month��5[  !   $ 12Q�5\  !   $ 	Total Tax��5]  !   $��18(�5^  !    . ��5`  !   �� *	TOTAL_TAX+$ PropertyChanged=�$ TwoWay=�5a     5b     5c     5d     5e     5f     5g     