   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HRMS.HR.ViewHRMS.HR.View  5      5clr-namespace:HRMS.HR.ViewModelHRMS.HR.ViewModel  5	      -    'HRMS.HR.View.uConTimekeepingInformation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:HRMS.HR.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      /	viewmodelclr-namespace:HRMS.HR.ViewModel  5	        � 	Resources  5         WrapText �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6!   .�5      ��  � ��$
 Wrap=�6-   �� 5       �@��TextAlignment$
 Left=�68   5      5      .��5      � .+�5   
   � $��0,20,0,0q�6    � ColumnDefinitions 5      �� 5      $	��13* �6#   �� 5      $
��787* �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5!      �� $��1��5"      $��27.339,10,0,10q�5#       �� Orientation$ 
Horizontal=�5$      .+�5&      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5'      $��30��5(      $��Center=�5)      
���iii�   Kind$ Search=�5+      �� 5,      -   5         ��Name$ tbSearch��5-      $	��250��5.      $��5,0,0,0q�5/      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Search ��50      $��18(�51      ��52      �� *SEARCH_TEXT+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� Mode$ TwoWay=��� 54      $	��100��55      $��8,0,0,0q�56      $��Center=�57      $��Center=�58       �� DisplayMemberPath$
 NAME��59      $��18(�5:      
���iii���5<      �� *
ListType+$ TwoWay=� �� SelectedValue 5=      �� *SELECTEDTYPE+��5>      �� 5?      " ��6    .�5@      ��  �@��
IsSelected 6;   �� *
ISSELECTED+5A      5C      �� 5E      $��1��5F      $��30,0,0,-0.4q�5G      $��Right=�5H      $ 
Horizontal=�5I      .+�5J      (  "System.Windows.Controls.DatePicker  $	��100��5K      $��35��5L      $��Center=�5M      $	��Top=�5N      $	 	Pick Date��5O      $��15(�5P         SelectedDate 5Q      �� 5R      $ TwoWay=�5S   !    �� Path$ SELECTED_DATE�5T   !    �� StringFormat$ {0: dd/MM/yyyy}��5U   !   $
 PropertyChanged=�5V   !   5X      5Y      �� 5Z      $��1��5[      $��30,0,0,-0.4q�5\      $��Right=�5]      $ 
Horizontal=�5^      .+�5_        $��30��5`      $��30��5a      $��Center=�5b      
���iii�$
 Home=�5d      �� 5f      $��8,0,0,0q�5g      $��Center=�5h      $��Center=�5i      $��18(�5j      
���iii���5l      �� *
DEPTLIST+$ TwoWay=� 5m      �� *SELECTDEPTTYPE+��5n      �� 5o      .R�5p   "   �� $ 
Horizontal=�6-   .+�5q   &   �� ��60   �� *	DEPT_NAME+5r   #   5s      ��5u      �� 5v      " ��6$   .�5w   "   ��  �@��
IsSelected 6?   �� *
ISSELECTED+5x      5z      5{      5|      &   System.Windows.Controls.DataGrid  5~      -   5          Name$ dgTimekeeping��5      $��1��5�      $��2��5�      $
��auto��5�      $	��470��5�      $��
10,20,10,0q�5�      $	��Top=�5�       J� 	AllowDrop .    AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .    
IsReadOnly . ��5�      �� *TimekeepingList+ �� SelectedItem 5�      �� *SELECTED_ITEM+ J� InputBindings 5�      d� 5�       d� Gesture$ LeftDoubleClicka�6J    �� Command 6#   �� *DoubleClickCommand+6J      Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 5�         
Foreground
 �OO/�    Header$  ID��5�      1  +System.Windows.Controls.DataGridBoundColumn!   Binding! 5�      �� *EMPLOYEE_ID+$
 PropertyChanged=�5�        5�      $
 auto 5�      "   ElementStyle#" [  5�      
 �OO/�$
  Name��5�      ! 5�      �� *NAME+$
 PropertyChanged=�5�        5�      $
 auto 5�      
 �OO/�$  
Department��5�      ! 5�      �� *DEPT+$
 PropertyChanged=�5�        5�      $
 auto 5�      
 �OO/�$
  Role��5�      ! 5�      �� *ROLE+$
 PropertyChanged=�5�        5�      $
 auto 5�      #" [  5�      
 �OO/�$  Month��5�      ! 5�      �� *MONTH+$
 PropertyChanged=�5�        5�      $
 auto 5�      #" [  5�      
 �OO/�$
  Date��5�      ! 5�      �� *DATE+$
 PropertyChanged=�5�        5�      $
 auto 5�      #" [  5�      
 �OO/�$  Session��5�      ! 5�      �� *	SESSION+$
 PropertyChanged=�5�        5�      $
 auto 5�      #" [  5�      
 �OO/�$  
Attendance��5�      ! 5�      �� *
ATTENDANCE+$
 PropertyChanged=�5�      5�      5�      5�      5�      