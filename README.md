# pdfDSNFT

Aplicacion web ASP.NET Core MVC para registrar documentos de normas sectoriales y generar archivos PDF asociados a procesos de validacion metodologica.

El sistema permite capturar informacion del documento, generar PDFs en diferentes etapas del proceso, consultar el historial, editar registros y eliminar documentos generados.

## Caracteristicas

- Registro de documentos con codigo, version, titulo, mesa sectorial y fechas de validacion.
- Generacion de PDFs con QuestPDF para:
  - Validacion metodologica inicial.
  - Aprobacion de verificacion metodologica.
  - Post-validacion.
  - Notificacion de salida conforme.
- Historial paginado de documentos generados.
- Edicion y eliminacion de registros.
- Persistencia con SQL Server y Entity Framework Core.
- Ejecucion local con .NET 8 o mediante Docker Compose.

## Tecnologias

- .NET 8
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server 2022
- QuestPDF
- Bootstrap
- Docker / Docker Compose

## Estructura del proyecto

```text
Controllers/        Controladores MVC
Data/               Contexto de Entity Framework Core
Migrations/         Migraciones de base de datos
Models/             Modelos de dominio y validaciones
services/           Servicio de generacion de PDFs
Views/              Vistas Razor
wwwroot/            Archivos estaticos de la aplicacion
docker-compose.yml  Servicios de aplicacion y SQL Server
dockerfile          Imagen Docker de la aplicacion
```

## Requisitos

Para ejecutar con Docker:

- Docker
- Docker Compose

Para ejecutar localmente:

- .NET SDK 8.0
- SQL Server

## Configuracion

El proyecto no versiona credenciales reales. Para Docker, crea un archivo `.env` a partir del ejemplo:

```bash
cp .env.example .env
```

Edita `.env` y define una contrasena segura para SQL Server:

```env
SA_PASSWORD=Tu_password_seguro_123!
```

Para ejecucion local sin Docker, ajusta la cadena de conexion en `appsettings.json` o usa configuracion local/variables de entorno:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=pdfDSNFT;User Id=sa;Password=CHANGE_ME;TrustServerCertificate=True;"
}
```

## Ejecucion con Docker

Levanta la aplicacion y la base de datos:

```bash
docker compose up --build
```

En una primera instalacion, aplica las migraciones contra el SQL Server del contenedor:

```bash
ConnectionStrings__DefaultConnection="Server=localhost,1433;Database=pdfDSNFT;User Id=sa;Password=Tu_password_seguro_123!;TrustServerCertificate=True;" dotnet ef database update
```

La aplicacion quedara disponible en:

```text
http://localhost:8080
```

Los PDFs generados se almacenan localmente en la carpeta `pdfs/` y se montan dentro del contenedor en `wwwroot/pdfs`.

## Ejecucion local

Restaura dependencias:

```bash
dotnet restore
```

Aplica las migraciones a la base de datos:

```bash
dotnet ef database update
```

Ejecuta la aplicacion:

```bash
dotnet run
```

## Uso general

1. Ingresa al formulario de registro.
2. Completa los datos del documento.
3. Selecciona si corresponde a validacion inicial, post-validacion o ambas.
4. Guarda el registro para generar los PDFs asociados.
5. Consulta los documentos desde el historial.

## Archivos no versionados

Por seguridad y limpieza del repositorio, se ignoran:

- Credenciales locales (`.env`, `appsettings.Local.json`).
- Archivos temporales de compilacion (`bin/`, `obj/`).
- Configuracion de usuario de Visual Studio (`*.user`, `.vs/`).
- PDFs generados (`pdfs/`, `wwwroot/pdfs/`).

## Estado del proyecto

Proyecto en desarrollo para automatizar la generacion y gestion de documentos PDF relacionados con normas sectoriales y procesos de validacion metodologica.
