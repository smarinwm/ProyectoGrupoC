# Microservicios de productos, estanterías y albaranes con .NET 6

Proyecto de práctica desarrollado con **C#**, **.NET 6** y **ASP.NET Core Web API** para trabajar una arquitectura basada en microservicios, comunicación HTTP entre servicios, inyección de dependencias, pruebas automatizadas e integración continua con **GitHub Actions**.

La solución está formada por servicios independientes para **productos** y **estanterías**, además de una API agregadora de **albaranes de entrega** que consulta ambos servicios y compone una respuesta con la información necesaria.

> Repositorio de carácter formativo y de trabajo en grupo. Se presenta como práctica técnica y no como un producto individual de producción.

## Arquitectura del proyecto

La solución contiene tres aplicaciones principales y dos proyectos de pruebas:

```text
ProyectoGrupoC/
├── Grupo5.Producto/
├── GrupoC.Estanteria/
├── ProyectoGrupoC/
├── TestProductos/
├── TestEstanteria/
├── .github/
│   └── workflows/
│       └── dotnet.yml
└── ProyectoGrupoC.sln
```

### `Grupo5.Producto`

Microservicio encargado de consultar productos.

Expone un endpoint:

```text
GET /api/Producto/{id}
```

El controlador utiliza `IProductoRepository` para desacoplar el acceso a los datos de la capa HTTP.

### `GrupoC.Estanteria`

Microservicio encargado de consultar la información de una estantería.

Expone:

```text
GET /api/Estanteria/{id}
```

La lógica de acceso se abstrae mediante `IEstanteriaProvider`.

### `ProyectoGrupoC`

API agregadora encargada de generar la información de un albarán de entrega.

Su endpoint principal es:

```text
GET /api/AlbaranDeEntrega/estanterias/{estanteriaId}
```

El flujo de trabajo es:

1. Consulta el microservicio de estanterías.
2. Recupera los identificadores de los productos asociados.
3. Consulta el microservicio de productos para cada elemento.
4. Enriquece la información de la estantería con el detalle de cada producto.
5. Devuelve una respuesta agregada.

Este enfoque permite practicar la **composición de información procedente de varios microservicios**.

## Tecnologías utilizadas

- **C#**
- **.NET 6**
- **ASP.NET Core Web API**
- **HttpClientFactory**
- **Dependency Injection**
- **Swagger / OpenAPI**
- **Newtonsoft.Json**
- **MSTest**
- **GitHub Actions**
- **YAML**
- **Visual Studio**

## Comunicación entre servicios

La API de albaranes utiliza `IHttpClientFactory` para consumir los servicios de productos y estanterías.

Las URL base se definen mediante configuración:

```json
"Services": {
  "Estanterias": "http://localhost:5000",
  "Productos": "http://localhost:5100"
}
```

Los servicios de aplicación utilizan clientes HTTP con nombre para realizar las peticiones a las APIs correspondientes.

## Inyección de dependencias

El proyecto utiliza el contenedor de dependencias integrado de ASP.NET Core para trabajar con abstracciones.

Entre los componentes utilizados se encuentran:

```text
IProductoRepository
IEstanteriaProvider
IProductoService
IEstanteriaService
```

Esto ayuda a separar las responsabilidades entre controladores, lógica de acceso y comunicación con servicios externos.

## Pruebas automatizadas

La solución incluye proyectos de pruebas para productos y estanterías:

```text
TestProductos/
TestEstanteria/
```

Las pruebas están desarrolladas con **MSTest** y comprueban casos como:

- Respuesta `200 OK` cuando el recurso existe.
- Respuesta `404 Not Found` cuando se solicita un identificador inexistente.

Para ejecutar las pruebas:

```bash
dotnet test
```

## Integración continua con GitHub Actions

El repositorio incluye el workflow:

```text
.github/workflows/dotnet.yml
```

El pipeline se ejecuta en `push` y `pull_request` sobre la rama `main` y realiza:

```text
Restore
   ↓
Build
   ↓
Test
```

Utiliza un runner Ubuntu y configura automáticamente **.NET 6**.

Esto permite practicar un flujo básico de **integración continua** desde GitHub.

## Swagger / OpenAPI

Los servicios utilizan **Swagger** para documentar y probar los endpoints durante el desarrollo.

Una vez iniciado cada microservicio, se puede acceder a su interfaz Swagger desde la URL local correspondiente.

## Puesta en marcha

### Requisitos

- **.NET 6 SDK**
- Visual Studio 2022, Visual Studio Code o un IDE compatible.
- Puertos locales disponibles para ejecutar simultáneamente los servicios.

### Clonar el repositorio

```bash
git clone https://github.com/smarinwm/ProyectoGrupoC.git
cd ProyectoGrupoC
```

### Restaurar dependencias

```bash
dotnet restore
```

### Compilar

```bash
dotnet build
```

### Ejecutar las pruebas

```bash
dotnet test
```

### Ejecutar los servicios

Cada aplicación debe iniciarse por separado:

```bash
dotnet run --project Grupo5.Producto
dotnet run --project GrupoC.Estanteria
dotnet run --project ProyectoGrupoC
```

Para que la API agregadora funcione correctamente, las URL configuradas en `appsettings.json` deben coincidir con las direcciones reales de los microservicios.

## Objetivo didáctico

Este repositorio permite practicar conceptos como:

- Arquitectura de microservicios.
- APIs REST con ASP.NET Core.
- Comunicación entre servicios mediante HTTP.
- `HttpClientFactory`.
- Inyección de dependencias.
- Uso de interfaces para desacoplar componentes.
- Programación asíncrona.
- Serialización y deserialización JSON.
- Composición de respuestas procedentes de varias APIs.
- Swagger y OpenAPI.
- Pruebas unitarias con MSTest.
- Integración continua con GitHub Actions.
- Pipelines definidos mediante YAML.

## Consideraciones

El proyecto tiene una finalidad principalmente **educativa y de práctica en equipo**.

Antes de utilizar una arquitectura similar en producción convendría incorporar, entre otros aspectos:

- Persistencia real e independiente para cada microservicio.
- Gestión de errores entre servicios.
- Timeouts y políticas de reintento.
- Circuit breakers.
- Logging centralizado.
- Trazabilidad distribuida.
- Autenticación y autorización.
- Gestión segura de configuración y secretos.
- Contenedores Docker.
- Tests de integración y contratos entre servicios.

## Perfil

**Silverio Marín** — Docente TIC en Valencia, especializado en programación, desarrollo backend y tecnologías .NET.

Más contenidos sobre **programación y desarrollo de software**:

**[silveriomarin.com/programacion](https://silveriomarin.com/programacion/)**

GitHub: **[@smarinwm](https://github.com/smarinwm)**
