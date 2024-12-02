using System.ComponentModel.DataAnnotations;

namespace JoseRivera_AP1_P2.Models;

public class Combos
{
    [Key]
    public int ComboId { get; set; }
    [Required(ErrorMessage = "Por Favor llenar el Campos")]
    public DateTime? Fecha { get; set; }
    [Required(ErrorMessage = "Por Favor llenar el Campos")]
    public string? Descripcion { get; set; }
    [Required(ErrorMessage = "Por Favor llenar el Campos")]
    public decimal? Precio { get; set; }
    [Required(ErrorMessage = "Por Favor llenar el Campos")]
    public string? Vendido { get; set;}   

    public ICollection<CombosDetalle> CombosDetalles { get; set; }=new List<CombosDetalle>();   
}
