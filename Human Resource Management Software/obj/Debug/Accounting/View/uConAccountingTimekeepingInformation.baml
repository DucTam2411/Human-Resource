   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:HRMS.Accounting.ViewHRMS.Accounting.View  5      ?    9HRMS.Accounting.View.uConAccountingTimekeepingInformation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:HRMS.Accounting.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��880��5        � 	Resources  5
         WrapText �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6!   .�5      ��  � ��$
 Wrap=�6-   �� 5       �@��TextAlignment$ Center=�68   5      5      .��5      �� -   5         ��Name$ contentControlMain��5      $	��600��61   .��5   
   � $��0,20,0,0q�6    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��
60,10,0,10q�6    �� Orientation$ 
Horizontal=�6-   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5      $��30��5      $��Center=�5      
���iii�   Kind$ Search=�5      �� 5       $	��370��5!      $��5,0,0,0q�5"      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search ��5#      $��18(�5$      ��5%      �� *SEARCH_TEXT+	 �� UpdateSourceTrigger$	 PropertyChanged=��� 5'      -   5        $��cbSearch��5(      $��	30,0,80,0q�5)      $��Center=�5*      $��Center=�5+      
 �� DisplayMemberPath$

 NAME��5,      $��18(�5-      
���iii���5/      �� *
ListType+ �� Mode$ TwoWay=� �� SelectedValue 50      �� *SELECTEDTYPE+��51      �� 52      " ��6    .�53      ��  �@��
IsSelected 6;   �� *
ISSELECTED+54      56      57      &   System.Windows.Controls.DataGrid  59      -   5          Name$ dgTimekeeping��5:      $��1��5;      $	��800��5<      $	��400��5=      $��
0,20.4,0,0q�5>      $	��Top=�5?       J� 	AllowDrop .    AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .    
IsReadOnly . ��5G      �� *TimekeepingList+ �� SelectedItem 5H      �� *SELECTEDITEM+ J� InputBindings 5I      d� 5J       d� Gesture$ LeftDoubleClicka�5M       �� Command 5K      �� *showDetailCommand+ �� CommandParameter 5L      ��  �� ElementName$ contentControlMain��5M         Columns 5O      0  *System.Windows.Controls.DataGridTextColumn  5P      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 5Q      1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [  5S         
Foreground
 �OO/�   Header$ Month��5U          Binding  5R      �� *MONTH+! �� StringFormat$! {0: MM/yyyy}��5U        5V      $
 auto 5W      # [  5Y      
 �OO/�$ 	Day Start��5[        5X      �� *	DAY_START+$! {0: dd/MM/yyyy}��5[        5\      $
 auto 5]      # [  5_      
 �OO/�$ Day End��5a        5^      �� *	DAY_END+$! {0: dd/MM/yyyy}��5a        5b      $
 auto 5c      # [  5e      
 �OO/�$ Total Work Day��5g        5d      �� *TOTAL_WORK_DAY+5g        5h      $
 auto 5i      # [  5k      
 �OO/�$ Total Overtime Day��5m        5j      �� *TOTAL_OVERTIME_DAY+5m        5n      $
 auto 5o      # [  5q      
 �OO/�$ Total Absent Day��5s        5p      �� *TOTAL_ABSENT_DAY+5s      5u      5w      5x      5y      