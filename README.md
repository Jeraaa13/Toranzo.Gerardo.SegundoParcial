# SEGUNDO PARCIAL LABORATORIO II CRUD - Vehiculos

## Sobre mí

Buenas, soy Gerardo Toranzo, el desarrollador de esta aplicación. Estoy en el segundo cuatrimestre de la carrera Tecnicatura Superior en Programacion de la UTN, esta es mi tercera aplicacion oficial, hice un juego con C# en el motor Unity, y despues hice un buscaminas con Python en el primer cuatrimestre de la carrera.

## Resumen

Esta aplicacion, es una herramienta de gestión de vehículos en un garaje. Permite a los usuarios realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) en una colección de vehículos. La aplicación es fácil de usar y proporciona una interfaz gráfica para interactuar con los datos de vehículos almacenados en un garaje virtual. Y a diferencia de la aplicación anterior esta persiste sus datos en una base de datos.

## Diagrama de clases

![Diagrama de Clases](./Screenshots/Diagrama%20de%20clases.png)

### Cómo usar
- **Inicio de Sesión:** Al abrir la aplicación, se muestra una ventana de inicio de sesión. Verificamos tus credenciales en un archivo JSON de usuarios. Si son correctas, se abre el formulario principal.

![Login](./Screenshots/login.PNG)

- **Perfiles de usuario:** Esta versión de la aplicación cuenta con la implementación de perfiles para los distintos usuarios, los cuales se dividen en 3:
- Administrador: puede realizar el CRUD (Create, Read, Update y Delete) completo y ver los logs de usuarios.
- Supervisor: puede realizar solamente ‘CRU’ (Create, Read y Update)
- Vendedor: solo puede realizar el ‘R’ (Read).

- **Formulario Principal:** Aquí encontrarás botones, una lista de vehiculos, y etiquetas que muestran tu nombre de usuario y la fecha actual. Puedes realizar las siguientes acciones:

![CRUD](./Screenshots/CRUD.PNG)

- **Visualizador**: Consulta tus registros de acceso.

![Visualizador](./Screenshots/visualizador.PNG)

**Cargar Datos**:

![Opciones](./Screenshots/AgregarAuto.PNG)

![Agregar](./Screenshots/AgregarUnAuto.PNG)

**Modificar**:

![Modificar](./Screenshots/Modificar.PNG)

**Ordenar**: Organiza tus vehículos según tus preferencias.

![OrdenarAsc](./Screenshots/OrdenadoAsc.PNG)

![OrdenarDesc](./Screenshots/OrdenadoDesc.PNG)

3. Salida Segura: Antes de salir, confirmaremos si deseas cerrar la aplicación.
   ![Salir](./Screenshots/CRUDsalir.PNG)