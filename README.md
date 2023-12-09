# Sistema Multi Base de Datos

Este es un proyecto de ejemplo que utiliza C# y .NET para interactuar con bases de datos SQL Server y Db4o. El proyecto está diseñado como una aplicación de formulario (`Form1`) que permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en una base de datos de contenidos multimedia.

## Configuración del Proyecto

### Base de Datos SQL Server

El proyecto se conecta a una base de datos SQL Server llamada "Netflix". Asegúrate de tener esta base de datos creada y configurada en tu entorno SQL Server. Puedes ajustar la cadena de conexión en el constructor de la clase `Form1` si es necesario.

### Db4o

El proyecto también utiliza Db4o, una base de datos orientada a objetos. Se espera que tengas un archivo de base de datos llamado "SMBDOO.dat" en la misma ubicación que la aplicación. Asegúrate de tener Db4o instalado y configurado.

## Funcionalidades Principales

El formulario (`Form1`) proporciona las siguientes funcionalidades:

1. **Inserción de Contenido:**
   - Permite insertar nuevos contenidos multimedia en la base de datos, ya sea en SQL Server o Db4o, según la selección del usuario.

2. **Consulta de Contenido:**
   - Permite consultar detalles de un contenido específico según el ID proporcionado.

3. **Actualización de Contenido:**
   - Permite actualizar los detalles de un contenido específico, ya sea en SQL Server o Db4o, según la selección del usuario.

4. **Eliminación de Contenido:**
   - Permite eliminar un contenido específico, ya sea en SQL Server o Db4o, según la selección del usuario.

## Uso del Código

El código proporciona una interfaz gráfica simple para interactuar con la base de datos. Asegúrate de entender y adaptar la lógica según tus necesidades específicas.
