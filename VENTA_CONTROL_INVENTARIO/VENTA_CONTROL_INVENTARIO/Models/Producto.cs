using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VENTA_CONTROL_INVENTARIO.Models
{
        public class Producto
        {
            [Key]
            public int ProductoId { get; set; }

            [Required]
            [MaxLength(50)]
            public string Codigo { get; set; } = string.Empty;

            [Required]
            [MaxLength(100)]
            public string Nombre { get; set; } = string.Empty;

            [MaxLength(250)]
            public string Descripcion { get; set; } = string.Empty;

            [Column(TypeName = "decimal(10,2)")]
            public decimal PrecioCompra { get; set; }

            [Column(TypeName = "decimal(10,2)")]
            public decimal PrecioVenta { get; set; }

            public int Stock { get; set; }

            public int StockMinimo { get; set; }

            [Required]
            [MaxLength(30)]
            public string UnidadMedida { get; set; } = string.Empty;

            public DateTime? FechaVencimiento { get; set; }

            // Clave foránea FK
            public int CategoriaId { get; set; }

            public int? ProveedorId { get; set; }

            // Propiedades de navegación
            [ForeignKey("CategoriaId")]
            public virtual Categoria? Categoria { get; set; }

            [ForeignKey("ProveedorId")]
            public virtual Proveedor? Proveedor { get; set; }

            public DateTime FechaCreacion { get; set; } = DateTime.Now;

            public void ValidarReglasDeNegocio()
            {
                if (string.IsNullOrWhiteSpace(Codigo) || Codigo.Length < 3)
                {
                    throw new InvalidOperationException("El código del producto debe contener al menos 3 caracteres.");
                }

                if (string.IsNullOrWhiteSpace(Nombre) || Nombre.Length < 3)
                {
                    throw new InvalidOperationException("El nombre del producto debe contener al menos 3 caracteres.");
                }

                if (PrecioCompra < 0)
                {
                    throw new InvalidOperationException("El precio de compra no puede ser negativo.");
                }

                if (PrecioVenta <= 0)
                {
                    throw new InvalidOperationException("El precio de venta debe ser mayor a cero.");
                }

                if (PrecioVenta < PrecioCompra)
                {
                    throw new InvalidOperationException("El precio de venta no puede ser menor al precio de compra.");
                }

                if (Stock < 0)
                {
                    throw new InvalidOperationException("El stock no puede ser negativo.");
                }

                if (StockMinimo < 0)
                {
                    throw new InvalidOperationException("El stock mínimo no puede ser negativo.");
                }

                if (string.IsNullOrWhiteSpace(UnidadMedida))
                {
                    throw new InvalidOperationException("Debe especificar la unidad de medida.");
                }
            }
        }
    
    
}
