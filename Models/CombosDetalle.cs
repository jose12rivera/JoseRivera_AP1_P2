using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseRivera_AP1_P2.Models;

public class CombosDetalle
{
    [Key]
    public int DetalleId { get; set; }
    public int ComboId { get; set; }
    [ForeignKey("ComboId")]
    public Combos? Combos { get; set; }

    public int ArticuloId { get; set; }
    [ForeignKey("ArticuloId")]
    public Articulos? Articulos { get; set; }
    public decimal? Cantidad {get; set;}
    public decimal? Costo{get; set;}
}
