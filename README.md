# monedas-cerdito
Prueba técnica Coink


Tablas parametrizadas

Paises
* Fuente: https://gist.github.com/brenes/1095110#file-paises-csv
```sql
CREATE TABLE paises (
    id SERIAL PRIMARY KEY UNIQUE,
    codigo_pais CHAR(4) NOT NULL, 
    nombre_pais VARCHAR(255) NOT NULL,
    status_pais bool not null,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL
);
```

* procedimientos almacenados
    ```sql
    -- Leer todos los paises
    CREATE OR REPLACE FUNCTION obtener_todos_paises()
    RETURNS TABLE (id INT, codigo_pais CHAR(4), nombre_pais VARCHAR,  status_pais bool,created_at TIMESTAMP, updated_at TIMESTAMP) AS $$
    BEGIN
        RETURN QUERY SELECT * FROM paises ORDER BY id;
    END;
    $$ LANGUAGE plpgsql;
    ```

    ```sql
    -- Leer pais por id
    CREATE OR REPLACE FUNCTION obtener_pais_por_id(
        p_id INTEGER
    )
    RETURNS TABLE (
        id INTEGER,
        codigo_pais CHAR(4),
        nombre_pais VARCHAR,
        status_pais BOOLEAN,
        created_at TIMESTAMP,
        updated_at TIMESTAMP
    ) AS $$
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
    $$ LANGUAGE plpgsql;
    ```

    ```sql
    -- Crear pais
    CREATE OR REPLACE FUNCTION crear_pais(
        p_codigo_pais CHAR(4),
        p_nombre_pais VARCHAR,
        p_status_pais BOOLEAN
    )
    RETURNS VOID AS $$
    BEGIN
        INSERT INTO paises (codigo_pais, nombre_pais, status_pais, created_at, updated_at)
        VALUES (p_codigo_pais, p_nombre_pais, p_status_pais, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
    END;
    $$ LANGUAGE plpgsql;
    ```

    ```sql
    -- Actualizar pais
    CREATE OR REPLACE FUNCTION actualizar_pais(
        p_id INTEGER,
        p_codigo_pais CHAR(4),
        p_nombre_pais VARCHAR,
        p_status_pais BOOLEAN
    )
    RETURNS VOID AS $$
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
    $$ LANGUAGE plpgsql;
    ```

    ```sql
    -- Eliminar pais
    CREATE OR REPLACE FUNCTION eliminar_pais(
        p_id INTEGER
    )
    RETURNS VOID AS $$
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
    $$ LANGUAGE plpgsql;
    ```

Departamentos 
* Fuente: https://www.dian.gov.co/atencionciudadano/formulariosinstructivos/Formularios/2012/departamentos_2012.pdf
```sql
CREATE TABLE departamentos (
    id_departamento SERIAL PRIMARY KEY,
    codigo_departamento CHAR(2) NOT NULL UNIQUE,
    nombre_departamento VARCHAR(255) NOT NULL,
    status_departamento bool not null,
    pais_id INT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    
    CONSTRAINT fk_pais_id FOREIGN KEY (pais_id)
        REFERENCES paises (id) ON DELETE CASCADE   
);
```

