   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HRMS.HR.uConHRMS.HR.uCon  5      5clr-namespace:HRMS.HR.ViewModelHRMS.HR.ViewModel  5	      #    HRMS.HR.uCon.uConListEmployee   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:HRMS.HR.uCon     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      /	viewmodelclr-namespace:HRMS.HR.ViewModel  5	      $	��880��5
      $	��620��5        � 	Resources  5         WrapText �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6!   .�5      ��  � ��$
 Wrap=�6-   �� 5       �@��TextAlignment$
 Left=�68   5      5      .��5      �� -   5         ��Name$ contentControlMain��5      $
��auto��61   .��5   
   � $��0,20,0,0q�6   
������  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $	��350 �6    �� 5      $
��auto �6    .+�5#      � $��0��6   $��20q�6    .+�5%      �� $��	-20,0,0,0q�6    �� Orientation$ 
Horizontal=�60   .+�5'      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5(      $��30��5)      $��Center=�5*      
���iii�   Kind$ Search=�5,      �� 5-      $	��370��5.      $��5,0,0,0q�5/      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search ��50      $��18(�51      .��6'   ��52      �� 53      	 �� Path$	 SEARCH_TEXT�6&   
 �� UpdateSourceTrigger$
 PropertyChanged=�69    �� ValidationRules 54   "   55      .��56   (   57      �� 59      $��8,0,0,0q�5:      $��Center=�5;      $��Center=�5<       �� DisplayMemberPath$
 NAME��5=      $��18(�5>      
���iii���5@      �� *
ListType+ �� SelectedValue 5A      �� *SELECTEDTYPE+��5B      �� 5C      " ��6$   .�5D   "   ��  �@��
IsSelected 6?   �� *
ISSELECTED+5E      5G      �� 5H      $��1��5I      $��30,0,0,-0.4q�5J      $��Right=�5K      $ 
Horizontal=�5L      .+�5M        $��30��5N      $��30��5O      $��Center=�5P      
���iii�$
 Home=�5R      �� 5T      $��8,0,0,0q�5U      $��Center=�5V      $��Center=�5W      $��18(�5X      
���iii���5Z      �� *
DEPTLIST+ �� Mode$ TwoWay=� 5[      �� *SELECTDEPTTYPE+��5\      �� 5]   "   .R�5^   &   �� $ 
Horizontal=�61   .+�5_   *   �� ��64   �� *	DEPT_NAME+5`   '   5a   #   ��5c      �� 5d   "   " ��6(   .�5e   &   ��  �@��
IsSelected 6C   �� *
ISSELECTED+5f   #   5h      5i      5n      5o      � 5s      $��1��6   .+�5t      &   System.Windows.Controls.DataGrid  -   5          Name$ dtgvEmployees��5u      $��
0,0,-0.4,0q�5v      $	��Top=�5w       J� 	AllowDrop .    AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .    
IsReadOnly . ��5      �� *	employees+$ TwoWay=� �� SelectedItem 5�      �� *SELECTED_ITEM+ J� InputBindings 5�      d� 5�       d� Gesture$ LeftDoubleClicka�5�       �� Command 5�      �� *DoubleClickCommand+ �� CommandParameter 5�      ��  �� ElementName$ contentControlMain��5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 5�       ) %MaterialDesignDataGridTextColumnStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 5�          
Foreground
  �OO/�!   Header$! ID��5�      "   Binding" 5�      �� *EMPLOYEE_ID+5�        5�      $
 auto 5�      # [  5�      
  �OO/�$
! Name��5�      " 5�      �� *NAME+5�      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5�      $
 auto 5�      # [  5�      
  �OO/�$! 
Department��5�      " 5�      �� *	DEPT_NAME+5�        5�      $
 auto 5�      # [  5�      
  �OO/�$
! Role��5�      " 5�      �� *	ROLE_NAME+5�      5�      5�      �� 5�      -   5        # ��Name$# btnNewEmployee��5�      $��2��5�      $	��160��5�      $��50��5�      $��	10,30,0,0q�5�      $
��Left=�5�      ��5�      �� *
AddCommand+��5�      �� $ contentControlMain��.��5�      �� $ 
Horizontal=�6   .+�5�        $��Center=�6.   $ AccountsAdd=�6I   �� 5�      $��5,0,0,0q�6    $��New Employee��61   5�      5�      5�      5�      5�      