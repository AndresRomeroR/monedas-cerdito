using CoinsBack.Core.DTOs;
using CoinsBack.Core.Entities;
using CoinsBack.Core.Interfaces;
using CoinsBack.Infrastructure.Data;
using Dapper;
using Npgsql;
using System.Data;

namespace CoinsBack.Infrastructure.Repositories;

public class MunicipioRepository : IMunicipioRepository
{
    private readonly DatabaseContext _context;

    public MunicipioRepository(DatabaseContext context)
    {
        _context = context;
    }

    // Obtener todos los municipios
    public async Task<List<MunicipioEntity>> GetAllAsync()
    {
        try
        {
            using var connection = _context.GetConnection();
            var municipios = await connection.QueryAsync(
                QueryConstant.CONSULTAR_MUNICIPIOS,
                commandType: CommandType.Text
            );

            var municipioList = municipios.Select(municipio => new MunicipioEntity
            {
                Id = municipio.id,
                CodigoMunicipio = municipio.codigo_municipio,
                NombreMunicipio = municipio.nombre_municipio,
                StatusMunicipio = municipio.status_municipio,
                DepartamentoId = municipio.departamento_id,
                CreatedAt = municipio.created_at,
                UpdatedAt = municipio.updated_at
            }).ToList();

            return municipioList;
        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.Error.WriteLine($"Error en la base de datos: {npgsqlEx.Message}");
            throw new Exception("Error al ejecutar el procedimiento CONSULTAR_MUNICIPIOS.", npgsqlEx);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error desconocido: {ex.Message}");
            throw new Exception("Ha ocurrido un error inesperado.", ex);
        }
    }

    // Obtener un municipio por su ID
    public async Task<MunicipioEntity> GetByIdAsync(int id)
    {
        try
        {
            using var connection = _context.GetConnection();
            var municipio = await connection.QuerySingleOrDefaultAsync(
                QueryConstant.CONSULTAR_MUNICIPIO_POR_ID,
                new { IdMunicipio = id },
                commandType: CommandType.Text
            );

            var municipioEntity = new MunicipioEntity
            {
                Id = municipio.id,
                CodigoMunicipio = municipio.codigo_municipio,
                NombreMunicipio = municipio.nombre_municipio,
                StatusMunicipio = municipio.status_municipio,
                DepartamentoId = municipio.departamento_id,
                CreatedAt = municipio.created_at,
                UpdatedAt = municipio.updated_at
            };

            return municipioEntity;

        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.Error.WriteLine($"Error en la base de datos: {npgsqlEx.Message}");
            throw new Exception("Error al ejecutar el procedimiento almacenado CONSULTAR_MUNICIPIO_POR_ID.", npgsqlEx);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error desconocido: {ex.Message}");
            throw new Exception("Ha ocurrido un error inesperado.", ex);
        }
    }

    // Crear un nuevo municipio
    public async Task<MunicipioEntity> CrearMunicipioAsync(
        string codigoMunicipio,
        string nombreMunicipio,
        string codigoDepartamento)
    {
        try
        {
            using var connection = _context.GetConnection();
            var municipio = await connection.QueryFirstOrDefaultAsync(
                QueryConstant.CREAR_MUNICIPIO,
                new { CodigoMunicipio = codigoMunicipio, NombreMunicipio = nombreMunicipio, CodigoDepartamento = codigoDepartamento },
                commandType: CommandType.Text
            );

            var municipioEntity = new MunicipioEntity
            {
                Id = municipio.id,
                CodigoMunicipio = municipio.codigo_municipio,
                NombreMunicipio = municipio.nombre_municipio,
                StatusMunicipio = municipio.status_municipio,
                DepartamentoId = municipio.departamento_id,
                CreatedAt = municipio.created_at,
                UpdatedAt = municipio.updated_at
            };

            return municipioEntity;

        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.Error.WriteLine($"Error en la base de datos: {npgsqlEx.Message}");
            throw new Exception("Error al ejecutar el procedimiento almacenado CREAR_MUNICIPIO.", npgsqlEx);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error desconocido: {ex.Message}");
            throw new Exception("Ha ocurrido un error inesperado.", ex);
        }
    }

    // Actualizar un municipio existente
    public async Task<bool> ActualizarMunicipioAsync(
        int id,
        string codigoMunicipio,
        string nombreMunicipio,
        string codigoDepartamento)
    {
        try
        {
            using var connection = _context.GetConnection();
            var result = await connection.ExecuteScalarAsync<int>(
                QueryConstant.ACTUALIZAR_MUNICIPIO,
                new { IdMunicipio = id, CodigoMunicipio = codigoMunicipio, NombreMunicipio = nombreMunicipio, CodigoDepartamento = codigoDepartamento },
                commandType: CommandType.Text
            );

            return true;

        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.Error.WriteLine($"Error en la base de datos: {npgsqlEx.Message}");
            throw new Exception("Error al ejecutar el procedimiento almacenado ACTUALIZAR_MUNICIPIO.", npgsqlEx);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error desconocido: {ex.Message}");
            throw new Exception("Ha ocurrido un error inesperado.", ex);
        }
    }

    // Eliminar un municipiuo
    public async Task<bool> EliminarMunicipioAsync(int id)
    {
        try
        {
            using var connection = _context.GetConnection();
            var result = await connection.ExecuteScalarAsync<int>(
                QueryConstant.ELIMINAR_MUNICIPIO,
                new { IdMunicipio = id },
                commandType: CommandType.Text
            );

            return true;
        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.Error.WriteLine($"Error en la base de datos: {npgsqlEx.Message}");
            throw new Exception("Error al ejecutar el procedimiento almacenado ELIMINAR_MUNICIPIO.", npgsqlEx);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error desconocido: {ex.Message}");
            throw new Exception("Ha ocurrido un error inesperado.", ex);
        }
    }
}
