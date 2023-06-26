# API-REST-Devsu
Ejercicio práctico de desarrollo de un API REST.

## Índice de contenido
1. [Inicio rápido](#inicio-rapido)
2. [Advertencia](#advertencia)
3. [Estructura](#estructura)
4. [Licencia](#licencia)

## Inicio rápido
Debe contar con los siguientes programas y base de datos:

  - Visual Studio 2022 o Visual Code
  - .NET 7
  - Base de datos SQL Server

Con el archivo de nombre "API Devsu.postman_collection.json" puede importarlo a Postman y empezar a consumir el API REST.

## Advertencia
Antes de ejecutar el proyecto debe crear la base de datos ejecutando el archivo que está en la siguiente ruta:

  - \Devsu Database\BaseDatos.sql
  
De ser necesario puede cambiar la cadena de conexión a la base de datos en el archivo appsettings.json que se encuentra en la siguiente ruta:

  - \Devsu .NET\Devsu.API\appsettings.json

Recuerde que debe ser una cadena de conexión válida de SQL Server.

## Estructura

    Devsu.API/
       ├─ Controllers
       
    Devsu.Core/
       ├─ Features

    Devsu.Infrastructure/
       ├─ Repositories

## Licencia
[MIT](https://choosealicense.com/licenses/mit/)