* procedimientos almacenados
    ```sql
    -- Obtener todos los departamentos
    CREATE OR REPLACE FUNCTION obtener_todos_departamentos()
    RETURNS TABLE (
        id_departamento INT,
        codigo_departamento CHAR(2),
        nombre_departamento VARCHAR,
        status_departamento BOOLEAN,
        pais_id INT,
        created_at TIMESTAMP,
        updated_at TIMESTAMP
    ) AS $$
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
    $$ LANGUAGE plpgsql;
    ```

    ```sql
    -- Obtener departamento por id
    CREATE OR REPLACE FUNCTION obtener_departamento_por_id(
        p_id_departamento INT
    )
    RETURNS TABLE (
        id_departamento INT,
        codigo_departamento CHAR(2),
        nombre_departamento VARCHAR,
        status_departamento BOOLEAN,
        pais_id INT,
        created_at TIMESTAMP,
        updated_at TIMESTAMP
    ) AS $$
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
    $$ LANGUAGE plpgsql;
    ```

    ```sql
    -- Crear departamento
    CREATE OR REPLACE FUNCTION crear_departamento(
        p_codigo_departamento CHAR(2),
        p_nombre_departamento VARCHAR,
        p_status_departamento BOOLEAN,
        p_pais_id INT
    )
    RETURNS VOID AS $$
    BEGIN
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
        );
    END;
    $$ LANGUAGE plpgsql;
    ```

    ```sql
    -- Actualizar departamento
    CREATE OR REPLACE FUNCTION actualizar_departamento(
        p_id_departamento INT,
        p_codigo_departamento CHAR(2),
        p_nombre_departamento VARCHAR,
        p_status_departamento BOOLEAN,
        p_pais_id INT
    )
    RETURNS VOID AS $$
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
    $$ LANGUAGE plpgsql;
    ```

    ```sql
    -- Eliminar departamento
    CREATE OR REPLACE FUNCTION eliminar_departamento(
        p_id_departamento INT
    )
    RETURNS VOID AS $$
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
    $$ LANGUAGE plpgsql;
    ```

Municipios
* Fuente: https://www.dane.gov.co/files/censo2005/provincias/subregiones.xls
```sql
CREATE TABLE municipios (
    id SERIAL PRIMARY KEY,
    codigo_municipio CHAR(6) NOT NULL,
    nombre_municipio VARCHAR(255) NOT NULL,
    status_municipio bool not null,
    departamento_id CHAR(2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,

    CONSTRAINT fk_department FOREIGN KEY (departamento_id)
        REFERENCES departamentos (codigo_departamento) ON DELETE CASCADE
);
```

* procedimientos almacenados
    ```sql
    -- Obtener todos los municipios
    CREATE OR REPLACE FUNCTION obtener_todos_municipios()
    RETURNS TABLE (
        id INT, 
        codigo_municipio CHAR(6), 
        nombre_municipio VARCHAR, 
        status_municipio BOOLEAN, 
        departamento_id CHAR(2), 
        created_at TIMESTAMP, 
        updated_at TIMESTAMP
    ) AS $$
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
    $$ LANGUAGE plpgsql;
    ```

    ```sql
    -- Obtener municipio por id
    CREATE OR REPLACE FUNCTION obtener_municipio_por_id(
        p_id INT
    )
    RETURNS TABLE (
        id INT,
        codigo_municipio CHAR(6),
        nombre_municipio VARCHAR,
        status_municipio BOOLEAN,
        departamento_id CHAR(2),
        created_at TIMESTAMP,
        updated_at TIMESTAMP
    ) AS $$
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
    $$ LANGUAGE plpgsql;
    ```

    ```sql
    -- Crear municipio
    CREATE OR REPLACE FUNCTION crear_municipio(
        p_codigo_municipio CHAR(6),
        p_nombre_municipio VARCHAR,
        p_status_municipio BOOLEAN,
        p_departamento_id CHAR(2)
    )
    RETURNS VOID AS $$
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
        );
    END;
    $$ LANGUAGE plpgsql;
    ```

    ```sql
    -- Actualizar municipio
    CREATE OR REPLACE FUNCTION actualizar_municipio(
        p_id INT,
        p_codigo_municipio CHAR(6),
        p_nombre_municipio VARCHAR,
        p_status_municipio BOOLEAN,
        p_departamento_id CHAR(2)
    )
    RETURNS VOID AS $$
    BEGIN
        UPDATE municipios
        SET 
            codigo_municipio = p_codigo_municipio,
            nombre_municipio = p_nombre_municipio,
            status_municipio = p_status_municipio,
            departamento_id = p_departamento_id,
            updated_at = CURRENT_TIMESTAMP
        WHERE id = p_id;

        IF NOT FOUND THEN
            RAISE EXCEPTION 'No se encontró el municipio con el ID %', p_id;
        END IF;
    END;
    $$ LANGUAGE plpgsql;
    ```

    ```sql
    -- Eliminar municipio
    CREATE OR REPLACE FUNCTION eliminar_municipio(
        p_id INT
    )
    RETURNS VOID AS $$
    BEGIN
        UPDATE municipios
        SET 
            status_municipio = FALSE,
            updated_at = CURRENT_TIMESTAMP
        WHERE id = p_id;

        IF NOT FOUND THEN
            RAISE EXCEPTION 'No se encontró el municipio con el ID %', p_id;
        END IF;
    END;
    $$ LANGUAGE plpgsql;
    ```
