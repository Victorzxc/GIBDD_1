   M S B A M L   `   `   `  ����  GIBDD_1     GIBDD_1.AddViolationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$)  #Добавить нарушение��5   	   $	��470��6$   $	��300��61   .��5      �� $��10q�6   .+�5   
   �� $��Водитель:��6   �� 5   
   -   5         ��Name$ DriverComboBox��5       �� DisplayMemberPath$ LastName��6+   6H   �� 5   
   $��Автомобиль:��6   �� 5	   
   -   5        $ VehicleComboBox��5	      $ RegistrationNumber��6,   �� 5
   
   $ ��Код нарушения:��6   �� 5   
   -   5         ��Name$ ViolationCodeTextBox��5      �� 5   
   $ ��Тип нарушения:��6   �� 5   
   -   5        $ ViolationTypeIdTextBox��5      �� 5   
   $��Место:��6   �� 5   
   -   5        $ LocationTextBox��5      �� 5   
   $ ��Размер штрафа:��6   �� 5   
   -   5        $ FineAmountTextBox��5      �� 5   
   $��Офицер:��6   �� 5   
   -   5        $ OfficerComboBox��5      $ LastName��6,   �� 5   
   $ ��Статус оплаты:��6   �� 5   
   -   5        $ PaymentStatusTextBox��5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��0,10,0,0q�6J   .+�5      �� -	   5         ��Name$ 
SaveButton��5      $��Сохранить��6)   $��0,0,5,0q�6V   �� 5      -
   5        $ CancelButton��5      $��Отмена��6+   6<   5      5      5      