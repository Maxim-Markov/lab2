   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$>  8Обработчик угроз безопасности��5   	   $��Normal$�6/   $��12(�6B   $	��600��6P   $	��900��6]    � 
ResizeMode$ NoResize=�6i   .��5	      � ��5
   
   
� 5      .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ 	#FFD6FBFF��6   $ 1Q�61   5      .+�5   
   �� -   5        $��RefreshButton��5      $,��&Обновить базу данных��6'   $
��Left=�6F   $��	10,10,0,0q�6a   $	��Top=�6t   $	��139��6�   $��42��6�   $	��100��6�   $��20��6�   $��5��6�    � ForceCursor . ���	#FFD4FFDC$��Center=�6  $	��200��6;  $	��100��6J   J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FF0C0303��6#      
BlurRadius$	 100Q�65   5      � 5   
   -   5        $��progressBar��5      $
��Left=�6*   $��10��6E   $��784,550,0,0q�6Q   $	��Top=�6f   $	��100��6~    J� RenderTransformOrigin$ 1.9,0.7&�6�   �� 5   
   -   5        	 ��Name$	 
SeekButton��5      $A��;Просмотреть перечень всех угроз��6&   $
��Left=�6P   $��
189,10,0,0q�6k   $	��Top=�6   $	��216��6�   $��42��6�   
 J� Opacity$	
 0.7Q�6�   ���	#FFF0ABEC6�   �� 5   
   -   5        $	 DetailsButton��5      $N��HУзнать подробнее о выделенном элементе��6*   $
��Left=�6[   $��
442,10,0,0q�6v   $	��Top=�6�   $	��248��6�   $��42��6�   $	
 0.7Q�6�   ���	#FFF0ABEC6�   �� 5   
   -   5        $	 
SaveButton��5      $-��'Сохранить базу в файл��6&   $
��Left=�6F   $��
735,10,0,0q�6a   $	��Top=�6u   $	��139��6�   $��42��6�   $	��100��6�   $��20��6�    . ���	#FFD4FFDC 5        5      $ 	#FF0C0303��6#   $	 100Q�65   5      �� 5   
   -   5        $��DownloadStatusBox��5      $
��Left=�6,   $��23��6G   $��784,522,0,0q�6S    �� TextWrapping$
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��100��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��ThreadTable��5      $
��Left=�6&   $	��444��6A   $��	10,73,0,0q�6N   $	��Top=�6a   $	��864��6y      AutoGenerateColumns .    CanUserSortColumns .     
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   $y�	Collapsed=�6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��281,500,233,16q�6K   .+�5       �� -	   5        $��btnFirst��5    =   $��23��6   $
��Left=�6!   $��Bottom=�6M   $��40��6h   $��<<��6s   $

 0.75Q�6�   �� 5!      -
   5        $	 btnPrev��5!   =   $��23��6   $��Bottom=�6"   $��40��6N   $

 0.75Q�6o   $��<��6~   $��0,9,0,0q�6�   �� 5"      -   5         ��Name$ lblpageInformation��5"      $��Center=�60   $
��Left=�6T   $��23��6o   $��97��6{   $��Center=�6�   $��Bottom=�6�   �� 5#      -   5        $��btnNext��5#   =   $��23��6   $��Right=�6!   $��Bottom=�6L   $��40��6g   $��>��6r   $

 0.75Q�6�   �� 5$      -   5        $��btnLast��5$   d   $��23��6   $��Right=�6!   $��Bottom=�6>   $��40��6Y   $

 0.75Q�6�   $��>>��6�   �� 5%      -   5         ��Name$ cbNumberOfRecords��5%      $
��Left=�62   $��Bottom=�6N   $	��120��6i    �� SelectedIndex$ 0��6v   $

 0.75Q�6�   $��0,10,0,0q�6�   5&      5'      5(      