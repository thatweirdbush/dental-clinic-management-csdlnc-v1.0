   M S B A M L   `   `   `  ����Q  MDentalClinicManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:DentalClinicManagement.AdminDentalClinicManagement.Admin  5      S.clr-namespace:DentalClinicManagement.Converter DentalClinicManagement.Converter  5      3    -DentalClinicManagement.Admin.CheckAppointment   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:DentalClinicManagement.Admin     5      E
converters.clr-namespace:DentalClinicManagement.Converter     5        N� Title$  CheckAppointment��5
       � 	Resources 5      8   2DentalClinicManagement.Converter.AbsoluteConverter   absoluteConverter��%   &	          5   
   6'   5      .��5      �� 
�������.+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $	��100��6   $
��1200��6"   ���#39A7FF.+�5      �� $&�� Xem lịch rảnh của bác sĩ��6   $��40(�6<   $
��Bold"�6J   $
��Left=�6\   $��53��6w    �� Left$ 69��6�   
�������
 �� Top$ 23��6�   $��Center=�6�   $	��463��6�   �� 5      $��../images/teeth.jpg��6   $	��127��65   $	��112��6A   $
 1063��6N   $ -6��6a   5      �� 5      $ 
Horizontal=�6   .+�5      �� $	��634��6   $	��400��6&   ���#FFEED9.+�5      �� $��../images/ava_10.png��6   $	��152��6:   $	��150��6F   $	 124��6S   $ 60��6e   $��Center=�6u   $	��Top=�6�   �� 5      -   5        $��fullname��5       $��Họ và tên:��60   $��15(�6B   $��24��6P   $ 27��6\   
���   �$	 251��6�   $��78��6�   $
��Left=�6�   $	��Top=�6�   �� 5      -   5        $��phone��5       $��Điện thoại:��6-   $��15(�6@   $��24��6N   $ 27��6Z   
���   �$	 295��6~   $	��100��6�   $
��Left=�6�   $	��Top=�6�   �� 5      -   5        $
��year��5       $��
Năm sinh:��6,   $��15(�6=   $��24��6K   $ 27��6W   
���   �$	 339��6{   $��78��6�   $
��Left=�6�   $	��Top=�6�   �� 5      -   5        $��address��5       $��Địa chỉ:��6/   $��15(�6?   $��24��6M   $ 27��6Y   
���   �$	 383��6}   $��78��6�   $
��Left=�6�   $	��Top=�6�   �� 5      -   5        $��email��5       $��Email:��6-   $��15(�6;   $��24��6I   $ 27��6U   
���   �$	 427��6y   $��78��6�   $
��Left=�6�   $	��Top=�6�   �� 5      -   5        $��homePageButton��5      $��Trang chủ��6P   $	��176��6d   $��49��6p    �� 	IsDefault$
 True��6|   $��24(�6�   ���#39A7FF$	 112��6�   $	 541��6�   $
��Left=�6�   $	��Top=�6�    5       �� 
TargetType �� Property �� Value��%_   '��       �� 5      " ��6$   .�5    "   ��  �@��CornerRadius$ 20��6A   5!      5"      5#      5$      �� 5%      $	��634��6   $	��800��6&   
�������.+�5&      �� -   5        $
��Date��5&       $��Ngày��6,   $��20(�68   $��31��6F   $ 23��6R   
���   �$ 36��6v   $��55��6�   $��Center=�6�   $	��Top=�6�   (  "System.Windows.Controls.DatePicker  5'      -   5        $��
datePicker��5'   !   $	��300��63   $��30��6?   $ 23��6K   $ 67��6\   �� 5(      -	   5        $��Schedule��5(       $��Lịch hẹn��60   $��20(�6@   $��31��6N   $ 23��6Z   
���   �$	 112��6~   $	��100��6�   $��Center=�6�   $	��Top=�6�   �� 5)      -
   5        $��listView��5)      $	��317��6/   $	��750��6<   $ 23��6H   $	 153��6Y   $��Center=�6j   $	��Top=�6�   	 �� View	 5*      �� 5+      .P�5,   "   �� $��Giờ hẹn��61   
 �� Width$
 70��6B   �� 5-   "   $��Bệnh nhân��61   $	
 150��6D   �� 5.   "   $��Lời nhắn��61   $	
 550��6C   5/      51      52      53      54      55      56      