   M S B A M L   `   `   `  ����Q  MBellIntegratorTestTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:BellIntegratorTestTask.ViewsBellIntegratorTestTask.Views  5   	   ;    5BellIntegratorTestTask.Views.EmployeeInsertUpdateView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:BellIntegratorTestTask.Views     5   	   -   5          �Name$   EmployeeInsertUpdateWindow��5   	    � Title$ EmployeeInsertUpdateView��5	   	    � SizeToContent$ WidthAndHeight=�5
   	   .��5      � $	��380��6   $	��360��6   .+�5   
   �� $
��Left=�6   $��	36,43,0,0q�6-    �� TextWrapping$
 Wrap=�6V   $	��Top=�6j   $	��120��6�   ��6@   �� *Name+6�   �� 5   
   $
��Left=�6   $��	36,80,0,0q�6-   $
 Wrap=�6\   $	��Top=�6p   $	��120��6�   ��6@   �� *
SecondName+6�   �� 5   
   $
��Left=�6   $��
36,113,0,0q�6-   $
 Wrap=�6Z   $	��Top=�6n   $	��120��6�   ��6A   �� *	SurName+6�   �� 5   
   $
��Left=�6   $��
36,147,0,0q�6-   $
 Wrap=�6j   $	��Top=�6~   $	��120��6�   ��6A   �� *Age+ �� TargetNullValue$  ��6�   �� 5   
   $
��Left=�6   $��36,0,0,0q�6-   $
 Wrap=�6V   $��Center=�6j   $	��120��6�   ��6?   �� *Phone+6�   �� 5   
   $
��Left=�6   $��
36,221,0,0q�6-   $
 Wrap=�6W   $	��Top=�6k   $	��120��6�   ��6A   �� *Post+6�   �� 5   
   $
��Left=�6   $��
36,258,0,0q�6-   $
 Wrap=�6m   $	��Top=�6�   $	��120��6�   ��6A   �� *Salary+$  ��6�   �� 5   
   $
��Left=�6   $��
36,293,0,0q�6-   $
 Wrap=�6p   $	��Top=�6�   $	��120��6�   ��6A   �� *	Seniority+$  ��6�   �� 5   
   $��Имя��6   $
��Left=�6   $��
219,37,0,0q�69   $	��Top=�6M   $	��107��6e   $��29��6q   �� 5   
   $��Отчество��6   $
��Left=�6#   $��
219,75,0,0q�6>   $	��Top=�6R   $	��107��6j   $��28��6v   �� 5   
   $��Фамилия��6   $
��Left=�6"   $��219,108,0,0q�6=   $	��Top=�6R   $	��107��6j   $��31��6v   �� 5   
   $��Возраст��6   $
��Left=�6"   $��219,140,0,0q�6=   $	��Top=�6R   $	��107��6j   $��32��6v   �� 5   
   $��Телефон��6   $
��Left=�6"   $��	219,0,0,0q�6=   $��Center=�6P   $	��107��6k   $��30��6w   �� 5   
   $��Должность��6   $
��Left=�6$   $��219,217,0,0q�6?   $	��Top=�6T   $	��107��6l   $��31��6x   �� 5   
   $��Зарплата��6   $
��Left=�6#   $��219,253,0,0q�6>   $	��Top=�6S   $	��107��6k   $��27��6w   �� 5   
   $��Опыт��6   $
��Left=�6   $��219,288,0,0q�6:   $	��Top=�6O   $	��107��6g   $��27��6s   �� 5   
   $#��Изменить/Внести��6   $
��Left=�6+   $��109,338,0,0q�6F   $	��Top=�6[   $	��112��6s   ��5      �� *UpdateCommand+��63   ��  �� ElementName$  EmployeeInsertUpdateWindow���� 5   
   $��Отмена��6   $
��Left=�6"   $��269,338,0,0q�6=   $	��Top=�6R   $��73��6j   ��5      �� *CancellCommand+��64   �� $  EmployeeInsertUpdateWindow���� 5    
   $��Center=�61   $��0,10,0,0q�6N   $	��Top=�6`   $	��290��6x   $��28��6�   ��6   �� *WarningLabel+6�   5"      5#      