   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HRMS.HR.uConHRMS.HR.uCon  5      5clr-namespace:HRMS.HR.ViewModelHRMS.HR.ViewModel  5	           HRMS.HR.uCon.uConDashboard   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:HRMS.HR.uCon     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      /	viewmodelclr-namespace:HRMS.HR.ViewModel  5	      $	��880��5
      $	��620��5      
������   � 	Resources  5         WrapText �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6!   .�5      ��  � ��$
 Wrap=�6-   �� 5       �@��TextAlignment$
 Left=�68   5      5      .��5      �� -   5         ��Name$ contentControlMain��5   	   $	��880��5   	   $	��600��5   	   .��5   
   � $��0,20,0,0q�6    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5"      �� $��
40,10,0,10q�6    �� Orientation$ 
Horizontal=�6-   .+�5$      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5%      $��30��5&      $��Center=�5'      
���iii�   Kind$ Search=�5)      �� 5*      -   5         ��Name$ tbSearch��5+      $	��370��5,      $��5,0,0,0q�5-      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Search ��5.      $��18(�5/      ��50      �� *SEARCH_TEXT+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� Mode$ TwoWay=��� 52      $	��170��53      $��8,0,0,0q�54      $��Center=�55      $��Center=�56       �� DisplayMemberPath$
 NAME��57      $��18(�58      
���iii���5:      �� *
ListType+$ TwoWay=� �� SelectedValue 5;      �� *SELECTEDTYPE+��5<      �� 5=      " ��6    .�5>      ��  �@��
IsSelected 6;   �� *
ISSELECTED+5?      5A      �� 5C      $��1��5D      $��30,0,0,-0.4q�5E      $��Right=�5F      $ 
Horizontal=�5G      .+�5H        $��30��5I      $��30��5J      $��Center=�5K      
���iii�$ Calendar=�5M      �� 5N      $��5,0,0,0q�5O      $��Center=�5P      $��18(�5Q      $��Month��5R      �� 5T      $��8,0,0,0q�5U      $��Center=�5V      $��Center=�5W      $��18(�5X      
���iii���5Z      �� *	MONTHLIST+$ TwoWay=� 5[      �� *SELECTMONTHTYPE+��5\      �� 5]      .R�5^   "   �� $ 
Horizontal=�6-   .+�5_   &   �� ��60   �� *MONTH+�� 5`   &   $	�� / ��60   �� 5a   &   ��60   �� *YEAR+5b   #   5c      ��5e      �� 5f      " ��6$   .�5g   "   ��  �@��
IsSelected 6?   �� *
ISSELECTED+5h      5j      5k      5l      &   System.Windows.Controls.DataGrid  5n      -   5          Name$ dgDashboard��5o      $��1��5p      $	��450��5q      $��
0,20.4,0,0q�5r      $	��Top=�5s       J� 	AllowDrop .    AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .    
IsReadOnly . "   VerticalScrollBarVisibility$ Visible=�5}      ��5{      �� *
RecordList+ �� SelectedItem 5|      �� *SelectedItem+ J� InputBindings 5~      d� 5       d� Gesture$ LeftDoubleClicka�5�       �� Command 5�      �� *SelectedCommand+ �� CommandParameter 5�      ��  �� ElementName$ contentControlMain��5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 5�         
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