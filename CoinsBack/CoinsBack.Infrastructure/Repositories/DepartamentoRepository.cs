using CoinsBack.Core.DTOs;
using CoinsBack.Core.Entities;
using CoinsBack.Core.Interfaces;
using CoinsBack.Infrastructure.Data;
using Dapper;
using Npgsql;
using System.Data;

namespace CoinsBack.Infrastructure.Repositories;

public class DepartamentoRepository : IDepartamentoRepository
{
    private readonly DatabaseContext _context;

    public DepartamentoRepository(DatabaseContext context)
    {
        _context = context;
    }

    // Obtener todos los departamentos
    public async Task<List<DepartamentoEntity>> GetAllAsync()
    {
        try
        {
            using var connection = _context.GetConnection();
            var departametos = await connection.QueryAsync(
                QueryConstant.CONSULTAR_DEPARTAMENTOS,
                commandType: CommandType.Text
            );

            var departametoList = departametos.Select(departamento => new DepartamentoEntity
            {
                IdDepartamento = departamento.id_departamento,
                CodigoDepartamento = departamento.codigo_departamento,
                NombreDepartamento = departamento.nombre_departamento,
                StatusDepartamento = departamento.status_departamento,
                PaisId = departamento.pais_id,
                CreatedAt = departamento.created_at,
                UpdatedAt = departamento.updated_at
            }).ToList();

            return departametoList;
        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.Error.WriteLine($"Error en la base de datos: {npgsqlEx.Message}");
            throw new Exception("Error al ejecutar el procedimiento CONSULTAR_DEPARTAMENTOS.", npgsqlEx);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error desconocido: {ex.Message}");
            throw new Exception("Ha ocurrido un error inesperado.", ex);
        }
    }

    // Obtener un departamento por su ID
    public async Task<DepartamentoEntity> GetByIdAsync(int id)
    {
        try
        {
            using var connection = _context.GetConnection();
            var departamento = await connection.QuerySingleOrDefaultAsync(
                QueryConstant.CONSULTAR_DEPARTAMENTO_POR_ID,
                new { IdDepartamento = id },
                commandType: CommandType.Text
            );

            var departamentoEntity = new DepartamentoEntity
            {
                IdDepartamento = departamento.id_departamento,
                CodigoDepartamento = departamento.codigo_departamento,
                NombreDepartamento = departamento.nombre_departamento,
                StatusDepartamento = departamento.status_departamento,
                PaisId = departamento.pais_id,
                CreatedAt = departamento.created_at,
                UpdatedAt = departamento.updated_at
            };

            return departamentoEntity;

        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.Error.WriteLine($"Error en la base de datos: {npgsqlEx.Message}");
            throw new Exception("Error al ejecutar el procedimiento almacenado CONSULTAR_DEPARTAMENTO_POR_ID.", npgsqlEx);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error desconocido: {ex.Message}");
            throw new Exception("Ha ocurrido un error inesperado.", ex);
        }
    }

    // Crear un nuevo departamento
    public async Task<DepartamentoEntity> CrearDepartamentoAsync(
        string codigoDepartamento, 
        string nombreDepartamento,
        int codigoPais)
    {
        try
        {
            using var connection = _context.GetConnection();
            var departamento = await connection.QueryFirstOrDefaultAsync(
                QueryConstant.CREAR_DEPARTAMENTO,
                new { CodigoDepartamento = codigoDepartamento, NombreDepartamento = nombreDepartamento, CodigoPais = codigoPais },
                commandType: CommandType.Text
            );

            var departamentoEntity = new DepartamentoEntity
            {
                IdDepartamento = departamento.id_departamento,
                CodigoDepartamento = departamento.codigo_departamento,
                NombreDepartamento = departamento.nombre_departamento,
                StatusDepartamento = departamento.status_departamento,
                PaisId = departamento.pais_id,
                CreatedAt = departamento.created_at,
                UpdatedAt = departamento.updated_at
            };

            return departamentoEntity;

        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.Error.WriteLine($"Error en la base de datos: {npgsqlEx.Message}");
            throw new Exception("Error al ejecutar el procedimiento almacenado CREAR_DEPARTAMENTO.", npgsqlEx);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error desconocido: {ex.Message}");
            throw new Exception("Ha ocurrido un error inesperado.", ex);
        }
    }

    // Actualizar un departamento existente
    public async Task<bool> ActualizarDepartamentoAsync(
        int id, 
        string codigoDepartamento, 
        string nombreDepartamento,
        int codigoPais)
    {
        try
        {
            using var connection = _context.GetConnection();
            var result = await connection.ExecuteScalarAsync<int>(
                QueryConstant.ACTUALIZAR_DEPARTAMENTO,
                new { IdDepartamento = id, CodigoDepartamento = codigoDepartamento, NombreDepartamento = nombreDepartamento, CodigoPais = codigoPais },
                commandType: CommandType.Text
            );

            return true;

        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.Error.WriteLine($"Error en la base de datos: {npgsqlEx.Message}");
            throw new Exception("Error al ejecutar el procedimiento almacenado ACTUALIZAR_DEPARTAMENTO.", npgsqlEx);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error desconocido: {ex.Message}");
            throw new Exception("Ha ocurrido un error inesperado.", ex);
        }
    }

    // Eliminar un departamento
    public async Task<bool> EliminarDepartamentoAsync(int id)
    {
        try
        {
            using var connection = _context.GetConnection();
            var result = await connection.ExecuteScalarAsync<int>(
                QueryConstant.ELIMINAR_DEPARTAMENTO,
                new { IdDepartamento = id },
                commandType: CommandType.Text
            );

            return true;
        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.Error.WriteLine($"Error en la base de datos: {npgsqlEx.Message}");
            throw new Exception("Error al ejecutar el procedimiento almacenado ELIMINAR_DEPARTAMENTO.", npgsqlEx);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error desconocido: {ex.Message}");
            throw new Exception("Ha ocurrido un error inesperado.", ex);
        }
    }
}
