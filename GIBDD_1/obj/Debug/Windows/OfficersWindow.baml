   M S B A M L   `   `   `  ����  GIBDD_1$    YourProjectName.OfficersWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Офицеры��5   	   $	��450��6   $	��800��6&   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��5q�6.   .+�5      �� $��Поиск:��6   $��0,0,5,0q�6%   �� 5      -   5         ��Name$ SearchTextBox��5      $	��200��6-   �� 5      -   5         ��Name$ SearchButton��5      $��
Найти��6+   $��5,0,0,0q�6;   6L   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ OfficersDataGrid��5      $��1��6-      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *	OfficerId+  5      $ Фамилия��6%   	 66   �� *
LastName+  5      $ Имя��6%   	 62   �� *	FirstName+  5      $ Отчество��6%   	 67   �� *
MiddleName+  5      $ 
Номер��6%   	 64   �� *OfficerNumber+  5      $ Звание��6%   	 65   �� *Title+5      �� 5   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   $��5q�6W   .+�5      �� $ 
Horizontal=�6   $	��540��62   .+�5      �� -   5        $��
Назад��5      $��84��6C   5      �� 5      -   5        $ 	AddButton��5      $��Добавить��6(   $��0,0,5,0q�6;   6L   �� 5      -   5        $ SaveEditButton��5      $��Изменить��6-   $��0,0,5,0q�6@   6Q   �� 5       -   5        $ DeleteButton��5       $��Удалить��6+   $��0,0,5,0q�6=   6N   5!      5"      5#      