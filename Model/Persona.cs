

namespace Model;

public partial class Persona
{
    public int Id { get; set; }

    public string? Nombre { get; set; }


    public int? Edad { get; set; }


    public int DepartamentoId { get; set; } // Clave foránea

    

}
