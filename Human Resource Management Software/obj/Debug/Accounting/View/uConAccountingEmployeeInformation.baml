   M S B A M L   `   `   `  ����?  ;HRMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:HRMS.Accounting.ViewHRMS.Accounting.View  5      5clr-namespace:HRMS.HR.ViewModelHRMS.HR.ViewModel  5	      <    6HRMS.Accounting.View.uConAccountingEmployeeInformation   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:HRMS.Accounting.View     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      /	viewmodelclr-namespace:HRMS.HR.ViewModel  5	      $	��700��5
      $
��auto��5      
������ .��5      � $��0,20,0,0q�6     � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   ]� $��0��6   $��0,0,0,10q�6!   .+�5      �� $��20q�6   $
��Left=�6%   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��5      $��30��5      $��Center=�5      
���iii�   Kind$
 User=�5       �� 5!      $	��250��5"      $��8,0,0,0q�5#      )  #MaterialDesignThemes.Wpf.HintAssist   
HelperText$ Employee full name.��5$         Hint$
 Name��5%      $��18(�5&       �� 
IsReadOnly . ��5(      �� *NAME+ �� UpdateSourceTrigger$ PropertyChanged=�5)      �� 5+      $��0,20,0,0q�6   $ 
Horizontal=�6/   .+�5,        $��30��5-      $��30��5.      $��Center=�5/      
���iii�$ IdCard=�51      �� 52      $	��250��53      $��8,0,0,0q�54      $ ID Card number��55      $ ID��56      $��18(�57       . ��59      �� *ID+$ PropertyChanged=�5;      �� 5=      $��0,20,0,0q�6   $ 
Horizontal=�6/   .+�5>        $��30��5?      $��30��5@      $��Center=�5A      
���iii�$ House=�5C      �� 5D      $	��250��5E      $��8,0,0,0q�5F      $ Department in company��5G      $ 
Department��5H      $��18(�5I       . ��5K      �� *
DEPARTMENT+$ PropertyChanged=�5L      �� 5N      $��0,20,0,0q�6   $ 
Horizontal=�6/   .+�5O        $��30��5P      $��30��5Q      $��Center=�5R      
���iii�$ CardAccountDetailsStar=�5T      �� 5U      $	��250��5V      $��8,0,0,0q�5W      $! Employee Role in department��5X      $ Position��5Y      $��18(�5Z       . ��5\      �� *ROLE+$ PropertyChanged=�5]      5^      �� 5`      $��1��5a      $	��200��5b      $	��200��5c      $��	20,10,0,0q�5d      $��Right=�5g       J� Opacity$	 100Q�5h      ��5e      �� *BRUSH+��5f      �� *BUTTONTHICKNESS+.��5i      �� -   5         ��Name$	 img��5j      $
��Fill=�5l      ��5k      �� *IMAGE_SOURCE+5l      5m      5o      �� 5q   
   $��1��5r      $��1��5s      $��0,10,0,0q�5t      
���   �$��10q�5v      $	 0.8Q�5w      ]� 5y   
   $��2��5z      $��1��5{      $��	0,0,0,0.2q�5|      .+�5~      ]� $��20q�6   $
��Left=�6$   .+�5�      �� $
��Left=�6   .+�5�      �� $��0,0,0,0q�6!   $ 
Horizontal=�62   .+�5�        $��30��5�      $��30��5�      $��Center=�5�      
���iii�$ Globe=�5�      �� 5�      $	��250��5�      $��8,0,0,0q�5�      $ Employee Citizenship��5�      $ Citizenship��5�      $��18(�5�       . ��5�      �� *CITIZENSHIP+$ PropertyChanged=�5�      �� 5�      $��0,30,0,0q�6!   $ 
Horizontal=�63   .+�5�        $��30��5�      $��30��5�      $��Center=�5�      
���iii�$ Place=�5�      �� 5�      $	��250��5�      $��8,0,0,0q�5�      $ Employee Bierthplace��5�      $ 
Birthplace��5�      $��18(�5�       . ��5�      �� *
BIRTHPLACE+$ PropertyChanged=�5�      �� 5�      $��0,30,0,0q�6!   $ 
Horizontal=�63   .+�5�        $��30��5�      $��30��5�      $��Center=�5�      
���iii�$ GenderMaleFemaleVariant=�5�      �� 5�      $	��250��5�      $��8,0,0,0q�5�      $ Employee Gender��5�      $ Gender��5�      $��18(�5�       . ��5�      �� *GENDER+$ PropertyChanged=�5�      �� 5�      $��0,30,0,0q�6!   $ 
Horizontal=�63   .+�5�        $��30��5�      $��30��5�      $��Center=�5�      
���iii�$ Phone=�5�      �� 5�      $	��250��5�      $��8,0,0,0q�5�      $ Employee phone number��5�      $ Phone Number��5�      $��18(�5�       . ��5�      �� *PHONE+$ PropertyChanged=�5�      5�      5�      ]� 5�      $��40,20,30,20q�6   $
��Left=�6-   .+�5�      �� $
��Left=�6   .+�5�      �� $��0,0,0,0q�6!   $ 
Horizontal=�62   .+�5�        $��30��5�      $��30��5�      $��Center=�5�      
���iii�$ CardAccountDetails=�5�      �� 5�      $	��250��5�      $��8,0,0,0q�5�      $ Employee ID Card��5�      $ ID Card��5�      $��18(�5�       . ��5�      �� *	ID_CARD+$ PropertyChanged=�5�      �� 5�      $��0,30,0,0q�6!   $ 
Horizontal=�63   .+�5�        $��30��5�      $��30��5�      $��Center=�5�      
���iii�$ Calendar=�5�      �� 5�      $	��250��5�      $��8,0,0,0q�5�      $ Employee Birthday��5�      $ Birthday��5�      $��18(�5�       . ��5�      �� *	BIRTHDATE+$ PropertyChanged=�	 �� StringFormat$	 {0: dd/MM/yyyy}��5�      �� 5�      $��0,30,0,0q�6!   $ 
Horizontal=�63   .+�5�        $��30��5�      $��30��5�      $��Center=�5�      
���iii�$ 	Equalizer=�5�      �� 5�      $	��250��5�      $��8,0,0,0q�5�      $ Employee Academic Level��5�      $ Academic Level��5�      $��18(�5�       . ��5�      �� *ACADEMIC_LEVEL+$ PropertyChanged=�5�      �� 5     $��0,30,0,0q�6!   $ 
Horizontal=�63   .+�5       $��30��5     $��30��5     $��Center=�5     
���iii�$ Email=�5     �� 5     $	��250��5	     $��8,0,0,0q�5
     $ Employee Email��5     $ Email��5     $��18(�5      . ��5     �� *EMAIL+$ PropertyChanged=�5     5     5     5     5     5     