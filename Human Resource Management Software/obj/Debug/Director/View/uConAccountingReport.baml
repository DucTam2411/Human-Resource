   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HRMS.Director.ViewHRMS.Director.View  5      C&clr-namespace:HRMS.Accouting.ViewModelHRMS.Accouting.ViewModel  5	      -    'HRMS.Director.View.uConAccountingReport   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:HRMS.Director.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      6	viewmodel&clr-namespace:HRMS.Accouting.ViewModel  5	      $	��880��5
      $	��600��5        � 	Resources  5         WrapText �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6!   .�5      ��  � ��$
 Wrap=�6-   �� 5       �@��TextAlignment$
 Left=�68   5      5      .��5      �� -   5         ��Name$ contentControlMain��5      $	��600��61   .��5   
   � $��0,20,0,0q�6   
������  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      � $��0��6   $��20,10q�6     � ColumnDefinitions 5       �� 5!      $��* �6'   �� 5"      $��* �6'   .+�5$      �� $��0,0,0,0q�6    �� Orientation$ 
Horizontal=�6.   .+�5%      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5&      $��30��5'      $��Center=�5(      
���iii�   Kind$ Filter=�5*      �� 5+      $��8,0,0,0q�5,      $��Center=�5-      $��18(�5.      $��Department ��5/      �� 50      $	��260��51      $��8,0,0,0q�52      $��Center=�53      $��Center=�54      	 �� DisplayMemberPath$	 	DEPT_NAME��55      $��18(�56      
���iii���58      �� *ListDeptType+
 �� Mode$
 TwoWay=� �� SelectedValue 59      �� *SELECTEDDEPTTYPE+��5:      �� 5;      " ��6$   .�5<   "   ��  �@��
IsSelected 6?   �� *
ISSELECTED+5=      5?      5@      �� 5B      $��1��5C      $��30,0,0,-0.4q�5D      $
��Left=�5E      $ 
Horizontal=�5F      .+�5G        $��30��5H      $��30��5I      $��Center=�5J      
���iii�$ Calendar=�5L      �� 5M      $��5,0,0,0q�5N      $��Center=�5O      $��18(�5P      $��Month��5Q      �� 5S      $��8,0,0,0q�5T      $��Center=�5U      $��Center=�5V      $��18(�5W      
���iii���5Y      �� *	MONTHLIST+$
 TwoWay=� 5Z      �� *SELECTMONTHTYPE+��5[      �� 5\      .R�5]   "   �� $ 
Horizontal=�6-   .+�5^   &   �� ��60   �� *MONTH+�� 5_   &   $	�� / ��60   �� 5`   &   ��60   �� *YEAR+5a   #   5b      ��5d      �� 5e      " ��6$   .�5f   "   ��  �@��
IsSelected 6?   �� *
ISSELECTED+5g      5i      5j      5k      � 5m      $��1��6   $��20q�6     5n      �� 5o      $
��auto �6'   �� 5p      $
��auto �6'   .+�5r      �� $��10,0,0,0q�6   $ 
Horizontal=�6/   .+�5s        $��30��5t      $��30��5u      $��Center=�5v      
���iii�$ Search=�5x      �� 5y      $	��400��5z      $��5,0,0,0q�5{      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search ��5|      $��18(�5}      ��5~      �� *SEARCH_TEXT+ �� UpdateSourceTrigger$ PropertyChanged=��� 5�      $��1��5�      $	��140��5�      $��50,0,0,0q�5�      $��Center=�5�      $��Center=�5�      $
	 NAME��5�      $��18(�5�      
���iii���5�      �� *
ListType+$
 TwoWay=� 5�      �� *SELECTEDTYPE+��5�      �� 5�      " ��6$   .�5�   "   ��  �@��
IsSelected 6?   �� *
ISSELECTED+5�      5�      5�      5�      � 5�      $��2��6   $	��420��6    .+�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ SalaryDataGrid��5�      $	��380��5�      $��0,20.4,20,0q�5�      $	��Top=�5�       J� 	AllowDrop .    AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .    
IsReadOnly . ��5�      �� *EmployeeList+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 5�       ) %MaterialDesignDataGridTextColumnStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 5�         
Foreground
 �OO/�   Header$ ID��5�         Binding 5�      �� *EMPLOYEE_ID+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$
 Name��5�       5�      �� *NAME+5�      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5�      $
 auto 5�      # [  5�      
 �OO/�$ 
Department��5�       5�      �� *
DEPARTMENT+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$
 Role��5�       5�      �� *ROLE+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$ Coefficient��5�       5�      �� *COEFFICIENT+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$ Work Day��5�       5�      �� *	WORKDAY+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$ Overtime Day��5�       5�      �� *OVERTIMEDAY+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$ 
Baisc Wage��5�       5�      �� *	BASICWAGE+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$ Overtime Salary��5�       5�      �� *OVERTIMESALARY+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$ Social Insurance��5�       5�      �� *SOCIALINSURANCE+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$ Health Insurance��5�       5�      �� *HEALTHINSURANCE+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$ Welfare��5�       5�      �� *	WELFARE+5�        5�      $
 auto 5�      # [  5�      
 �OO/�$ Bonus��5�       5�      �� *BONUS+5�        5     $
 auto 5     # [  5     
 �OO/�$	 Tax��5      5     �� *TAX+5       5     $
 auto 5	     # [  5     
 �OO/�$ Salary��5      5
     �� *TOTALSALARY+5     5     5     5     5     5     