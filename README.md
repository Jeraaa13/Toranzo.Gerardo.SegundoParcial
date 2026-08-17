# CRUD - Vehicles (2nd midterm exam)

WinForms app for managing a collection of vehicles in a garage, evolved from the
[1st midterm exam](https://github.com/Jeraaa13/Toranzo.Gerardo.PrimerParcial) to persist data in
a SQL database instead of JSON files, and add role-based access. Built for Laboratorio II at UTN.

## Features

- Login screen, credentials checked against a JSON user file
- Role-based access: Admin (full CRUD + access logs), Supervisor (CRU), Seller (read-only)
- Vehicle data persisted in a SQL database
- Add, edit, delete, and sort vehicles
- Access log viewer
- Unit tests
- Confirmation prompt on exit

![Class diagram](./Screenshots/Diagrama%20de%20clases.png)

## Stack

C# WinForms (.NET 6), SQL Server (System.Data.SqlClient), Newtonsoft.Json

## Screenshots

| Login | CRUD | Access log |
|---|---|---|
| ![Login](./Screenshots/login.PNG) | ![CRUD](./Screenshots/CRUD.PNG) | ![Access log](./Screenshots/visualizador.PNG) |

| Add vehicle | Edit | Sort |
|---|---|---|
| ![Add](./Screenshots/AgregarUnAuto.PNG) | ![Edit](./Screenshots/Modificar.PNG) | ![Sort](./Screenshots/OrdenadoAsc.PNG) |
