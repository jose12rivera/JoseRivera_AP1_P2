using System.ComponentModel.DataAnnotations;

namespace JoseRivera_AP1_P2.Models;

public class Articulos
{
    [Key]
    public int ArticuloId { get; set; }
    [Required(ErrorMessage ="Intentar de nuevo")]
    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }
   
}
