   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:HRMS.Accounting.ViewHRMS.Accounting.View  5      (    "HRMS.Accounting.View.uConDashBoard   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:HRMS.Accounting.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      
������   � 	Resources  5         WrapText �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6!   .�5      ��  � ��$
 Wrap=�6-   �� 5       �@��TextAlignment$
 Left=�68   5      5      .��5      �� -   5         ��Name$ contentControlMain��5   	   $	��880��5   	   $	��600��5   	   .��5   
   � $��0,20,0,0q�6    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��
40,10,0,10q�6    �� Orientation$ 
Horizontal=�6-   .+�5       '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5!      $��30��5"      $��Center=�5#      
���iii�   Kind$ Search=�5%      �� 5&      -   5         ��Name$ tbSearch��5'      $	��370��5(      $��5,0,0,0q�5)      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Search ��5*      $��18(�5+      ��5,      �� *SEARCH_TEXT+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� Mode$ TwoWay=��� 5.      $	��170��5/      $��8,0,0,0q�50      $��Center=�51      $��Center=�52       �� DisplayMemberPath$
 NAME��53      $��18(�54      
���iii���56      �� *
ListType+$ TwoWay=� �� SelectedValue 57      �� *SELECTEDTYPE+��58      �� 59      " ��6    .�5:      ��  �@��
IsSelected 6;   �� *
ISSELECTED+5;      5=      �� 5?      $��1��5@      $��30,0,0,-0.4q�5A      $��Right=�5B      $ 
Horizontal=�5C      .+�5D        $��30��5E      $��30��5F      $��Center=�5G      
���iii�$ Calendar=�5I      �� 5J      $��5,0,0,0q�5K      $��Center=�5L      $��18(�5M      $��Month��5N      �� 5P      $��8,0,0,0q�5Q      $��Center=�5R      $��Center=�5S      $��18(�5T      
���iii���5V      �� *	MONTHLIST+$ TwoWay=� 5W      �� *SELECTMONTHTYPE+��5X      �� 5Y      .R�5Z   "   �� $ 
Horizontal=�6-   .+�5[   &   �� ��60   �� *MONTH+�� 5\   &   $	�� / ��60   �� 5]   &   ��60   �� *YEAR+5^   #   5_      ��5a      �� 5b      " ��6$   .�5c   "   ��  �@��
IsSelected 6?   �� *
ISSELECTED+5d      5f      5g      5h      &   System.Windows.Controls.DataGrid  5j      -   5          Name$ dgDashboard��5k      $��1��5l      $	��450��5m      $��
0,20.4,0,0q�5n      $	��Top=�5o       J� 	AllowDrop .    AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .    
IsReadOnly . "   VerticalScrollBarVisibility$ Visible=�5y      ��5w      �� *
RecordList+ �� SelectedItem 5x      �� *SelectedItem+ J� InputBindings 5z      d� 5{       d� Gesture$ LeftDoubleClicka�5~       �� Command 5|      �� *SelectedCommand+ �� CommandParameter 5}      ��  �� ElementName$ contentControlMain��5~         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 5�         
Foreground
 �OO/�    Header$  ID��5�      1  +System.Windows.Controls.DataGridBoundColumn!   Binding! 5�      �� *EMPLOYEE_ID+$
 PropertyChanged=�5�        5�      $
 auto 5�      "   ElementStyle#" [  5�      
 �OO/�$
  Name��5�      ! 5�      �� *EMPLOYEE.NAME+$
 PropertyChanged=�5�        5�      $
 auto 5�      
 �OO/�$  Date Change��5�      ! 5�      �� *DATE_CHANGE+$
 PropertyChanged=�5�        5�      $
 auto 5�      
 �OO/�$  Employee Changed��5�      ! 5�      �� *EMPLOYEE_CHANGE_NAME+$
 PropertyChanged=�5�        5�      $	 600 5�      #" [  5�      
 �OO/�$  Record��5�      ! 5�      �� *CHANGE+$
 PropertyChanged=�5�      5�      5�      5�      5�      