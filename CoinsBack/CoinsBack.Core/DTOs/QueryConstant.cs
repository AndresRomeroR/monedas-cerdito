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

    public static readonly string ACTUALIZAR_PAIS = @"
    SELECT actualizar_pais(@IdPais, @CodigoPais, @NombrePais, TRUE);";

    public static readonly string ELIMINAR_PAIS = @"
    SELECT eliminar_pais(@IdPais);";
}
