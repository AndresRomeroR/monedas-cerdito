using CoinsBack.Core.DTOs;
using CoinsBack.Core.Entities;
using CoinsBack.Core.Interfaces;
using CoinsBack.Infrastructure.Data;
using Dapper;
using Npgsql;
using System.Data;
using System.Reflection.Metadata;

namespace CoinsBack.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    // Obtener todos los usuarios
    public async Task<List<UserEntity>> GetAllAsync()
    {
        try
        {
            using var connection = _context.GetConnection();
            var usuarios = await connection.QueryAsync(
                QueryConstant.CONSULTAR_USUARIOS,
                commandType: CommandType.Text
            );

            var usuarioList = usuarios.Select(usuario => new UserEntity
            {
                Id = usuario.id,
                NombreUsuario = usuario.nombre_usuario,
                TelefonoUsuario = usuario.telefono_usuario,
                DireccionDetalle = usuario.direccion_detalle,
                PaisId = usuario.pais_id,
                DepartamentoId = usuario.departamento_id,
                MunicipioId = usuario.municipio_id,
                StatusUsuario = usuario.status_usuario,
                CreatedAt = usuario.created_at,
                UpdatedAt = usuario.updated_at
            }).ToList();

            return usuarioList;
        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.Error.WriteLine($"Error en la base de datos: {npgsqlEx.Message}");
            throw new Exception("Error al ejecutar el procedimiento almacenado CONSULTAR_TODOS_USUARIOS.", npgsqlEx);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error desconocido: {ex.Message}");
            throw new Exception("Ha ocurrido un error inesperado.", ex);
        }
    }

    // Obtener un usuario por su ID
    public async Task<UserEntity> GetByIdAsync(int id)
    {
        try
        {
            using var connection = _context.GetConnection();
            var usuario = await connection.QuerySingleOrDefaultAsync(
                QueryConstant.CONSULTAR_USUARIO_POR_ID,
                new { IdUsuario = id },
                commandType: CommandType.Text
            );

            var userEntity = new UserEntity
            {
                Id = usuario.id,
                NombreUsuario = usuario.nombre_usuario,
                TelefonoUsuario = usuario.telefono_usuario,
                DireccionDetalle = usuario.direccion_detalle,
                PaisId = usuario.pais_id,
                DepartamentoId = usuario.departamento_id,
                MunicipioId = usuario.municipio_id,
                StatusUsuario = usuario.status_usuario,
                CreatedAt = usuario.created_at,
                UpdatedAt = usuario.updated_at
            };

            return userEntity;

        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.Error.WriteLine($"Error en la base de datos: {npgsqlEx.Message}");
            throw new Exception("Error al ejecutar el procedimiento almacenado CONSULTAR_USUARIO_POR_ID.", npgsqlEx);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error desconocido: {ex.Message}");
            throw new Exception("Ha ocurrido un error inesperado.", ex);
        }
    }

    // Crear un nuevo usuario
    public async Task<UserEntity> CrearUsuarioAsync(
        string nombreUsuario,
        string telefonoUsuario,
        string direccionDetalle,
        int paisId,
        string departamentoId,
        int municipioId)
    {
        try
        {
            using var connection = _context.GetConnection();
            var usuario = await connection.QueryFirstOrDefaultAsync(
                QueryConstant.CREAR_USUARIO,
                new { 
                    NombreUsuario = nombreUsuario,
                    TelefonoUsuario = telefonoUsuario,
                    DireccionDetalle = direccionDetalle,
                    PaisId = paisId,
                    DepartamentoId = departamentoId,
                    MunicipioId = municipioId
                },
                commandType: CommandType.Text
            );

            var userEntity = new UserEntity
            {
                Id = usuario.id,
                NombreUsuario = usuario.nombre_usuario,
                TelefonoUsuario = usuario.telefono_usuario,
                DireccionDetalle = usuario.direccion_detalle,
                PaisId = usuario.pais_id,
                DepartamentoId = usuario.departamento_id,
                MunicipioId = usuario.municipio_id,
                StatusUsuario = usuario.status_usuario,
                CreatedAt = usuario.created_at,
                UpdatedAt = usuario.updated_at
            };

            return userEntity;

        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.Error.WriteLine($"Error en la base de datos: {npgsqlEx.Message}");
            throw new Exception("Error al ejecutar el procedimiento almacenado CREAR_USUARIO.", npgsqlEx);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error desconocido: {ex.Message}");
            throw new Exception("Ha ocurrido un error inesperado.", ex);
        }
    }

    // Actualizar un usuario existente
    public async Task<bool> ActualizarUsuarioAsync(
        int idUsuario,
        string nombreUsuario,
        string telefonoUsuario,
        string direccionUsuario,
        int idPaisUsuario,
        string idDepartamentoUsuario,
        int idMunicipioUsuario)
    {
        try
        {
            using var connection = _context.GetConnection();
            var result = await connection.ExecuteScalarAsync<int>(
                QueryConstant.ACTUALIZAR_USUARIO,
                new {
                    IdUsuario = idUsuario,
                    NombreUsuario = nombreUsuario,
                    TelefonoUsuario = telefonoUsuario,
                    DireccionUsuario = direccionUsuario,
                    IdPaisUsuario = idPaisUsuario,
                    IdDepartamentoUsuario = idDepartamentoUsuario,
                    IdMunicipioUsuario = idMunicipioUsuario
                },
                commandType: CommandType.Text
            );

            return true;

        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.Error.WriteLine($"Error en la base de datos: {npgsqlEx.Message}");
            throw new Exception("Error al ejecutar el procedimiento almacenado ACTUALIZAR_USUARIO.", npgsqlEx);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error desconocido: {ex.Message}");
            throw new Exception("Ha ocurrido un error inesperado.", ex);
        }
    }

    // Eliminar un usuario
    public async Task<bool> EliminarUsuarioAsync(int id)
    {
        try
        {
            using var connection = _context.GetConnection();
            var result = await connection.ExecuteScalarAsync<int>(
                QueryConstant.ELIMINAR_USUARIO,
                new { IdUsuario = id },
                commandType: CommandType.Text
            );

            return true;
        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.Error.WriteLine($"Error en la base de datos: {npgsqlEx.Message}");
            throw new Exception("Error al ejecutar el procedimiento almacenado ELIMINAR_USUARIO.", npgsqlEx);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error desconocido: {ex.Message}");
            throw new Exception("Ha ocurrido un error inesperado.", ex);
        }
    }
}
