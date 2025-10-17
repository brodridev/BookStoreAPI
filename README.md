# BookStoreAPI

API REST en .NET 9 para gestionar libros y pedidos.

## Requisitos
- .NET SDK 9.0+

## Ejecutar localmente

```pwsh
# Restaurar dependencias (opcional)
dotnet restore

# Ejecutar
dotnet run --project .\BookStoreAPI.csproj
```

- La API arranca por defecto en http://localhost:5000 o https://localhost:5001 (según `launchSettings.json`).
- Endpoints principales:
  - `GET /api/books` – Lista libros
  - `GET /api/books/{id}` – Detalle de libro
  - `POST /api/books` – Crear
  - `PUT /api/books/{id}` – Actualizar
  - `DELETE /api/books/{id}` – Eliminar

## Estructura
- `Controllers/BooksController.cs`: Endpoints CRUD de libros
- `Services/IBookService.cs` y `Services/BookService.cs`: Lógica de negocio en memoria
- `Models/Book.cs`, `Models/Order.cs`: Modelos de dominio
- `Program.cs`: Configuración mínima de la app

## Desarrollo
- Recomendado: VS Code con C# Dev Kit, y extensiones para .NET.
- Formato/Lint: `dotnet format` (opcional).

## Despliegue
- Crear publicación self-contained o framework-dependent con `dotnet publish`.

## Licencia
MIT (puedo agregar `LICENSE` si lo deseas).
