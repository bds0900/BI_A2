   M S B A M L   `   `   `  ����?  ;A2-2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:A2_2A2_2  5   	       A2_2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:A2_2     5   	   c _DevExpress.Xpf.Charts.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxc4http://schemas.devexpress.com/winfx/2008/xaml/charts  5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      � -   5         �Name$ ChartControl��5
      $��-1,-2,0.6,2q�6!   .+�5   
   (  "DevExpress.Xpf.Charts.ChartControl  $
��Left=�6   $��
283,19,0,0q�66   $	��Top=�6J   $	��386��6b   $	��501��6o   ,  &DevExpress.Xpf.Charts.ChartControlBase   Titles 5      !  DevExpress.Xpf.Charts.Title  5      %  DevExpress.Xpf.Charts.TitleBase   Content$ Rejection Reason Chart��6   $
��Bold"�6=   $��16(�6O   $��0q�6]   (  "DevExpress.Xpf.Charts.ChartElement   Width$	 178Q�6h      Legends 5      "  DevExpress.Xpf.Charts.Legend  5      $��	0,0.4,0,0q�6   $	 104Q�60      Diagram. 5      '  !DevExpress.Xpf.Charts.XYDiagram2D  -   5          Name$ ParetoChart��5      $��
0,10,0,0.8q�63   $	 375Q�6G      DefaultPane 5         DevExpress.Xpf.Charts.Pane  5      	   AxisY	 5      #	  DevExpress.Xpf.Charts.AxisY2D	  5       
  DevExpress.Xpf.Charts.Axis
 
  Title
 5      %  DevExpress.Xpf.Charts.AxisTitle  5      $ Number of Reason��6,   $��12(�6G   5         SecondaryAxesY 5      ,  &DevExpress.Xpf.Charts.SecondaryAxisY2D  5      
 5         5!      $ 
Percentage��6,   $��12(�6A   5#         AxisX 5%      #  DevExpress.Xpf.Charts.AxisX2D  5&      $��1(�6"   
 5'        5(      $ Reasons' Name��6,   $��12(�6D   5*      #  DevExpress.Xpf.Charts.Diagram   Series. 5,      1  +DevExpress.Xpf.Charts.BarSideBySideSeries2D  "  DevExpress.Xpf.Charts.Series   DisplayName$ Reason��6,   $��9(�6A     5-      $ 
Cumulative��6,   $��9(�6E   5.      5/      �� 50   
   -   5         ��Name$ lbx_product��50      $
��Left=�6'   $��33��6B   $��	85,31,0,0q�6N   $	��Top=�6a   $	��173��6y   �� 51   
   $��Product��6   $
��Left=�6"   $��	21,34,0,0q�6=   $	��Top=�6P   $��59��6h   $��14(�6s   �� 52   
   $��Total parts molded��6   $
��Left=�6-   $��
21,138,0,0q�6H   $	��Top=�6\   $	��118��6t   $��14(�6�   $��Arial Narrow)�6�   �� 53   
   $��Yield at Mold��6   $
��Left=�6(   $��
21,197,0,0q�6C   $	��Top=�6W   $��97��6o   $��14(�6z   $��Arial Narrow)�6�   �� 54   
   $(��"Total parts successfully assembled��6   $
��Left=�6=   $��
21,287,0,0q�6X   $	��Top=�6l   $	��205��6�   $��14(�6�   $��Arial Narrow)�6�   �� 55   
   $��Total parts packaged��6   $
��Left=�6/   $��
21,351,0,0q�6J   $	��Top=�6^   $	��130��6v   $��14(�6�   $��Arial Narrow)�6�   �� 56   
   $��Yield at Paint��6   $
��Left=�6)   $��
21,256,0,0q�6D   $	��Top=�6X   $��87��6p   $��14(�6{   $��Arial Narrow)�6�   �� 57   
   $%��Total parts successfully molded��6   $
��Left=�6:   $��
21,166,0,0q�6U   $	��Top=�6i   $	��202��6�   $��14(�6�   $��Arial Narrow)�6�   �� 58   
   $%��Total parts sucessfully painted��6   $
��Left=�6:   $��
21,226,0,0q�6U   $	��Top=�6i   $	��190��6�   $��14(�6�   $��Arial Narrow)�6�   �� 59   
   $��Yield at Assembly��6   $
��Left=�6,   $��
21,319,0,0q�6G   $	��Top=�6[   $	��113��6s   $��14(�6   $��Arial Narrow)�6�   �� 5:   
   $��Total Yield��6   $
��Left=�6&   $��
21,383,0,0q�6A   $	��Top=�6U   $��74��6m   $��14(�6x   $��Arial Narrow)�6�   �� 5;   
   -   5         ��Name$ tlt_mod��5;   5   $
��Left=�6F   $��142,138,0,0q�6a   $
��Wrap=�6v   $	��Top=�6�   $��69��6�   ���	#FFE9EEA9$��23��6�   ��6   �� *part_total_mod+6�   �� 5<   
   -   5        $ suc_mod��5<   3   $
��Left=�6D   $��206,166,0,0q�6_   $
��Wrap=�6t   $	��Top=�6�   $��64��6�   ���	#FFE9EEA9$��23��6�   ��6   �� *part_suc_mod+6�   �� 5=   
   -   5        $ yld_mod��5=   0   $
��Left=�6A   $��114,197,0,0q�6\   $
��Wrap=�6q   $	��Top=�6�   $��72��6�   ���	#FFE9EEA9$��23��6�   ��6   �� *	yield_mod+6�   �� 5>   
   -   5        $ tlt_suc_pntd��5>   8   $
��Left=�6N   $��201,226,0,0q�6i   $
��Wrap=�6~   $	��Top=�6�   $��69��6�   ���	#FFE9EEA9$��23��6�   ��6   �� *total_suc_painted+6�   �� 5?   
   -   5        $ tlt_suc_asmbd��5?   7   $
��Left=�6N   $��206,286,0,0q�6i   $
��Wrap=�6~   $	��Top=�6�   $��64��6�   ���	#FFE9EEA9$��23��6�   ��6   �� *total_suc_asmbld+6�   �� 5@   
   -	   5        $ yld_pnt��5@   2   $
��Left=�6C   $��135,256,0,0q�6^   $
��Wrap=�6s   $	��Top=�6�   $��76��6�   ���	#FFE9EEA9$��23��6�   ��6   �� *yield_point+6�   �� 5A   
   -
   5        $ yld_asmb��5A   2   $
��Left=�6D   $��142,317,0,0q�6_   $
��Wrap=�6t   $	��Top=�6�   $	��105��6�   ���	#FFE9EEA9$��23��6�   ��6   �� *yield_asmbl+6�   �� 5B   
   -   5        $ tlt_pakd��5B   2   $
��Left=�6D   $��143,350,0,0q�6_   $
��Wrap=�6t   $	��Top=�6�   $	��104��6�   ���	#FFE9EEA9$��23��6�   ��6   �� *total_pakgd+6�   �� 5C   
   -   5        $ tlt_yld��5C   3   $
��Left=�6D   $��101,383,0,0q�6_   $
��Wrap=�6t   $	��Top=�6�   $	��125��6�   ���	#FFE9EEA9$��23��6�   ��6   �� *total_yield+6�   5E      5F      