   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:HRMS.Accounting.ViewHRMS.Accounting.View  5      5    /HRMS.Accounting.View.uConListEmployeeAccounting   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:HRMS.Accounting.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��880��5      $	��600��5	        � 	Resources  5         WrapText �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6!   .�5      ��  � ��$
 Wrap=�6-   �� 5       �@��TextAlignment$
 Left=�68   5      5      .��5      �� -   5         ��Name$ contentControlMain��5      $	��600��61   .��5   
   � $��0,20,0,0q�6   
������  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $	��380 �6    �� 5      $
��auto �6    .+�5      � $��0��6   $��20,10q�6     � ColumnDefinitions 5      �� 5      $��* �6'   �� 5       $��* �6'   .+�5"      �� $��0,0,0,0q�6    �� Orientation$ 
Horizontal=�6.   .+�5#      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5$      $��30��5%      $��Center=�5&      
���iii�   Kind$ Filter=�5(      �� 5)      $��8,0,0,0q�5*      $��Center=�5+      $��18(�5,      $��Department ��5-      �� 5.      $	��260��5/      $��8,0,0,0q�50      $��Center=�51      $��Center=�52      	 �� DisplayMemberPath$	 	DEPT_NAME��53      $��18(�54      
���iii���56      �� *ListDeptType+
 �� Mode$
 TwoWay=� �� SelectedValue 57      �� *SELECTEDDEPTTYPE+��58      �� 59      " ��6$   .�5:   "   ��  �@��
IsSelected 6?   �� *
ISSELECTED+5;      5=      5>      �� 5@      $��1��5A      $��30,0,0,-0.4q�5B      $
��Left=�5C      $ 
Horizontal=�5D      .+�5E        $��30��5F      $��30��5G      $��Center=�5H      
���iii�$ Calendar=�5J      �� 5K      $��5,0,0,0q�5L      $��Center=�5M      $��18(�5N      $��Month��5O      �� 5Q      $��8,0,0,0q�5R      $��Center=�5S      $��Center=�5T      $��18(�5U      
���iii���5W      �� *	MONTHLIST+$
 TwoWay=� 5X      �� *SELECTMONTHTYPE+��5Y      �� 5Z      .R�5[   "   �� $ 
Horizontal=�6-   .+�5\   &   �� ��60   �� *MONTH+�� 5]   &   $	�� / ��60   �� 5^   &   ��60   �� *YEAR+5_   #   5`      ��5b      �� 5c      " ��6$   .�5d   "   ��  �@��
IsSelected 6?   �� *
ISSELECTED+5e      5g      5h      5i      � 5k      $��1��6   $��20q�6     5l      �� 5m      $
��auto �6'   �� 5n      $
��auto �6'   .+�5p      �� $��10,0,0,0q�6   $ 
Horizontal=�6/   .+�5q        $��30��5r      $��30��5s      $��Center=�5t      
���iii�$ Search=�5v      �� 5w      $	��400��5x      $��5,0,0,0q�5y      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search ��5z      $��18(�5{      ��5|      �� *SEARCH_TEXT+ �� UpdateSourceTrigger$ PropertyChanged=��� 5~      $��1��5      $	��140��5�      $��50,0,0,0q�5�      $��Center=�5�      $��Center=�5�      $
	 NAME��5�      $��18(�5�      
���iii���5�      �� *
ListType+$
 TwoWay=� 5�      �� *SELECTEDTYPE+��5�      �� 5�      " ��6$   .�5�   "   ��  �@��
IsSelected 6?   �� *
ISSELECTED+5�      5�      5�      5�      � 5�      $��2��6   $	��380��6    .+�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ SalaryDataGrid��5�      $	��350��5�      $��
0,20.4,0,0q�5�      $	��Top=�5�       J� 	AllowDrop .    AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .    
IsReadOnly . ��5�      �� *
SalaryList+ �� SelectedItem 5�      �� *SelectedItem+ J� InputBindings 5�      d� 5�       d� Gesture$ LeftDoubleClicka�5�       �� Command 5�      �� *showEmployeeCommand+ �� CommandParameter 5�      ��  �� ElementName$ contentControlMain��5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 5�       ) %MaterialDesignDataGridTextColumnStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 5�         
Foreground
 �OO/�    Header$  ID��5�      !   Binding! 5�      �� *EMPLOYEE_ID+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$
  Name��5�      ! 5�      �� *NAME+5�      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5�      $
 auto 5�      # [  5�      
 �OO/�$  
Department��5�      ! 5�      �� *
DEPARTMENT+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$
  Role��5�      ! 5�      �� *ROLE+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$  Coefficient��5�      ! 5�      �� *COEFFICIENT+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$  Work Day��5�      ! 5�      �� *	WORKDAY+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$  Overtime Day��5�      ! 5�      �� *OVERTIMEDAY+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$  
Baisc Wage��5�      ! 5�      �� *	BASICWAGE+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$  Overtime Salary��5�      ! 5�      �� *OVERTIMESALARY+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$  Social Insurance��5�      ! 5�      �� *SOCIALINSURANCE+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$  Health Insurance��5�      ! 5�      �� *HEALTHINSURANCE+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$  Welfare��5�      ! 5�      �� *	WELFARE+5�        5      $
 auto 5     # [  5     
 �OO/�$  Bonus��5     ! 5     �� *BONUS+5       5     $
 auto 5     # [  5
     
 �OO/�$	  Tax��5     ! 5	     �� *TAX+5       5     $
 auto 5     # [  5     
 �OO/�$  Salary��5     ! 5     �� *TOTALSALARY+5     5     5     �� 5     $��3��5     $��Right=�5     $ 
Horizontal=�5     .+�5     �� $	��150��5     $��50��5     $��
10,10,50,0q�5     $��
Export PDF��5!     $��18(�5"     $��Light"�5#     ��5     �� *ExportPDFCommand+��5      �� $ SalaryDataGrid��5#     �� 5$     $	��150��5%     $��50��5&     $��
10,10,50,0q�5'     $��Export Excel��5*     $��18(�5+     $��Light"�5,     ��5(     �� *ExportExcelCommand+��5)     �� $ SalaryDataGrid��5,     5-     5.     5/     50     