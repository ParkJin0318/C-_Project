   M S B A M L   `   `   `  ����@  <Kiosk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Kiosk.statsKiosk.stats  5      "    Kiosk.stats.TableProfitsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Kiosk.stats     5        N� Title$  TableProfitsPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��5* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $��3* �6    �� 5      $��1* �6    .+�5      � $��0��6   .+�5      �� -   5         ��Name$ xTable��5      $��	0 20 0 20q�5      $��16(�5      $��Center=�5      
������ $��Disabled=�5      $��Disabled=�5      ��5!      �� 5"      .R�5#      A�  A� Columns$ 3��5$   %    A� Rows$ 3��5%   %   5&      ��5)      �� 5*      .R�5+      �� $��20, 10, 20, 10q�5,   %   $��140px��5-   %   $��140px��5.   %   ��5/   %   �� *
TableColor+.+�50   "   �� $
��42pt(�51   )   $
��Bold"�52   )   
���������50   ,   �� *myTableNumber+53   )   54      55      57      58      � 5:      $��1��6    5;      �� 5<      $��1* �6'   �� 5=      $��1* �6'   .+�5@      � $��0��6   .+�5A      �� -   5         ��Name$ xMenu��5I      $
��Menu��5B      $
��26pt(�5C      $
��Bold"�5D      
�������
���  ��$��10 20 10 20q�5G      5I      5J      � 5L      $��1��6   .+�5M      �� -   5        $ 	xCategory��5U      $��Category��5N      $
��26pt(�5O      $
��Bold"�5P      
�������
���  ��$��10 20 10 20q�5S      5U      5V      5X      5Y      � 5[   
   $��1��6   .+�5\       � -   5          �Name$ 
ChartFrame��5]        � NavigationUIVisibility$ Hidden=�5^      5_      5`      5a      