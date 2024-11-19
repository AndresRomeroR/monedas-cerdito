using System.ComponentModel.DataAnnotations.Schema;

namespace CoinsBack.Core.Entities;

public class MunicipioEntity
{
    [Column("id")]
    public int Id { get; set; }

    [Column("codigo_municipio")]
    public string CodigoMunicipio { get; set; }

    [Column("nombre_municipio")]
    public string NombreMunicipio { get; set; }

    [Column("status_municipio")]
    public bool StatusMunicipio { get; set; }

    [Column("departamento_id")]
    public string DepartamentoId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
