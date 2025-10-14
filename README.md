# Academy Users (API POST UserRegistration)

## English Instructions

### Prerequisites
- .NET 8.0 SDK or later
- Visual Studio 2022 (preferably) or Visual Studio Code

### How to Run the Application

1. Clone the repository:
```bash
git clone https://github.com/Joovs/Academy.Users.git
cd Academy.Users
```
2. In the File.Validator.WebAPI/appsettings.json file you must edit the connection string to the Database

3. Run the API project:

- Visual Studio Comunity 2022: <br>
Run the project with the help of the Visual Studio IDE, clicking on the green triangle icon to run (📐🟩✅)

- Visual Studio Code
Build the solution:
```bash
dotnet build
```

Run the proyect:
```bash
dotnet run --project Academy.Users.WebAPI
```

The application will start and be available at:
- HTTP: http://localhost:5140

### API Documentation
The Swagger UI documentation is available at:
- http://localhost:5140/swagger
- http://localhost:5140/swagger/index.html

---

## Instrucciones en Español

### Prerrequisitos
- SDK de .NET 8.0 o superior
- Visual Studio 2022 (de preferencia) o Visual Studio Code

### Cómo Ejecutar la Aplicación

1. Clonar el repositorio:
```bash
git clone https://github.com/Joovs/Academy.Users.git
cd Academy.Users
```
2. En el archivo File.Validator.WebAPI/appsetings.json debes editar la cadena de conexión a la Base de Datos 

3. Ejecutar el proyecto API:
- Visual Studio Comunity 2022: <br>
Corre el proyecto con ayuda de Visual Studio IDE, dando clic en el ícono de triángulo verde (📐🟩✅)

- Visual Studio Code
Compilar la solución:
```bash
dotnet build
```

Correr el proyecto:
```bash
dotnet run --project Academy.Users.WebAPI
```

La aplicación estará disponible en:
- HTTP: http://localhost:5140

### Documentación de la API
La documentación de Swagger UI está disponible en:
- http://localhost:5140/swagger
- http://localhost:5140/swagger/index.html

## Project Structure / Estructura del Proyecto

```
Academy.Users/


├── Academy.Users.Application/      # Application Layer / Capa de Aplicación
├── Academy.Users.Domain/           # Domain Layer / Capa de Dominio
├── Academy.Users.Infrastructure/   # Infrastructure Layer / Capa de Infraestructura
├── Academy.Users.Presentation/     # Presentation Layer / Capa de Presentación
├── Academy.Users.WebAPI/           # API Layer / Capa de API
└── Academy.Users.sln               # Solution File / Archivo de Solución
```