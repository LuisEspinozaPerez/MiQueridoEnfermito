   M S B A M L   `   `   `  ����M  IMiQueridoEnfermito, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MiQueridoEnfermitoMiQueridoEnfermito  5   	   "    MiQueridoEnfermito.Empleados   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MiQueridoEnfermito     5   	     � Title$  	Empleados��5   	   $	��300��6   $	��300��6(   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��1��6    .��6.   Nombre del Empleado:6D   �� 5   
   $��0��6   $��2��6    .��6.   Numero de Empleado:6C   �� 5   
   -   5         ��Name$ txbNombreEmpleado��5      $��1��6-   $��1��6=   6M   �� 5   
   -   5        $ txbNoEmpleado��5      $��1��6)   $��2��69   6I   � 5   
   $��3��6   $��2��6!   .+�5      �� -   5         ��Name$ btnNuevo��5       $��70��6   .��6I   Nuevo6P   �� 5      -   5        $ 
btnGuardar��5       $��70��6   .��6M   	Guardar6V   �� 5      -   5        $ 	btnEditar��5       $��70��6   .��6K   Editar6S   �� 5      -   5        $ btnCancelar��5       $��70��6   .��6O   
Cancelar6Y   �� 5      -   5        $ btnEliminar��5       $��70��6   .��6O   
Eliminar6Y   5       &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ dtgEmpleados��5!      $��4��6)      
IsReadOnly . $��2��6H   6_   5"      5#      