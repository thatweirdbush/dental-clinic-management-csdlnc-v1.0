   M S B A M L   `   `   `  ����Q  MDentalClinicManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:DentalClinicManagement.AdminDentalClinicManagement.Admin  5      S.clr-namespace:DentalClinicManagement.Converter DentalClinicManagement.Converter  6@   2    ,DentalClinicManagement.Admin.ReportTreatment   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:DentalClinicManagement.Admin     5      E
converters.clr-namespace:DentalClinicManagement.Converter     6@     N� Title$  ReportTreatment��5	       � 	Resources 5      8   2DentalClinicManagement.Converter.AbsoluteConverter   absoluteConverter��%   &	          5   
   6'   5      .��5      �� 
�������.+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $	��100��6   $
��1200��6"   ���#39A7FF.+�5      �� $"��Báo cáo các điều trị��6   $��40(�68   $
��Bold"�6F   $
��Left=�6X   $��53��6s    �� Left$ 69��6   
�������
 �� Top$ 23��6�   $��Center=�6�   $	��463��6�   �� 5      $��../images/teeth.jpg��6   $	��127��65   $	��112��6A   $
 1063��6N   $ -6��6a   5      �� 5      $ 
Horizontal=�6   .+�5      �� $	��621��6   $
��1199��6&   
�������.+�5      �� -   5        $��fromDate��5       $��
Từ Ngày��60   $��20(�6?   $��33��6M   $ 23��6Y   
���   �$ 34��6}   $	��106��6�   $
��Left=�6�   $	��Top=�6�   (  "System.Windows.Controls.DatePicker  5      -   5        $��fromDatePicker��5   !   $	��242��67   $��30��6C   $ 23��6O   $ 67��6`   $
��Left=�6p   $��Center=�6�   �� 5      -   5        $��Patient��5       $��Bệnh nhân��6/   $��20(�6@   $��31��6N   $ 26��6Z   
���   �$	 136��6~   $	��100��6�   $
��Left=�6�   $	��Top=�6�   �� 5      -   5        $��ReportTreatListView��5      $	��325��6:   $	��754��6G   $	 222��6S   $	 245��6e   $��Center=�6v   $��Center=�6�   $��Center=�6�    �� View 5      �� 5      .P�5   "   �� $��Mã điều trị��61    �� Width$	 150��6F    �� DisplayMemberBinding 6R   �� *ConductedTreatmentID+�� 5   "   $��Ngày điều trị��61   $	 150��6H    6T   �� *Date+�� 5   "   $��Tên bệnh nhân��61   $	 300��6H    6T   �� *Name+�� 5    "   $��Trạng thái��61   $	 150��6E    6Q   �� *Status+5!      5#        5$      -   5          Name$ toDatePicker��5$   !   $	��300��67   $��30��6C   $	 359��6O   $ 67��6a   $
��Left=�6q   $��Center=�6�   �� 5%      -   5        	 ��Name$	 toDate��5%       $��Đến ngày��60   $��20(�6@   $��33��6N   $	 359��6Z   
���   �$ 34��6   $	��106��6�   $
��Left=�6�   $��Center=�6�   �� 5&      -   5        $��PatientSearch��5&      $ 26��63   
 �� TextWrapping$

 Wrap=�6D   $	 172��6X   $	��304��6i   $
��Left=�6u   $��Center=�6�   $��37��6�   $��22(�6�   �� 5'      -   5         ��Name$ FilterButton��5'      $��Lọc��63   $	��176��6A   $��49��6M    �� 	IsDefault$
 True��6Y   $��24(�6j   ���	#FF39A7FF$	 987��6�   $	 141��6�   $��Center=�6�   $��Center=�6�    5(       �� 
TargetType �� Property �� Value��%_   '��       �� 5)      " ��6$   .�5*   "   ��  �@��CornerRadius$ 20��6A   5+      5,      5-      5.      5/      50      �� 51   
   -	   5        $��
HomeButton��51      $��Trang chủ��6#   $	��176��67   $��49��6C   $
 True��6O   $��24(�6`   ���	#FF39A7FF$	 987��6�   $	 141��6�   $
��Left=�6�   $	��Top=�6�    52      ��%_   '��       �� 53      " ��6   .�54      ��  �@��CornerRadius$ 20��65   55      56      57      58      59      