   M S B A M L   `   `   `  ����M  IMiQueridoEnfermito, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MiQueridoEnfermitoMiQueridoEnfermito  5   	   !    MiQueridoEnfermito.Producto   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MiQueridoEnfermito     5   	     � Title$  Producto��5   	   $	��300��6   $	��300��6'   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6    $��2��6-   $
��73,0q�6A   .��6P   Catalogo de Productos6g   �� 5   
   $��0��6   $��1��6    .��6.   Nombre del Producto:6D   �� 5   
   $��0��6   $��2��6    .��6.   Descripcion:6<   �� 5   
   $��0��6   $��3��6    .��6.   Precio de Compra:6A   �� 5   
   $��0��6   $��4��6    .��6.   Precio de Venta:6@   �� 5   
   $��0��6   $��5��6    .��6-   Presentacion6;   �� 5   
   -   5         ��Name$ txbNombreProducto��5      $��1��6-   $��1��6=   6M   �� 5   
   -   5        $ txbDescripcion��5      $��1��6*   $��2��6:   6J   �� 5    
   -   5        $ txbPrecioCompra��5       $��1��6+   $��3��6;   6K   �� 5!   
   -   5        $ txbPrecioVenta��5!      $��1��6*   $��4��6:   6J   �� 5"   
   -   5        $ txbPresentacion��5"      $��1��6+   $��5��6;   6K   � 5#   
   $��6��6   $��2��6!   .+�5$      �� -   5         ��Name$ btnNuevo��5$       $��70��6   .��6I   Nuevo6P   �� 5%      -   5        $ 
btnGuardar��5%       $��70��6   .��6M   	Guardar6V   �� 5&      -   5        $ 	btnEditar��5&       $��70��6   .��6K   Editar6S   �� 5'      -	   5        $ btnCancelar��5'       $��70��6   .��6O   
Cancelar6Y   �� 5(      -
   5        $ btnEliminar��5(       $��70��6   .��6O   
Eliminar6Y   5)      &   System.Windows.Controls.DataGrid  5*   
   -   5          Name$ dtgProducto��5*      $��7��6(      
IsReadOnly . $��2��6G   6_   5+      5,      