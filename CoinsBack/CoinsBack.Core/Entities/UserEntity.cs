using System.ComponentModel.DataAnnotations.Schema;

namespace CoinsBack.Core.Entities;

public class UserEntity
{
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre_usuario")]
    public string NombreUsuario { get; set; }

    [Column("telefono_usuario")]
    public string TelefonoUsuario { get; set; }

    [Column("direccion_detalle")]
    public string DireccionDetalle { get; set; }

    [Column("pais_id")]
    public int PaisId { get; set; }

    [Column("departamento_id")]
    public string DepartamentoId { get; set; }

    [Column("municipio_id")]
    public int MunicipioId { get; set; }

    [Column("status_usuario")]
    public bool StatusUsuario { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
