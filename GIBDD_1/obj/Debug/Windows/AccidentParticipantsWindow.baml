   M S B A M L   `   `   `  ����  GIBDD_1(    "GIBDD_1.AccidentParticipantsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Участники ДТП��5   
   $	��450��6    $	��800��6-   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ParticipantsDataGrid��5
      $��0��61      AutoGenerateColumns . 6Y   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��5q�6W   .+�5      �� $ 
Horizontal=�6   $	��520��62   .+�5      �� -   5        $��
Назад��5      $��84��6C   5      �� 5      -   5         ��Name$ 	AddButton��5      $��Добавить��6(   $��0,0,5,0q�6;   6L   �� 5      -   5        $ SaveEditButton��5      $��Изменить��6-   $��0,0,5,0q�6@   6Q   �� 5      -   5        $ DeleteButton��5      $��Удалить��6+   $��0,0,5,0q�6=   6N   5      5      5      