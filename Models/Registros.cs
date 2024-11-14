using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace JoseRivera_AP1_P2.Models;

public class Registros
{
    [Key]
    public int RegistroId { get; set; }
    [Required(ErrorMessage ="Por Favor llenar el Campos")]
    public string? Nombre{ get; set; }
    [Required(ErrorMessage = "Por Favor llenar el Campos")]
    public string? Descripcion { get;set; }
}
