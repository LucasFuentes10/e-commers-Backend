# ECommerce API - Backend (Clean Architecture)

Proyecto desarrollado para la Tecnicatura Universitaria en Desarrollo de Software.

## Tecnologías utilizadas
- .NET 8
- Clean Architecture
- CQRS + MediatR
- Entity Framework Core + SQLite
- JWT Authentication
- FluentValidation + Global Exception Handler

---

# Endpoints principales

## Auth
- `POST /api/auth/register` → Registro de usuario
- `POST /api/auth/login` → Login y obtención de token

## Products
- `POST /api/products` → Crear producto (solo Admin)
- `GET /api/products` → Listar productos (requiere token)
- `GET /api/products/{id}` → Obtener por ID
- `PUT /api/products/{id}` → Actualizar producto
- `DELETE /api/products/{id}` → Eliminar producto (solo Admin)

## Dashboard
- `GET /api/dashboard` → Resumen general (requiere token)

---

# Cómo ejecutar el proyecto

## 1. Restaurar paquetes
```bash
dotnet restore
```

## 2. Compilar
```bash
dotnet build
```

## 3. Ejecutar API
```bash
dotnet run --project ECommerce.Api
```

La API se ejecutará normalmente en:

```txt
http://localhost:5074
```

---

# Base de datos

La base de datos SQLite se llama:

```txt
ecommerce.db
```

Se crea automáticamente al ejecutar las migraciones.

---

# Migraciones EF Core

## Crear migración
```bash
dotnet ef migrations add NombreMigracion --project ECommerce.Infrastructure --startup-project ECommerce.Api
```

## Aplicar migraciones
```bash
dotnet ef database update --project ECommerce.Infrastructure --startup-project ECommerce.Api
```

---

# Cómo usar JWT Authentication

## 1. Registrar usuario

Entrar a Swagger:

```txt
http://localhost:5074/swagger
```

Usar:

```txt
POST /api/auth/register
```

Ejemplo:

```json
{
  "email": "lucas@gmail.com",
  "name": "Lucas",
  "password": "1234"
}
```

---

## 2. Iniciar sesión

Usar:

```txt
POST /api/auth/login
```

Ejemplo:

```json
{
  "email": "user@gmail.com",
  "password": "1234"
  "email": "lucas@gmail.com",
  "password": "1234"
  "email": "admin@gmail.com",
  "password": "1234"
}
```

La API devolverá un token JWT:

```json
{
  "userId": "...",
  "email": "lucas@gmail.com",
  "token": "eyJhbGciOiJIUzI1NiIs..."
}
```

---

## 3. Autorizarse en Swagger

1. Copiar únicamente el token JWT.
2. Presionar el botón:

```txt
Authorize
```

3. Pegar:

```txt
Bearer TU_TOKEN
```

Ejemplo:

```txt
Bearer eyJhbGciOiJIUzI1NiIs...
```

4. Presionar:

```txt
Authorize
```

5. Cerrar la ventana.

Ahora los endpoints protegidos funcionarán correctamente.

---

# Roles

## Usuario común
Puede:
- Ver productos
- Consultar dashboard

## Admin
Puede:
- Crear productos
- Actualizar productos
- Eliminar productos

---

# Usuario de prueba

## Usuario normal
- Email: `lucas@gmail.com`
- Password: `1234`

---

# Arquitectura del proyecto

```txt
ECommerce.Domain
→ Entidades e interfaces

ECommerce.Application
→ CQRS, Handlers, DTOs, Validaciones, JWT

ECommerce.Infrastructure
→ EF Core, SQLite, Repositories, Persistence

ECommerce.Api
→ Controllers, Swagger, Middleware, Authentication
```

---

# Características implementadas

✅ Clean Architecture  
✅ CQRS con MediatR  
✅ Repository Pattern  
✅ Entity Framework Core  
✅ SQLite  
✅ JWT Authentication  
✅ Swagger con Authorization  
✅ Global Exception Handler  
✅ CRUD completo de productos  
✅ Roles y autorización  
✅ Dashboard protegido  

---

Profesor: Nicolás Ortiz  
Alumno: Lucas Fuentes
