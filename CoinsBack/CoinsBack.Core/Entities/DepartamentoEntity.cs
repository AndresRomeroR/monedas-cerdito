using System.ComponentModel.DataAnnotations.Schema;

namespace CoinsBack.Core.Entities;

public class DepartamentoEntity
{
    [Column("id_departamento")]
    public int IdDepartamento { get; set; }

    [Column("codigo_departamento")]
    public string CodigoDepartamento { get; set; }

    [Column("nombre_departamento")]
    public string NombreDepartamento { get; set; }

    [Column("status_departamento")]
    public bool StatusDepartamento { get; set; }

    [Column("pais_id")]
    public int PaisId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
