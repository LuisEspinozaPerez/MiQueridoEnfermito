   M S B A M L   `   `   `  ����M  IMiQueridoEnfermito, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MiQueridoEnfermitoMiQueridoEnfermito  5   	       MiQueridoEnfermito.Ventas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MiQueridoEnfermito     5   	     � Title$  Ventas��5   	   $	��380��6   $	��350��6%   .��5	      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��2��6   $��	88,0,58,0q�6$   .��68   Mi Querido Enfermito6N   �� 5   
   $��2��6   $��0��6   .��6-   	Cliente66   �� 5   
   -   5         ��Name$ 
cmbCliente��5   0   $��1��6   $��2��6#   6G   �� 5   
   $��1��6   $��0��6   .��6-   
Empleado67   �� 5   
   -   5        $ cmbEmpleado��5   1   $��1��6   $��1��6!   6H   �� 5   
   $��3��6   $��0��6   .��6-   	Productos68   � 5   
    � Orientation$ Vertical=�6   $��4��6+   $��0��68   .+�5       �� .��6   	Cantidad:6   �� 5!      .��6   	Precio:6   5$      � 5%   
   $ Vertical=�6   $��4��6+   $��1��68   .+�5&      �� -   5         ��Name$ txbcantidad��5&   "   $��25��6   6"   �� 5'      -   5        $ 	txbprecio��5'   "   $��25��6   6"   5*      �� 5+   
   -   5        $ cmbProductos��5+   0   $��3��6   $��1��6    6H   �� 5,   
   $��6��6   .��6   Total a Pagar:6-   �� 5-   
   -   5        $ txbTotalPagar��5-   /   $��6��6   $��1��6   6H   � 5.   
   $��5��6   $��2��6!   .+�5/      �� -   5         ��Name$ btnTotalPagar��5/      .��6H   Total a pagar6W   50      �� 51   
   -   5        $ btnGenerarVenta��51   2   $��7��6   $��2��6   .��6i   Generar Ticket6y   52      53      