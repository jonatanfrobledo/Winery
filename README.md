# Documentación del Controlador de Autenticación

## Introducción
El controlador de autenticación permite a los usuarios iniciar sesión en la aplicación y recibir un token JWT (JSON Web Token) que se utilizará para autenticar futuras solicitudes a la API.

## Endpoint de Autenticación

- **URL**: `POST /api/auth`
- **Descripción**: Este endpoint permite a los usuarios autenticarse y obtener un token de acceso.

### Cuerpo de la Solicitud
El cuerpo de la solicitud debe contener las credenciales del usuario en formato JSON:

```json
{
    "username": "Jonatan",
    "password": "Jonatan"
}
```
# Documentación del Controlador de Usuarios

## Introducción
El controlador de usuarios permite gestionar las cuentas de usuario en la aplicación. Incluye funcionalidades para registrar nuevos usuarios y obtener una lista de todos los usuarios registrados.

## Endpoints del Controlador de Usuarios

### Registro de Usuario

- **URL**: `POST /api/users`
- **Descripción**: Este endpoint permite registrar un nuevo usuario en la aplicación.

#### Cuerpo de la Solicitud
El cuerpo de la solicitud debe contener los datos del usuario en formato JSON. Por ejemplo:

```json
{
    "username": "usuario",
    "password": "contraseña"
}
```
# Documentación del Controlador de Vinos

## Introducción
El controlador de vinos permite gestionar la información relacionada con los vinos en la aplicación. Incluye funcionalidades para obtener todos los vinos, buscar un vino por nombre, obtener vinos por variedad, registrar nuevos vinos y añadir stock a un vino existente.

## Endpoints del Controlador de Vinos

### Obtener Todos los Vinos

- **URL**: `GET /api/wine`
- **Descripción**: Este endpoint devuelve la lista de todos los vinos registrados en la aplicación.

# Documentación del Controlador de Catas

## Introducción
El controlador de catas permite gestionar las catas de vinos en la aplicación. Proporciona funcionalidades para crear nuevas catas y obtener información sobre catas específicas mediante su identificador.

## Endpoints del Controlador de Catas

### 1. Crear una Nueva Cata

- **URL**: `POST /api/cata`
- **Descripción**: Este endpoint permite crear una nueva cata. Se debe proporcionar un DTO con los detalles de la cata en el cuerpo de la solicitud.

#### Cuerpo de la Solicitud
El cuerpo debe contener los datos de la cata en formato JSON. Por ejemplo:

```json
{
    "nombre": "Cata de Verano",
    "fecha": "2024-11-10",
    "vinos": [1, 2, 3], // IDs de los vinos involucrados en la cata
    "invitados": ["Juan", "María"]
}
