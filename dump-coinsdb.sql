PGDMP  $    6            
    |            coinsdb    17.1 (Debian 17.1-1.pgdg120+1)    17.1 (Debian 17.1-1.pgdg120+1) <    d           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            e           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            f           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            g           1262    16384    coinsdb    DATABASE     r   CREATE DATABASE coinsdb WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.utf8';
    DROP DATABASE coinsdb;
                     arrr    false                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
                     pg_database_owner    false            h           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                        pg_database_owner    false    4            �            1255    16785 P   actualizar_departamento(integer, character, character varying, boolean, integer)    FUNCTION     �  CREATE FUNCTION public.actualizar_departamento(p_id_departamento integer, p_codigo_departamento character, p_nombre_departamento character varying, p_status_departamento boolean, p_pais_id integer) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE departamentos
    SET 
        codigo_departamento = p_codigo_departamento,
        nombre_departamento = p_nombre_departamento,
        status_departamento = p_status_departamento,
        pais_id = p_pais_id,
        updated_at = CURRENT_TIMESTAMP
    WHERE id_departamento = p_id_departamento;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'No se encontró el departamento con el ID %', p_id_departamento;
    END IF;
END;
$$;
 �   DROP FUNCTION public.actualizar_departamento(p_id_departamento integer, p_codigo_departamento character, p_nombre_departamento character varying, p_status_departamento boolean, p_pais_id integer);
       public               arrr    false    4            �            1255    16796 O   actualizar_municipio(integer, character, character varying, boolean, character)    FUNCTION     �  CREATE FUNCTION public.actualizar_municipio(p_id integer, p_codigo_municipio character, p_nombre_municipio character varying, p_status_municipio boolean, p_departamento_id character) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Verificar si el municipio existe
    UPDATE municipios
    SET 
        codigo_municipio = p_codigo_municipio,
        nombre_municipio = p_nombre_municipio,
        status_municipio = p_status_municipio,
        departamento_id = p_departamento_id,
        updated_at = CURRENT_TIMESTAMP
    WHERE id = p_id;

    -- Si no se actualiza ningún registro, lanzar una excepción
    IF NOT FOUND THEN
        RAISE EXCEPTION 'No se encontró el municipio con el ID %', p_id;
    END IF;
END;
$$;
 �   DROP FUNCTION public.actualizar_municipio(p_id integer, p_codigo_municipio character, p_nombre_municipio character varying, p_status_municipio boolean, p_departamento_id character);
       public               arrr    false    4            �            1255    16781 ?   actualizar_pais(integer, character, character varying, boolean)    FUNCTION       CREATE FUNCTION public.actualizar_pais(p_id integer, p_codigo_pais character, p_nombre_pais character varying, p_status_pais boolean) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE paises
    SET
        codigo_pais = p_codigo_pais,
        nombre_pais = p_nombre_pais,
        status_pais = p_status_pais,
        updated_at = CURRENT_TIMESTAMP
    WHERE id = p_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'No se encontró el país con el ID %', p_id;
    END IF;
END;
$$;
 �   DROP FUNCTION public.actualizar_pais(p_id integer, p_codigo_pais character, p_nombre_pais character varying, p_status_pais boolean);
       public               arrr    false    4            �            1255    16866 z   actualizar_usuario(integer, character varying, character varying, character varying, integer, character, integer, boolean)    FUNCTION     �  CREATE FUNCTION public.actualizar_usuario(p_id integer, p_nombre_usuario character varying, p_telefono_usuario character varying, p_direccion_detalle character varying, p_pais_id integer, p_departamento_id character, p_municipio_id integer, p_status_usuario boolean) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Actualizar los datos del usuario
    UPDATE usuarios
    SET
        nombre_usuario = p_nombre_usuario,
        telefono_usuario = p_telefono_usuario,
        direccion_detalle = p_direccion_detalle,
        pais_id = p_pais_id,
        departamento_id = p_departamento_id,
        municipio_id = p_municipio_id,
        status_usuario = p_status_usuario,
        updated_at = CURRENT_TIMESTAMP
    WHERE id = p_id;

    -- Si no se encuentra el usuario, lanzar una excepción
    IF NOT FOUND THEN
        RAISE EXCEPTION 'No se encontró el usuario con el ID %', p_id;
    END IF;
