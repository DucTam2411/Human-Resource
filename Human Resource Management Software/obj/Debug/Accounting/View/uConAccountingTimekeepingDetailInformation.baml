   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:HRMS.Accounting.ViewHRMS.Accounting.View  5      E    ?HRMS.Accounting.View.uConAccountingTimekeepingDetailInformation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:HRMS.Accounting.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � 	Resources  5         WrapText �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6!   .�5      ��  � ��$
 Wrap=�6-   �� 5       �@��TextAlignment$ Center=�68   5      5      .��5      �� -   5         ��Name$ contentControlDetail��5      .��5   
   �  � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� -   5         ��Name$ btnTest��5       $��3��5!      $��95��5"      $��0,0,10,217.8q�5#      $��Bottom=�5$      
������ $��0q�5&      ��5'      �� *BackCommand+��5(      ��  �� ElementName$ contentControlDetail��.��5*      '  !MaterialDesignThemes.Wpf.PackIcon  $��40��5+      $��40��5,      
���iii�	   Kind$	 	ArrowBack=�5.      5/      �� 57      $��1��58      $��20q�59      
 �� Orientation$
 
Horizontal=�5:      .+�5<      �� $��0,30,0,0q�6   $
 
Horizontal=�6/   .+�5>        $��30��5?      $��30��5@      $��Center=�5A      
���iii�$
	 User=�5C      �� 5D      -   5         ��Name$ tbName��5E      $	��200��5F      $��8,0,0,0q�5G      )  #MaterialDesignThemes.Wpf.HintAssist   
HelperText$ Employee full name.��5H         Hint$
 Name��5I      $��15(�5J       �� 
IsReadOnly . .��5K   +   ��5L      �� 5M       �� Path$ EMPLOYEENAME�6&    �� UpdateSourceTrigger$ PropertyChanged=�6:    �� ValidationRules 5N   "   5O      .��5P   (   5Q      5S      �� 5W      $��	30,30,0,0q�6   $
 
Horizontal=�60   .+�5X        $��30��5Y      $��30��5Z      $��Center=�5[      
���iii�$	 IdCard=�5]      �� 5^      -   5         ��Name$ cbMonth��5_      $	��200��5`      $��8,0,0,0q�5a      $ Choose your month��5b      $ Month��5c      $��15(�5d       �� 
IsEditable .  ��5f      �� *	MONTHLIST+ �� Mode$ TwoWay=� �� SelectedValue 5g      �� *SELECTMONTHTYPE+��5h      �� 5i      .R�5j   "   �� $
 
Horizontal=�6-   .+�5k   &   �� ��60   �� *MONTH+�� 5l   &   $	�� / ��60   �� 5m   &   ��60   �� *YEAR+5n   #   5o      ��5q      �� 5r      " ��6$   .�5s   "   ��  �@��
IsSelected 6?   �� *
ISSELECTED+5t      5v      5x      5{      �� 5}      $��1��5~      $��1��5      $��10q�5�      �� 5�      $��2��5�      $��1��5�      $
 Vertical=�5�      .+�5�      �� 
���iii� ! MaterialDesignButtonTextBlock#��[ 5�      $��Workdays��5�      �� 5�      $	��700��5�      $	��120��5�      $��10,0,0,0q�5�      
���iii�$��1q�5�       �� ItemStringFormat$ {0:dd/MM/yyy}��5�      ��5�      �� *workdayList+�� 5�      $��0,10,0,0q�5�      
���iii�#��[ 5�      $��Absent days��5�      �� 5�      $	��120��5�      $��10,0,0,0q�5�      
���iii�$��1q�5�      $ {0:dd/MM/yyy}��5�      ��5�      �� *absentdayList+�� 5�      $��0,10,0,0q�5�      
���iii�#��[ 5�      $��Overtime days��5�      �� 5�      $	��120��5�      $��10,0,0,0q�5�      
���iii�$��1q�5�      $ {0:dd/MM/yyy}��5�      ��5�      �� *overtimeList+5�      5�      5�      5�      