Usuarios

```sql
CREATE TABLE usuarios (
    id SERIAL PRIMARY KEY,
    nombre_usuario VARCHAR(255) NOT NULL,
    telefono_usuario VARCHAR(20) NOT NULL,
    direccion_detalle VARCHAR(255) NOT NULL,
    pais_id INT NOT NULL,
    departamento_id CHAR(2) NOT NULL,
    municipio_id INT NOT NULL, 
    status_usuario BOOL NOT NULL DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,

    -- Relaciones (Foreign Keys)
    CONSTRAINT fk_pais FOREIGN KEY (pais_id)
        REFERENCES paises (id) ON DELETE RESTRICT,
    CONSTRAINT fk_departamento FOREIGN KEY (departamento_id)
        REFERENCES departamentos (codigo_departamento) ON DELETE RESTRICT,
    CONSTRAINT fk_municipio FOREIGN KEY (municipio_id)
        REFERENCES municipios (id) ON DELETE RESTRICT 
);
```

* procedimientos almacenados
    ```sql
    -- Obtener todos los usuarios
    CREATE OR REPLACE FUNCTION obtener_todos_los_usuarios()
    RETURNS TABLE (
        id INTEGER,
        nombre_usuario VARCHAR,
        telefono_usuario VARCHAR,
        direccion_detalle VARCHAR,
        pais_id INT,
        departamento_id CHAR(2),
        municipio_id INT,
        status_usuario BOOLEAN,
        created_at TIMESTAMP,
        updated_at TIMESTAMP
    ) AS $$
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
    $$ LANGUAGE plpgsql;
    ```

    ```sql
    -- Obtener usuario por id
    CREATE OR REPLACE FUNCTION obtener_usuario_por_id(
        p_id INTEGER
    )
    RETURNS TABLE (
        id INTEGER,
        nombre_usuario VARCHAR,
        telefono_usuario VARCHAR,
        direccion_detalle VARCHAR,
        pais_id INT,
        departamento_id CHAR(2),
        municipio_id INT,
        status_usuario BOOLEAN,
        created_at TIMESTAMP,
        updated_at TIMESTAMP
    ) AS $$
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
    $$ LANGUAGE plpgsql;
    ```

    ```sql
    -- Crear Usuario
    CREATE OR REPLACE FUNCTION crear_usuario(
        p_nombre_usuario VARCHAR,
        p_telefono_usuario VARCHAR,
        p_direccion_detalle VARCHAR,
        p_pais_id INT,
        p_departamento_id CHAR(2),
        p_municipio_id INT,
        p_status_usuario BOOLEAN
    )
    RETURNS TABLE (
        id INTEGER,
        nombre_usuario VARCHAR,
        telefono_usuario VARCHAR,
        direccion_detalle VARCHAR,
        pais_id INT,
        departamento_id CHAR(2),
        municipio_id INT,
        status_usuario BOOLEAN,
        created_at TIMESTAMP,
        updated_at TIMESTAMP
    ) AS $$
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
    ```

    ```sql
    -- Actualizar usuario
    CREATE OR REPLACE FUNCTION actualizar_usuario(
        p_id INTEGER,
        p_nombre_usuario VARCHAR,
        p_telefono_usuario VARCHAR,
        p_direccion_detalle VARCHAR,
        p_pais_id INT,
        p_departamento_id CHAR(2),
        p_municipio_id INT,
        p_status_usuario BOOLEAN
    )
    RETURNS VOID AS $$
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
    $$ LANGUAGE plpgsql;
    ```

    ```sql
    -- Eliminar usuario
        CREATE OR REPLACE FUNCTION eliminar_usuario(
        p_id INTEGER
    )
    RETURNS VOID AS $$
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
    $$ LANGUAGE plpgsql;
    ```
