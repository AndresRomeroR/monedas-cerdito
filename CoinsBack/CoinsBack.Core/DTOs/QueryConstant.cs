namespace CoinsBack.Core.DTOs;

public static class QueryConstant
{
    public static readonly string CONSULTAR_TODOS_PAIESES = @"
    SELECT 
        id, 
        codigo_pais, 
        nombre_pais, 
        status_pais, 
        created_at, 
        updated_at 
    FROM 
        obtener_todos_paises();";

    public static readonly string CONSULTAR_DEPARTAMENTOS = @"
    SELECT 
	    id_departamento,
        codigo_departamento,
        nombre_departamento,
        status_departamento,
        pais_id,
        created_at,
        updated_at
    FROM
        obtener_todos_departamentos();";

    public static readonly string CONSULTAR_MUNICIPIOS = @"
    select 
	    id,
        codigo_municipio,
        nombre_municipio,
        status_municipio,
        departamento_id,
        created_at,
        updated_at
    FROM
        obtener_todos_municipios();";

    public static readonly string CONSULTAR_USUARIOS = @"
    SELECT 
	    id ,
        nombre_usuario ,
        telefono_usuario ,
        direccion_detalle ,
        pais_id ,
        departamento_id ,
        municipio_id ,
        status_usuario ,
        created_at ,
        updated_at 
    FROM 
	    obtener_todos_los_usuarios();";

    public static readonly string CONSULTAR_PAIS_POR_ID = @"
    SELECT 
        id, 
        codigo_pais, 
        nombre_pais, 
        status_pais, 
        created_at, 
        updated_at 
    FROM 
        obtener_pais_por_id(@IdPais);";

    public static readonly string CONSULTAR_DEPARTAMENTO_POR_ID = @"
    SELECT 
        id_departamento,
        codigo_departamento,
        nombre_departamento,
        status_departamento,
        pais_id,
        created_at,
        updated_at 
    FROM 
        obtener_departamento_por_id(@IdDepartamento);";

    public static readonly string CONSULTAR_MUNICIPIO_POR_ID = @"
    SELECT 
	    id ,
        codigo_municipio ,
        nombre_municipio ,
        status_municipio ,
        departamento_id ,
        created_at ,
        updated_at 
    FROM 
        obtener_municipio_por_id(@IdMunicipio);";

    public static readonly string CONSULTAR_USUARIO_POR_ID = @"
    SELECT 
	    id ,
        nombre_usuario ,
        telefono_usuario ,
        direccion_detalle ,
        pais_id ,
        departamento_id ,
        municipio_id ,
        status_usuario ,
        created_at ,
        updated_at 
    FROM 
	    obtener_usuario_por_id(@IdUsuario);";

    public static readonly string CREAR_PAIS = @"
    SELECT 
        id, 
        codigo_pais, 
        nombre_pais, 
        status_pais, 
        created_at, 
        updated_at 
    FROM 
        crear_pais(@CodigoPais, @NombrePais, TRUE);";

    public static readonly string CREAR_DEPARTAMENTO = @"
    SELECT
        id_departamento,
        codigo_departamento,
        nombre_departamento,
        status_departamento,
        pais_id,
        created_at,
        updated_at
    FROM
        crear_departamento(@CodigoDepartamento, @NombreDepartamento, TRUE, @CodigoPais);";

    public static readonly string CREAR_MUNICIPIO = @"
    SELECT 
        id,
        codigo_municipio,
        nombre_municipio,
        status_municipio,
        departamento_id,
        created_at,
        updated_at 
    FROM
        crear_municipio(@CodigoMunicipio, @NombreMunicipio, TRUE, @CodigoDepartamento);";

    public static readonly string CREAR_USUARIO = @"
    SELECT 
	    id ,
        nombre_usuario ,
        telefono_usuario ,
        direccion_detalle ,
        pais_id ,
        departamento_id ,
        municipio_id ,
        status_usuario ,
        created_at ,
        updated_at
    FROM 
	    crear_usuario(
        @NombreUsuario, 
        @TelefonoUsuario, 
        @DireccionDetalle, 
        @PaisId, 
        @DepartamentoId, 
        @MunicipioId, 
        TRUE);";

    public static readonly string ACTUALIZAR_PAIS = @"
    SELECT actualizar_pais(@IdPais, @CodigoPais, @NombrePais, TRUE);";

    public static readonly string ACTUALIZAR_DEPARTAMENTO = @"
    SELECT actualizar_departamento(@IdDepartamento, @CodigoDepartamento, @NombreDepartamento, TRUE, @CodigoPais);";

    public static readonly string ACTUALIZAR_MUNICIPIO = @"
    SELECT actualizar_municipio(@IdMunicipio, @CodigoMunicipio, @NombreMunicipio, TRUE, @CodigoDepartamento);";

    public static readonly string ACTUALIZAR_USUARIO = @"
    SELECT actualizar_usuario(@IdUsuario, @NombreUsuario, @TelefonoUsuario, @DireccionUsuario, @IdPaisUsuario, @IdDepartamentoUsuario, @IdMunicipioUsuario, TRUE);";

    public static readonly string ELIMINAR_PAIS = @"
    SELECT eliminar_pais(@IdPais);";

    public static readonly string ELIMINAR_DEPARTAMENTO = @"
    SELECT eliminar_departamento(@IdDepartamento);";

    public static readonly string ELIMINAR_MUNICIPIO = @"
    SELECT eliminar_municipio(@IdMunicipio);";

    public static readonly string ELIMINAR_USUARIO = @"
    SELECT eliminar_usuario(@IdUsuario);";
}
