   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      ? ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HRMS.HR.uConHRMS.HR.uCon 5      5clr-namespace:HRMS.HR.ViewModelHRMS.HR.ViewModel 5
         HRMS.HR.uCon.uConReport   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      FChart4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:HRMS.HR.uCon     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      /	viewmodelclr-namespace:HRMS.HR.ViewModel  5
      $	��880��5      $	��600��5        � 	Resources  5         WrapText �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6!   .�5      ��  � ��$
 Wrap=�6-   �� 5       �@��TextAlignment$
 Left=�68   5      5      .��5      �� -   5         ��Name$ contentControlMain��5      .��5   
   � .+�5      � $��0,20,0,0q�6    � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   .+�5       �� $��
40,10,0,10q�6    �� Orientation$ 
Horizontal=�61   .+�5"      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5#      $��30��5$      $��Center=�5%      
���iii�   Kind$ Search=�5'      �� 5(      -   5         ��Name$ tbSearch��5)      $	��250��5*      $��5,0,0,0q�5+      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Search ��5,      $��18(�5-      ��5.      �� *SEARCH_TEXT+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� Mode$ TwoWay=��� 50      $	��100��51      $��8,0,0,0q�52      $��Center=�53      $��Center=�54       �� DisplayMemberPath$
 NAME��55      $��18(�56      
���iii���58      �� *
ListType+$ TwoWay=� �� SelectedValue 59      �� *SELECTEDTYPE+��5:      �� 5;      " ��6$   .�5<   "   ��  �@��
IsSelected 6?   �� *
ISSELECTED+5=      5?      �� 5A      $��1��5B      $��30,0,0,-0.4q�5C      $��Right=�5D      $ 
Horizontal=�5E      .+�5F        $��30��5G      $��30��5H      $��Center=�5I      
���iii�$ Calendar=�5K      �� 5M      $��8,0,0,0q�5N      $��Right=�5O      $��Center=�5P      $��18(�5Q      
���iii���5S      �� *	MONTHLIST+$ TwoWay=� 5T      �� *SELECTMONTHTYPE+��5U      �� 5V   "   .R�5W   &   �� $ 
Horizontal=�61   .+�5X   *   �� ��64   �� *MONTH+�� 5Y   *   $	�� / ��64   �� 5Z   *   ��64   �� *YEAR+5[   '   5\   #   ��5^      �� 5_   "   " ��6(   .�5`   &   ��  �@��
IsSelected 6C   �� *
ISSELECTED+5a   #   5c      5d      �� 5e      $��1��5f      $��30,0,0,-0.4q�5g      $��Right=�5h      $ 
Horizontal=�5i      .+�5j        $��30��5k      $��30��5l      $��Center=�5m      
���iii�$
 Home=�5o      �� 5q      $��8,0,0,0q�5r      $��Center=�5s      $��Center=�5t      $��18(�5u      
���iii���5w      �� *
DEPTLIST+$ TwoWay=� 5x      �� *SELECTDEPTTYPE+��5y      �� 5z   "   .R�5{   &   �� $ 
Horizontal=�61   .+�5|   *   �� ��64   �� *	DEPT_NAME+5}   '   5~   #   ��5�      �� 5�   "   " ��6(   .�5�   &   ��  �@��
IsSelected 6C   �� *
ISSELECTED+5�   #   5�      5�      5�      &   System.Windows.Controls.DataGrid  5�      -   5          Name$ dgTimekeeping��5�      $��1��5�      $	��430��5�      $��
0,20.4,0,0q�5�      $	��Top=�5�       J� 	AllowDrop .    AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .    
IsReadOnly . "   VerticalScrollBarVisibility$ Visible=�5�      ��5�      �� *TimekeepingList+ �� SelectedItem 5�      �� *SELECTEDITEM+ J� InputBindings 5�      d� 5�       d� Gesture$ LeftDoubleClicka�5�       �� Command 5�      �� *showDetailCommand+ �� CommandParameter 5�      ��  �� ElementName$ contentControlMain��5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 5�         
Foreground
 �OO/�    Header$  ID��5�      1  +System.Windows.Controls.DataGridBoundColumn!   Binding! 5�      �� *EMPLOYEE_ID+$
 PropertyChanged=�5�        5�      $
 auto 5�      "   ElementStyle#" [  5�      
 �OO/�$
  Name��5�      ! 5�      �� *NAME+$
 PropertyChanged=�5�        5�      $
 auto 5�      
 �OO/�$  
Department��5�      ! 5�      �� *DEPT+$
 PropertyChanged=�5�        5�      $
 auto 5�      
 �OO/�$
  Role��5�      ! 5�      �� *ROLE+$
 PropertyChanged=�5�        5�      $
 auto 5�      #" [  5�      
 �OO/�$  	Work days��5�      ! 5�      �� *WORK+$
 PropertyChanged=�5�        5�      $
 auto 5�      #" [  5�      
 �OO/�$  Absent days��5�      ! 5�      �� *ABSENT+$
 PropertyChanged=�5�        5�      $
 auto 5�      #" [  5�      
 �OO/�$  Overtime days��5�      ! 5�      �� *
OVERTIME+$
 PropertyChanged=�5�        5�      $
 auto 5�      #" [  5�      
 �OO/�$  Standard working days��5�      ! 5�      �� *
STANDARD+$
 PropertyChanged=�5�      5�      �� 5�      $��2��5�      $��Right=�5�      $ 
Horizontal=�5�      .+�5�      �� $	��150��5�      $��50��5�      $��
10,10,50,0q�5�      $��
Export PDF��5�      $��18(�5�      $��Light"�5�      ��5�      �� *ExportPDFCommand+��5�      �� $ dgTimekeeping��5�      �� 5�      $	��150��5�      $��50��5�      $��
10,10,50,0q�5�      $��Export Excel��5�      $��18(�5�      $��Light"�5�      ��5�      �� *ExportExcelCommand+��5�      �� $ dgTimekeeping��5�      5�      5�      5�      5�      5�      