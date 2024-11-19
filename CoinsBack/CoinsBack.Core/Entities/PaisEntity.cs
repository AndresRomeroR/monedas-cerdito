using System.ComponentModel.DataAnnotations.Schema;

namespace CoinsBack.Core.Entities;

public class PaisEntity
{
    [Column("id")]
    public int Id { get; set; }

    [Column("codigo_pais")]
    public string CodigoPais { get; set; }

    [Column("nombre_pais")]
    public string NombrePais { get; set; }

    [Column("status_pais")]
    public bool StatusPais { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