END;
$$;
 
  DROP FUNCTION public.actualizar_usuario(p_id integer, p_nombre_usuario character varying, p_telefono_usuario character varying, p_direccion_detalle character varying, p_pais_id integer, p_departamento_id character, p_municipio_id integer, p_status_usuario boolean);
       public               arrr    false    4            �            1255    16808 B   crear_departamento(character, character varying, boolean, integer)    FUNCTION     �  CREATE FUNCTION public.crear_departamento(p_codigo_departamento character, p_nombre_departamento character varying, p_status_departamento boolean, p_pais_id integer) RETURNS TABLE(id_departamento integer, codigo_departamento character, nombre_departamento character varying, status_departamento boolean, pais_id integer, created_at timestamp without time zone, updated_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY 
    INSERT INTO departamentos (
        codigo_departamento, 
        nombre_departamento, 
        status_departamento, 
        pais_id, 
        created_at, 
        updated_at
    )
    VALUES (
        p_codigo_departamento, 
        p_nombre_departamento, 
        p_status_departamento, 
        p_pais_id, 
        CURRENT_TIMESTAMP, 
        CURRENT_TIMESTAMP
    )
    RETURNING 
        departamentos.id_departamento, 
        departamentos.codigo_departamento, 
        departamentos.nombre_departamento, 
        departamentos.status_departamento, 
        departamentos.pais_id, 
        departamentos.created_at, 
        departamentos.updated_at;
END;
$$;
 �   DROP FUNCTION public.crear_departamento(p_codigo_departamento character, p_nombre_departamento character varying, p_status_departamento boolean, p_pais_id integer);
       public               arrr    false    4            �            1255    16812 A   crear_municipio(character, character varying, boolean, character)    FUNCTION     1  CREATE FUNCTION public.crear_municipio(p_codigo_municipio character, p_nombre_municipio character varying, p_status_municipio boolean, p_departamento_id character) RETURNS TABLE(id integer, codigo_municipio character, nombre_municipio character varying, status_municipio boolean, departamento_id character, created_at timestamp without time zone, updated_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Insertar un nuevo municipio en la tabla
    INSERT INTO municipios (
        codigo_municipio, 
        nombre_municipio, 
        status_municipio, 
        departamento_id, 
        created_at, 
        updated_at
    )
    VALUES (
        p_codigo_municipio, 
        p_nombre_municipio, 
        p_status_municipio, 
        p_departamento_id, 
        CURRENT_TIMESTAMP, 
        CURRENT_TIMESTAMP
    )
    RETURNING 
        municipios.id, 
        municipios.codigo_municipio, 
        municipios.nombre_municipio, 
        municipios.status_municipio, 
        municipios.departamento_id, 
        municipios.created_at, 
        municipios.updated_at
    INTO 
        id, codigo_municipio, nombre_municipio, status_municipio, departamento_id, created_at, updated_at;

    -- Ahora, retornar los valores de los datos insertados
    RETURN NEXT;
END;
$$;
 �   DROP FUNCTION public.crear_municipio(p_codigo_municipio character, p_nombre_municipio character varying, p_status_municipio boolean, p_departamento_id character);
       public               arrr    false    4            �            1255    16805 1   crear_pais(character, character varying, boolean)    FUNCTION       CREATE FUNCTION public.crear_pais(p_codigo_pais character, p_nombre_pais character varying, p_status_pais boolean) RETURNS TABLE(id integer, codigo_pais character, nombre_pais character varying, status_pais boolean, created_at timestamp without time zone, updated_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Verificar si el código de país ya existe
    IF EXISTS (SELECT 1 FROM paises WHERE paises.codigo_pais = p_codigo_pais) THEN
        -- Si el código de país ya existe, lanzar un error
        RAISE EXCEPTION 'El código de país % ya existe.', p_codigo_pais;
    END IF;

    -- Si el código de país no existe, proceder con la inserción
    RETURN QUERY
    INSERT INTO paises (codigo_pais, nombre_pais, status_pais, created_at, updated_at)
    VALUES (p_codigo_pais, p_nombre_pais, p_status_pais, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)
    RETURNING paises.id, paises.codigo_pais, paises.nombre_pais, paises.status_pais, paises.created_at, paises.updated_at;
END;
$$;
 r   DROP FUNCTION public.crear_pais(p_codigo_pais character, p_nombre_pais character varying, p_status_pais boolean);
       public               arrr    false    4            �            1255    16863 l   crear_usuario(character varying, character varying, character varying, integer, character, integer, boolean)    FUNCTION     s  CREATE FUNCTION public.crear_usuario(p_nombre_usuario character varying, p_telefono_usuario character varying, p_direccion_detalle character varying, p_pais_id integer, p_departamento_id character, p_municipio_id integer, p_status_usuario boolean) RETURNS TABLE(id integer, nombre_usuario character varying, telefono_usuario character varying, direccion_detalle character varying, pais_id integer, departamento_id character, municipio_id integer, status_usuario boolean, created_at timestamp without time zone, updated_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Verificar si el país, departamento y municipio existen
    IF NOT EXISTS (SELECT 1 FROM paises WHERE paises.id = p_pais_id) THEN
        RAISE EXCEPTION 'No se encontró el país con el ID %', p_pais_id;
    END IF;

    IF NOT EXISTS (SELECT 1 FROM departamentos WHERE departamentos.codigo_departamento = p_departamento_id) THEN
        RAISE EXCEPTION 'No se encontró el departamento con el código %', p_departamento_id;
    END IF;

    IF NOT EXISTS (SELECT 1 FROM municipios WHERE municipios.id = p_municipio_id) THEN
        RAISE EXCEPTION 'No se encontró el municipio con el ID %', p_municipio_id;
    END IF;

    -- Insertar el nuevo usuario
    RETURN QUERY
    INSERT INTO usuarios (
        nombre_usuario, 
        telefono_usuario, 
        direccion_detalle, 
        pais_id, 
        departamento_id, 
        municipio_id, 
        status_usuario, 
        created_at, 
        updated_at
    )
    VALUES (
        p_nombre_usuario, 
        p_telefono_usuario, 
        p_direccion_detalle, 
        p_pais_id, 
        p_departamento_id, 
        p_municipio_id, 
        p_status_usuario, 
        CURRENT_TIMESTAMP, 
        CURRENT_TIMESTAMP
    )
    RETURNING 
        usuarios.id, 
        usuarios.nombre_usuario, 
        usuarios.telefono_usuario, 
        usuarios.direccion_detalle, 
        usuarios.pais_id, 
        usuarios.departamento_id, 
        usuarios.municipio_id, 
        usuarios.status_usuario, 
        usuarios.created_at, 
        usuarios.updated_at;
END;
$$;
 �   DROP FUNCTION public.crear_usuario(p_nombre_usuario character varying, p_telefono_usuario character varying, p_direccion_detalle character varying, p_pais_id integer, p_departamento_id character, p_municipio_id integer, p_status_usuario boolean);
       public               arrr    false    4            �            1255    16786    eliminar_departamento(integer)    FUNCTION     �  CREATE FUNCTION public.eliminar_departamento(p_id_departamento integer) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE departamentos
    SET 
        status_departamento = FALSE,
        updated_at = CURRENT_TIMESTAMP
    WHERE id_departamento = p_id_departamento;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'No se encontró el departamento con el ID %', p_id_departamento;
    END IF;
END;
$$;
 G   DROP FUNCTION public.eliminar_departamento(p_id_departamento integer);
       public               arrr    false    4            �            1255    16798    eliminar_municipio(integer)    FUNCTION     �  CREATE FUNCTION public.eliminar_municipio(p_id integer) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Actualizar el estado del municipio a 'inactivo' en lugar de eliminarlo
    UPDATE municipios
    SET 
        status_municipio = FALSE,
        updated_at = CURRENT_TIMESTAMP
    WHERE id = p_id;

    -- Si no se actualiza ningún registro, lanzar una excepción
    IF NOT FOUND THEN
        RAISE EXCEPTION 'No se encontró el municipio con el ID %', p_id;
    END IF;
END;
$$;
 7   DROP FUNCTION public.eliminar_municipio(p_id integer);
       public               arrr    false    4            �            1255    16806    eliminar_pais(integer)    FUNCTION     Z  CREATE FUNCTION public.eliminar_pais(p_id integer) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE paises
    SET
        status_pais = FALSE,
        updated_at = CURRENT_TIMESTAMP
    WHERE id = p_id;
    
    IF NOT FOUND THEN
        RAISE EXCEPTION 'No se encontró el país con el ID %', p_id;
    END IF;
END;
$$;
 2   DROP FUNCTION public.eliminar_pais(p_id integer);
       public               arrr    false    4            �            1255    16867    eliminar_usuario(integer)    FUNCTION     �  CREATE FUNCTION public.eliminar_usuario(p_id integer) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Desactivar al usuario
    UPDATE usuarios
    SET
        status_usuario = FALSE,
        updated_at = CURRENT_TIMESTAMP
    WHERE id = p_id;

    -- Si no se encuentra el usuario, lanzar una excepción
    IF NOT FOUND THEN
        RAISE EXCEPTION 'No se encontró el usuario con el ID %', p_id;
    END IF;
END;
$$;
 5   DROP FUNCTION public.eliminar_usuario(p_id integer);
       public               arrr    false    4            �            1255    16784 $   obtener_departamento_por_id(integer)    FUNCTION     �  CREATE FUNCTION public.obtener_departamento_por_id(p_id_departamento integer) RETURNS TABLE(id_departamento integer, codigo_departamento character, nombre_departamento character varying, status_departamento boolean, pais_id integer, created_at timestamp without time zone, updated_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT 
        departamentos.id_departamento, 
        departamentos.codigo_departamento, 
        departamentos.nombre_departamento, 
        departamentos.status_departamento, 
        departamentos.pais_id, 
        departamentos.created_at, 
        departamentos.updated_at
    FROM departamentos
    WHERE departamentos.id_departamento = p_id_departamento;
END;
$$;
 M   DROP FUNCTION public.obtener_departamento_por_id(p_id_departamento integer);
       public               arrr    false    4            �            1255    16795 !   obtener_municipio_por_id(integer)    FUNCTION     R  CREATE FUNCTION public.obtener_municipio_por_id(p_id integer) RETURNS TABLE(id integer, codigo_municipio character, nombre_municipio character varying, status_municipio boolean, departamento_id character, created_at timestamp without time zone, updated_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY 
    SELECT 
        m.id, 
        m.codigo_municipio, 
        m.nombre_municipio, 
        m.status_municipio, 
        m.departamento_id, 
        m.created_at, 
        m.updated_at
    FROM municipios m
    WHERE m.id = p_id;
END;
$$;
 =   DROP FUNCTION public.obtener_municipio_por_id(p_id integer);
       public               arrr    false    4            �            1255    16779    obtener_pais_por_id(integer)    FUNCTION       CREATE FUNCTION public.obtener_pais_por_id(p_id integer) RETURNS TABLE(id integer, codigo_pais character, nombre_pais character varying, status_pais boolean, created_at timestamp without time zone, updated_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT 
        paises.id, 
        paises.codigo_pais, 
        paises.nombre_pais, 
        paises.status_pais, 
        paises.created_at, 
        paises.updated_at
    FROM paises 
    WHERE paises.id = p_id;
END;
$$;
 8   DROP FUNCTION public.obtener_pais_por_id(p_id integer);
       public               arrr    false    4            �            1255    16791    obtener_todos_departamentos()    FUNCTION     �  CREATE FUNCTION public.obtener_todos_departamentos() RETURNS TABLE(id_departamento integer, codigo_departamento character, nombre_departamento character varying, status_departamento boolean, pais_id integer, created_at timestamp without time zone, updated_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT 
        departamentos.id_departamento, 
        departamentos.codigo_departamento, 
        departamentos.nombre_departamento, 
        departamentos.status_departamento, 
        departamentos.pais_id, 
        departamentos.created_at, 
        departamentos.updated_at
    FROM departamentos
    WHERE departamentos.status_departamento = TRUE;
END;
$$;
 4   DROP FUNCTION public.obtener_todos_departamentos();
       public               arrr    false    4            �            1255    16865    obtener_todos_los_usuarios()    FUNCTION       CREATE FUNCTION public.obtener_todos_los_usuarios() RETURNS TABLE(id integer, nombre_usuario character varying, telefono_usuario character varying, direccion_detalle character varying, pais_id integer, departamento_id character, municipio_id integer, status_usuario boolean, created_at timestamp without time zone, updated_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT 
        usuarios.id,
        usuarios.nombre_usuario,
        usuarios.telefono_usuario,
        usuarios.direccion_detalle,
        usuarios.pais_id,
        usuarios.departamento_id,
        usuarios.municipio_id,
        usuarios.status_usuario,
        usuarios.created_at,
        usuarios.updated_at
    FROM usuarios;
END;
$$;
 3   DROP FUNCTION public.obtener_todos_los_usuarios();
       public               arrr    false    4            �            1255    16793    obtener_todos_municipios()    FUNCTION     g  CREATE FUNCTION public.obtener_todos_municipios() RETURNS TABLE(id integer, codigo_municipio character, nombre_municipio character varying, status_municipio boolean, departamento_id character, created_at timestamp without time zone, updated_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY 
    SELECT 
        m.id, 
        m.codigo_municipio, 
        m.nombre_municipio, 
        m.status_municipio, 
        m.departamento_id, 
        m.created_at, 
        m.updated_at
    FROM municipios m
    WHERE m.status_municipio = TRUE
    ORDER BY m.id;
END;
$$;
 1   DROP FUNCTION public.obtener_todos_municipios();
       public               arrr    false    4            �            1255    16800    obtener_todos_paises()    FUNCTION     h  CREATE FUNCTION public.obtener_todos_paises() RETURNS TABLE(id integer, codigo_pais character, nombre_pais character varying, status_pais boolean, created_at timestamp without time zone, updated_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT * FROM paises Where paises.status_pais = true ORDER BY id;
END;
$$;
 -   DROP FUNCTION public.obtener_todos_paises();
       public               arrr    false    4            �            1255    16864    obtener_usuario_por_id(integer)    FUNCTION     $  CREATE FUNCTION public.obtener_usuario_por_id(p_id integer) RETURNS TABLE(id integer, nombre_usuario character varying, telefono_usuario character varying, direccion_detalle character varying, pais_id integer, departamento_id character, municipio_id integer, status_usuario boolean, created_at timestamp without time zone, updated_at timestamp without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT 
        usuarios.id,
        usuarios.nombre_usuario,
        usuarios.telefono_usuario,
        usuarios.direccion_detalle,
        usuarios.pais_id,
        usuarios.departamento_id,
        usuarios.municipio_id,
        usuarios.status_usuario,
        usuarios.created_at,
        usuarios.updated_at
    FROM usuarios
    WHERE usuarios.id = p_id;
END;
$$;
 ;   DROP FUNCTION public.obtener_usuario_por_id(p_id integer);
       public               arrr    false    4            �            1259    16747    departamentos    TABLE     �  CREATE TABLE public.departamentos (
    id_departamento integer NOT NULL,
    codigo_departamento character(2) NOT NULL,
    nombre_departamento character varying(255) NOT NULL,
    status_departamento boolean NOT NULL,
    pais_id integer NOT NULL,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    updated_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);
 !   DROP TABLE public.departamentos;
       public         heap r       arrr    false    4            �            1259    16746 !   departamentos_id_departamento_seq    SEQUENCE     �   CREATE SEQUENCE public.departamentos_id_departamento_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 8   DROP SEQUENCE public.departamentos_id_departamento_seq;
       public               arrr    false    220    4            i           0    0 !   departamentos_id_departamento_seq    SEQUENCE OWNED BY     g   ALTER SEQUENCE public.departamentos_id_departamento_seq OWNED BY public.departamentos.id_departamento;
          public               arrr    false    219            �            1259    16763 
   municipios    TABLE     �  CREATE TABLE public.municipios (
    id integer NOT NULL,
    codigo_municipio character(6) NOT NULL,
    nombre_municipio character varying(255) NOT NULL,
    status_municipio boolean NOT NULL,
    departamento_id character(2) NOT NULL,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    updated_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);
    DROP TABLE public.municipios;
       public         heap r       arrr    false    4            �            1259    16762    municipios_id_seq    SEQUENCE     �   CREATE SEQUENCE public.municipios_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public.municipios_id_seq;
       public               arrr    false    222    4            j           0    0    municipios_id_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public.municipios_id_seq OWNED BY public.municipios.id;
          public               arrr    false    221            �            1259    16738    paises    TABLE     P  CREATE TABLE public.paises (
    id integer NOT NULL,
    codigo_pais character(4) NOT NULL,
    nombre_pais character varying(255) NOT NULL,
    status_pais boolean NOT NULL,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    updated_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);
    DROP TABLE public.paises;
       public         heap r       arrr    false    4            �            1259    16737    paises_id_seq    SEQUENCE     �   CREATE SEQUENCE public.paises_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE public.paises_id_seq;
       public               arrr    false    4    218            k           0    0    paises_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE public.paises_id_seq OWNED BY public.paises.id;
          public               arrr    false    217            �            1259    16836    usuarios    TABLE       CREATE TABLE public.usuarios (
    id integer NOT NULL,
    nombre_usuario character varying(255) NOT NULL,
    telefono_usuario character varying(20) NOT NULL,
    direccion_detalle character varying(255) NOT NULL,
    pais_id integer NOT NULL,
    departamento_id character(2) NOT NULL,
    municipio_id integer NOT NULL,
    status_usuario boolean DEFAULT true NOT NULL,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    updated_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);
    DROP TABLE public.usuarios;
       public         heap r       arrr    false    4            �            1259    16835    usuarios_id_seq    SEQUENCE     �   CREATE SEQUENCE public.usuarios_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.usuarios_id_seq;
       public               arrr    false    224    4            l           0    0    usuarios_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.usuarios_id_seq OWNED BY public.usuarios.id;
          public               arrr    false    223            �           2604    16750    departamentos id_departamento    DEFAULT     �   ALTER TABLE ONLY public.departamentos ALTER COLUMN id_departamento SET DEFAULT nextval('public.departamentos_id_departamento_seq'::regclass);
 L   ALTER TABLE public.departamentos ALTER COLUMN id_departamento DROP DEFAULT;
       public               arrr    false    219    220    220            �           2604    16766    municipios id    DEFAULT     n   ALTER TABLE ONLY public.municipios ALTER COLUMN id SET DEFAULT nextval('public.municipios_id_seq'::regclass);
 <   ALTER TABLE public.municipios ALTER COLUMN id DROP DEFAULT;
       public               arrr    false    221    222    222            �           2604    16741 	   paises id    DEFAULT     f   ALTER TABLE ONLY public.paises ALTER COLUMN id SET DEFAULT nextval('public.paises_id_seq'::regclass);
 8   ALTER TABLE public.paises ALTER COLUMN id DROP DEFAULT;
       public               arrr    false    218    217    218            �           2604    16839    usuarios id    DEFAULT     j   ALTER TABLE ONLY public.usuarios ALTER COLUMN id SET DEFAULT nextval('public.usuarios_id_seq'::regclass);
 :   ALTER TABLE public.usuarios ALTER COLUMN id DROP DEFAULT;
       public               arrr    false    224    223    224            ]          0    16747    departamentos 
   TABLE DATA           �   COPY public.departamentos (id_departamento, codigo_departamento, nombre_departamento, status_departamento, pais_id, created_at, updated_at) FROM stdin;
    public               arrr    false    220   I�       _          0    16763 
   municipios 
   TABLE DATA           �   COPY public.municipios (id, codigo_municipio, nombre_municipio, status_municipio, departamento_id, created_at, updated_at) FROM stdin;
    public               arrr    false    222   `�       [          0    16738    paises 
   TABLE DATA           c   COPY public.paises (id, codigo_pais, nombre_pais, status_pais, created_at, updated_at) FROM stdin;
    public               arrr    false    218   8�       a          0    16836    usuarios 
   TABLE DATA           �   COPY public.usuarios (id, nombre_usuario, telefono_usuario, direccion_detalle, pais_id, departamento_id, municipio_id, status_usuario, created_at, updated_at) FROM stdin;
    public               arrr    false    224   "�       m           0    0 !   departamentos_id_departamento_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('public.departamentos_id_departamento_seq', 38, true);
          public               arrr    false    219            n           0    0    municipios_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.municipios_id_seq', 160, true);
          public               arrr    false    221            o           0    0    paises_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.paises_id_seq', 256, true);
          public               arrr    false    217            p           0    0    usuarios_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.usuarios_id_seq', 3, true);
          public               arrr    false    223            �           2606    16756 3   departamentos departamentos_codigo_departamento_key 
   CONSTRAINT     }   ALTER TABLE ONLY public.departamentos
    ADD CONSTRAINT departamentos_codigo_departamento_key UNIQUE (codigo_departamento);
 ]   ALTER TABLE ONLY public.departamentos DROP CONSTRAINT departamentos_codigo_departamento_key;
       public                 arrr    false    220            �           2606    16754     departamentos departamentos_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public.departamentos
    ADD CONSTRAINT departamentos_pkey PRIMARY KEY (id_departamento);
 J   ALTER TABLE ONLY public.departamentos DROP CONSTRAINT departamentos_pkey;
       public                 arrr    false    220            �           2606    16770    municipios municipios_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.municipios
    ADD CONSTRAINT municipios_pkey PRIMARY KEY (id);
 D   ALTER TABLE ONLY public.municipios DROP CONSTRAINT municipios_pkey;
       public                 arrr    false    222            �           2606    16745    paises paises_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.paises
    ADD CONSTRAINT paises_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.paises DROP CONSTRAINT paises_pkey;
       public                 arrr    false    218            �           2606    16846    usuarios usuarios_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.usuarios
    ADD CONSTRAINT usuarios_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.usuarios DROP CONSTRAINT usuarios_pkey;
       public                 arrr    false    224            �           2606    16852    usuarios fk_departamento    FK CONSTRAINT     �   ALTER TABLE ONLY public.usuarios
    ADD CONSTRAINT fk_departamento FOREIGN KEY (departamento_id) REFERENCES public.departamentos(codigo_departamento) ON DELETE RESTRICT;
 B   ALTER TABLE ONLY public.usuarios DROP CONSTRAINT fk_departamento;
       public               arrr    false    220    3261    224            �           2606    16771    municipios fk_department    FK CONSTRAINT     �   ALTER TABLE ONLY public.municipios
    ADD CONSTRAINT fk_department FOREIGN KEY (departamento_id) REFERENCES public.departamentos(codigo_departamento) ON DELETE CASCADE;
 B   ALTER TABLE ONLY public.municipios DROP CONSTRAINT fk_department;
       public               arrr    false    220    3261    222            �           2606    16857    usuarios fk_municipio    FK CONSTRAINT     �   ALTER TABLE ONLY public.usuarios
    ADD CONSTRAINT fk_municipio FOREIGN KEY (municipio_id) REFERENCES public.municipios(id) ON DELETE RESTRICT;
 ?   ALTER TABLE ONLY public.usuarios DROP CONSTRAINT fk_municipio;
       public               arrr    false    224    222    3265            �           2606    16847    usuarios fk_pais    FK CONSTRAINT     �   ALTER TABLE ONLY public.usuarios
    ADD CONSTRAINT fk_pais FOREIGN KEY (pais_id) REFERENCES public.paises(id) ON DELETE RESTRICT;
 :   ALTER TABLE ONLY public.usuarios DROP CONSTRAINT fk_pais;
       public               arrr    false    218    224    3259            �           2606    16757    departamentos fk_pais_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.departamentos
    ADD CONSTRAINT fk_pais_id FOREIGN KEY (pais_id) REFERENCES public.paises(id) ON DELETE CASCADE;
 B   ALTER TABLE ONLY public.departamentos DROP CONSTRAINT fk_pais_id;
       public               arrr    false    218    220    3259            ]     x���=n�@���)x���N�����$\�y�E�W�s�)T>/�U�XH�`���0���D�Xn�������\Iy%c)�B�0��Ϊ�
a��vxJ-qH!K)mX�����Em�BJ��i>��ժ���ΰn>h�<�͠g��G'@z���y��!c�R3��H�`3iO=��$!c&1�$U�b��y畏]e���������e��{އY��t�붧-�L����Dm?�x$�hϤC�M@��x�ڎ'(���2k�֎,V��񸡇����$��M3�(
VaMc;�d�d�Z��0NMY7�-��uú4� 8|HS��3O�����ھ�O<��s���>8�&��S岯����~����^�6mx�Ox��C�nyO	�pG]wNVW�+]+D��i��\kĈ�v�H�$h��N�"��K�2���3��(�U)o����͎Ɖ�M?�nL�=��B�����Jz���:?[ܟ�ujåT�gI�!h��)�B�*8m�*�TEQ�{1�      _   �  x����n�F��O��m�"�;�D�eP���'���n���M�&/��J���HW�k�Iթ*���k}<�sz)��|����n��A�TwT�1�F�:k}0��уa������(�Y��"XN/q�(�9�LC�)^D��I�I�I�G�(�<����ԂtI�,%�"^Ǽ��r]�*:2� gq�s��#S�Q��8�����C:���N�J�h�o2�`��X�8�Up��z.9��PQ����*Ŋ����6�Yc<����Uc%)qNy��>���,���]�Pk��f:ðM�-5�_5��~܆8)���XEL�LO�c�f��A��ۭ���˶�����>U�T�e���)^{�u��!�jL�%���lm�xs�^J.������{
9M1���	%B�c%�g\Zd,V��ɥ|�9]�t���"���Ǒ\� g�:�����*K*������#EK��aX�[�s�E{,G��[�R��3t�6�i��2���y��#�d����!��x���Z���X�<�g�0�>�P�)��,�X��o&�׌�(�,|а��=�KM"|�-e�je!l=�Z�^ǋ�մB
��JEL؝X6"X�
u������_��l�N1,�:Y�p�!��/�n�,�;��㾔\��l��a�Yxf�QT[ߨ�^���H�Рۤf�ƙno931�K� ��D�h�`dBP��}SA������MD�@����!�x{ո�גAwp"��X�D0��/[�ք���*c���'ou�{"�f 3�$X�yq7�2�l��#b���&��<��m���pn!��T�����63�#3�(�^e8��Z��iHU�O8�<}�eKu-Ǟ��L1Zj�S�;��a0�E�s��R!����>��.��ֻ�g�����m��q-�ޓ��$1x-9q�����W�U"���޺�l�X�"�؍nM�VEY�w��Y.ԟ��8�������2L��*yIsD��a���~��`�`<?�-OD� �;}^˕���tɣ:YDX,(-�ܞ�ϲ`9f��D��r`�̪�Ky��h�[ �����s)g�2=�����@�����Z�Q���%˶܁���~�^��`��L�٩u�Bk�r�Ҽg��qPCc<��G�~���l���L]�8��~�v�-i��{?�Pn9��K�P��sK,����eK"�g����$J�찖�F=AW�N;�iƍw�s|!�&��J>ѭ>�u����QL�-�%:@���~r�ê�s�nX\��B�HT�Tcmۆ߆��l�g�ơ&Q�/�1����V/����n���%����nF5Do"��A�inη!��ց�X�ZzM5�y��S@SL�g�c�����/���B�������N;��H�������	h4�]�&��Aex\�ǧR�����mĴP����@���>P��FF�{������ð4�|���j�4���µi�u;M�Q��|�S�I�b</l\�tel�>@��{V�>���z	������i��~p�A+Ÿ��{���c$o�j2dal ��i?�U�'�q�.	��v{��!�����SS�E�uh�1Z��*p�q�
�L����mV���+�E�u�x�XOQ�����}�#�VL�9�1�1Y��Ʉl}��0���YZ�,1�X��
#��	��2!cA�����-IƳ���[����,�^�UȶL�7��?�"�-l0x��L,n�/�]��mB' B������,�\�0:7\�S��M�:�2���$⛴H8����7FX<+�t����������\�<Ր�JX���qG~�f&+����Sx��4�.�h|~�����ǯ?��_�y?�t�O���c�O*x�}ƺ��������i���4P����_8�G�k:�:Ek�x�$�����?����?���he�Q铢�����`�}T�dt�4-����z�������~K��km�~d�G�N�k�R8=<<�ٛ�      [   �  x����r�6���Sh�YXE\	h'��]�ǒ5��l��p�T@RNk�7�7ȋ�H9�S5SS<�����A�;WJ	yxx(>���Ǽ�� T��3)��p(�q��muTi���/���I�m|�?�~��b%3+}��X<���6��_�	����q?��^��ZhZ�˒֌��BK:���ԟƟ�~�TZA�45[�{�Jh�%��7�RhC���ǖ!��v�y5���Y�:@�,��7������.'I�Y���¬0�d��rt�0r";?2Tja��O�~`m��N�%�Pۧ�r�0�I'��Y�M*�)9�|L��>�y�� ����z�۸��a�J��gy#e�!�xٕ1m:vֹz��*���Ml/�>1t{r�]�q�D�o2ړ&��Mya'ϝʸ\$K>�"��
ԕ�d�g�j�i),q}R��2�ek%,a}Zb���2ZXb��67i���P<8������ImzS�Prǿ�M�$D�N~�լ���4;����#���?���n��?�M����o�3�J8�����kg׌n�or�����(��b.��톱,-��)ޏe�����:fZg���t�o�}�����j2�� Ws�y�Zx�����:^�'���s&�@v|=�_FNaS� g�9*R5�w�bOÔ~�"B�t^W�X�c��a
)��¶�"�]8��"RJJ��U�*b���l�t����BA��f����JW�6��~�����<� A='�@�*�82��**�P�˜���TU(Q"+/p2��
y�����@g:�������S���� re���mb�P+K���
��:�����X��_Ğ�	ӪF��۴�hk���u�]��@�@��6/wK5��ꉠuf,Hk9�W�4j ���TJ|�:F�����/o9ݤPk�t�7՚��e��5`��0r']��/�yI���Yܡ8]Γ�ړΪ�Ie����[�G��]w���Pr���I<5�W�t����D��荤p�bd���]jМu-�7x�o�7��Ӯ[��{��=��	D��9��0��澏˻"va�S���Am���*��Ԣ��7�bI�Oݷ�Y���\�;e��;�#��ƾ_��v99�3`B�Sr�_ߦ�I��>lȄ��b9�OmE�fV�`,�r>���G��R��v�F��Xɏy5�s� s�0����~X��T����<.�, ���8���4���q3�-h��)g�e\�e�@���}�
����g��_�婜�@��R�}7��3���4��Md���)�Vq��o��(�;V�$+���ܽ�	p;��.��>WV����Џ��F	�9�/��;���T���h2J�ǡ�s�x�$��@nq�0�:)x����r�x��_��1 � <���R�>�Zh
�/��f�8�!%��#�A e��ʻ�״[����IUAKS�׶�JB��G��s��d�jnŻWBn�PG�@����������t���R�Yj��M��7d���v�md��+@^W�1F���zi`]�J�kE�'\!^S7�k6��k��ʎ�`J�kK���t��ƪ�絣p-�@�kڨ62j&�Ay���wA�G
�{p�	3o�������=i��մG5�g��{jB�.�&���L��xd �l����U*�i�=p�٤�>�?_������CM�?{n��3,g,����E�5�4Z��hZ߂�~H�n�4��U�,^��l3���ô6_���yc%���7oX����i�1�!�V�Qԏ�C�EFgKZ	)�ys�׋p�--��W]�YE��P���F��#�����G�䨵���
���::s ��6��_P���Җ�>�Ǔ����=L]縉���_Kf)��i,�'1�����k2+Gq�=L��g������3��tiE�Xr�9+�����0FSxS�Q�ܲL�y*��3g�E:�N%��22_�G)�u�u�}ɼ��e���䬫Y���eW>w�CLBLӰ��&�g�t������������2����閣k������"=Ba����A���!��_5��{��u*> U�,�S����4�߿���B=8��9ʎA��^S���!{0N�U�u���Tn��%�"'{�M��d(g�I^����a��ѝ���b��h<M���.\ww���)\�ua��J���#�/�-�_.*���uTΝs$�Ԕno������4T�#�`2v�Xu{ƾ!�;���o������C�1�ONxr�����y�Ъ��!�/��n���t�8eW���8_�����|ӕ�+�JBIӈ��G�1�X��(�*��v��2��c�C�W9^�q��|UY�!J��v�/�*��;�Gh���j������ 7���w�ġ�QϬw(FU`|ήKL˝��`|J��m�����Y�=r���S��v䌴+	�)����+�̊���R��tϨ������>3G���T�_���(�j`�J���TV1�YZ�����F&C|�9�܎�T`|*�W���J
��"{�;F�RJ���6��
���348fFU)CB���L]	Z��h(e!����7�>YL���=��9!���F*�����C�j��T���
&�i���NS�aS9k���x�j%r�GWBZ$K���OM`��J�>�	��?���?�g2J�T �۸�f�I���������Þ]�(mHVR�syWPi؋��L���.1'̕����XW�."���Xi�Dm�<��nd}��a����n���*c��-ko�:�C��=�d�[.�"=Ҭ?'���9x��b��6q���V�1!D�����6�5�˜3���H|���8��j��Ü�%>2jre(��م�v�CZ����w>]�>;<;�<y~�k�c-��;�UU[w�,,�O_aN���_����J�Z*+��c�+G��9�D@Ο����Wy,��6GVz�_�&��j�G�_t�>���}��c���׎>��~=��GR�:����;      a   �   x�}��j�0E��Wl-�yȲԅ)R�N�X
��-���%�H3Ž��a�VW�϶� D�XԆ>�s���}��O�� {V��&����\�]T�[i�����<���y�݁3"(��L� 1�"�(� ��)��z��Oe����/�e\؍��.��^ۭ�iO���Rj�1c�8��D')$�PCfr�R5o����I�     