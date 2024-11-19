using Dapper;
using CoinsBack.Core.Entities;
using CoinsBack.Core.Interfaces;
using CoinsBack.Infrastructure.Data;
using System.Data;
using Npgsql;
using CoinsBack.Core.DTOs;

namespace CoinsBack.Infrastructure.Repositories;

public class PaisRepository : IPaisRepository
{
    private readonly DatabaseContext _context;

    public PaisRepository(DatabaseContext context)
    {
        _context = context;
    }

    // Obtener todos los países
    public async Task<List<PaisEntity>> GetAllAsync()
    {
        try
        {
            using var connection = _context.GetConnection();
            var paises = await connection.QueryAsync(
                QueryConstant.CONSULTAR_TODOS_PAIESES,
                commandType: CommandType.Text
            );

            var paisesList = paises.Select(pais => new PaisEntity
            {
                Id = pais.id,
                CodigoPais = pais.codigo_pais,
                NombrePais = pais.nombre_pais,
                StatusPais = pais.status_pais,
                CreatedAt = pais.created_at,
                UpdatedAt = pais.updated_at
            }).ToList();

            return paisesList;
        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.Error.WriteLine($"Error en la base de datos: {npgsqlEx.Message}");
            throw new Exception("Error al ejecutar el procedimiento almacenado obtener_todos_paises.", npgsqlEx);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error desconocido: {ex.Message}");
            throw new Exception("Ha ocurrido un error inesperado.", ex);
        }
    }

    // Obtener un país por su ID
    public async Task<PaisEntity> GetByIdAsync(int id)
    {
        using var connection = _context.GetConnection();
        var pais = await connection.QuerySingleOrDefaultAsync(
            QueryConstant.CONSULTAR_PAIS_POR_ID,
            new { IdPais = id },
            commandType: CommandType.Text
        );

        var paisEntity = new PaisEntity
        {
            Id = pais.id,
            CodigoPais = pais.codigo_pais,
            NombrePais = pais.nombre_pais,
            StatusPais = pais.status_pais,
            CreatedAt = pais.created_at,
            UpdatedAt = pais.updated_at
        };

        return paisEntity;
    }

    // Crear un nuevo país
    public async Task<PaisEntity> CrearPaisAsync(string codigoPais, string nombrePais)
    {
        using var connection = _context.GetConnection();
        var pais = await connection.QueryFirstOrDefaultAsync(
            QueryConstant.CREAR_PAIS,
            new { CodigoPais = codigoPais, NombrePais = nombrePais },
            commandType: CommandType.Text
        );

        var paisEntity = new PaisEntity
        {
            Id = pais.id,
            CodigoPais = pais.codigo_pais,
            NombrePais = pais.nombre_pais,
            StatusPais = pais.status_pais,
            CreatedAt = pais.created_at,
            UpdatedAt = pais.updated_at
        };

        return paisEntity;
    }

    // Actualizar un país existente
    public async Task<bool> ActualizarPaisAsync(int id, string codigoPais, string nombrePais)
    {
        using var connection = _context.GetConnection();
        var result = await connection.ExecuteScalarAsync<int>(
            QueryConstant.ACTUALIZAR_PAIS,
            new { IdPais = id, CodigoPais = codigoPais, NombrePais = nombrePais },
            commandType: CommandType.Text
        );

        return true;
    }

    // Eliminar un país
    public async Task<bool> EliminarPaisAsync(int id)
    {
        using var connection = _context.GetConnection();
        var result = await connection.ExecuteScalarAsync<int>(
            QueryConstant.ELIMINAR_PAIS,
            new { IdPais = id },
            commandType: CommandType.Text
        );

        return true;
    }
}
