   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HRMS.Director.ViewHRMS.Director.View  5      5clr-namespace:HRMS.HR.ViewModelHRMS.HR.ViewModel  5      %    HRMS.Director.View.uConHRReport   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:HRMS.Director.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      /	viewmodelclr-namespace:HRMS.HR.ViewModel  5      $	��880��5	      $	��620��5
        � 	Resources  5         WrapText �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6!   .�5      ��  � ��$
 Wrap=�6-   �� 5       �@��TextAlignment$
 Left=�68   5      5      .��5      � .+�5   
   � $��0,20,0,0q�6    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��
40,10,0,10q�6    �� Orientation$ 
Horizontal=�6-   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5       $��30��5!      $��Center=�5"      
���iii�   Kind$ Search=�5$      �� 5%      -   5         ��Name$ tbSearch��5&      $	��250��5'      $��5,0,0,0q�5(      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search ��5)      $��18(�5*      ��5+      �� *SEARCH_TEXT+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� Mode$
 TwoWay=��� 5-      $	��100��5.      $��8,0,0,0q�5/      $��Center=�50      $��Center=�51       �� DisplayMemberPath$
 NAME��52      $��18(�53      
���iii���55      �� *
ListType+$
 TwoWay=� �� SelectedValue 56      �� *SELECTEDTYPE+��57      �� 58      " ��6    .�59      ��  �@��
IsSelected 6;   �� *
ISSELECTED+5:      5<      �� 5>      $��1��5?      $��30,0,0,-0.4q�5@      $��Right=�5A      $ 
Horizontal=�5B      .+�5C        $��30��5D      $��30��5E      $��Center=�5F      
���iii�$ Calendar=�5H      �� 5J      $��8,0,0,0q�5K      $��Right=�5L      $��Center=�5M      $��18(�5N      
���iii���5P      �� *	MONTHLIST+$
 TwoWay=� 5Q      �� *SELECTMONTHTYPE+��5R      �� 5S      .R�5T   "   �� $ 
Horizontal=�6-   .+�5U   &   �� ��60   �� *MONTH+�� 5V   &   $	�� / ��60   �� 5W   &   ��60   �� *YEAR+5X   #   5Y      ��5[      �� 5\      " ��6$   .�5]   "   ��  �@��
IsSelected 6?   �� *
ISSELECTED+5^      5`      5a      �� 5b      $��1��5c      $��30,0,0,-0.4q�5d      $��Right=�5e      $ 
Horizontal=�5f      .+�5g        $��30��5h      $��30��5i      $��Center=�5j      
���iii�$
 Home=�5l      �� 5n      $��8,0,0,0q�5o      $��Center=�5p      $��Center=�5q      $��18(�5r      
���iii���5t      �� *
DEPTLIST+$
 TwoWay=� 5u      �� *SELECTDEPTTYPE+��5v      �� 5w      .R�5x   "   �� $ 
Horizontal=�6-   .+�5y   &   �� ��60   �� *	DEPT_NAME+5z   #   5{      ��5}      �� 5~      " ��6$   .�5   "   ��  �@��
IsSelected 6?   �� *
ISSELECTED+5�      5�      5�      5�      &   System.Windows.Controls.DataGrid  5�      -   5          Name$ dgTimekeeping��5�      $��1��5�      $	��450��5�      $��0,20.4,20,0q�5�      $	��Top=�5�       J� 	AllowDrop .    AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .    
IsReadOnly . "   VerticalScrollBarVisibility$ Visible=�5�      ��5�      �� *TimekeepingList+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 5�         
Foreground
 �OO/�   Header$ ID��5�      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�      �� *EMPLOYEE_ID+$	 PropertyChanged=�5�        5�      $
 auto 5�         ElementStyle# [  5�      
 �OO/�$
 Name��5�       5�      �� *NAME+$	 PropertyChanged=�5�        5�      $
 auto 5�      
 �OO/�$ 
Department��5�       5�      �� *DEPT+$	 PropertyChanged=�5�        5�      $
 auto 5�      
 �OO/�$
 Role��5�       5�      �� *ROLE+$	 PropertyChanged=�5�        5�      $
 auto 5�      # [  5�      
 �OO/�$ 	Work days��5�       5�      �� *WORK+$	 PropertyChanged=�5�        5�      $
 auto 5�      # [  5�      
 �OO/�$ Absent days��5�       5�      �� *ABSENT+$	 PropertyChanged=�5�        5�      $
 auto 5�      # [  5�      
 �OO/�$ Overtime days��5�       5�      �� *
OVERTIME+$	 PropertyChanged=�5�        5�      $
 auto 5�      # [  5�      
 �OO/�$ Standard working days��5�       5�      �� *
STANDARD+$	 PropertyChanged=�5�      5�      5�      5�      5�      