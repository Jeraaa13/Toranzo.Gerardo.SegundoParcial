# CRUD - Vehiculos

## Sobre Mí

Buenas, soy Gerardo Toranzo, el desarrollador de esta aplicación. Estoy en el segundo cuatrimestre de la carrera Tecnicatura Superior en Programacion de la UTN, esta es mi tercera aplicacion oficial, hice un juego con C# en el motor Unity, y despues hice un buscaminas con Python en el primer cuatrimestre de la carrera.

## Resumen

Esta aplicacion, es una herramienta de gestión de vehículos en un garaje. Permite a los usuarios realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) en una colección de vehículos. La aplicación es fácil de usar y proporciona una interfaz gráfica para interactuar con los datos de vehículos almacenados en un garaje virtual.

## Diagrama de Clases

![Diagrama de Clases](./Screenshots/Diagrama%20de%20clases.png)

## Cómo usar

1. Inicio de Sesión: Al abrir la aplicación, se muestra una ventana de inicio de sesión. Verificamos tus credenciales en un archivo JSON de usuarios. Si son correctas, se abre el formulario principal.

![Login](./Screenshots/login.PNG)

2. Formulario Principal: Aquí encontrarás botones, una lista de vehiculos, y etiquetas que muestran tu nombre de usuario y la fecha actual. Puedes realizar las siguientes acciones:
![CRUD](./Screenshots/CRUD.PNG)
    **Visualizador**: Consulta tus registros de acceso.
    
    ![Visualizador](./Screenshots/visualizador.PNG)
    
    **Serialización**: Elige cómo guardar.
    
    ![Serializar](./Screenshots/serializar.PNG)
    
    **Deserializar**: Elige como cargar tus datos.
    
    ![Deserializar](./Screenshots/deserializar.PNG)
    
    **Agregar/Modificar/Eliminar**: Administra tu colección de vehículos.
    
    ![Opciones](./Screenshots/AgregarAuto.PNG)
    
    ![Agregar](./Screenshots/AgregarUnAuto.PNG)
    
    **Modificar**:
    
    ![Modificar](./Screenshots/Modificar.PNG)
    
    **Ordenar**: Organiza tus vehículos según tus preferencias.
    
    ![OrdenarAsc](./Screenshots/OrdenadoAsc.PNG)
    
    ![OrdenarDesc](./Screenshots/OrdenadoDesc.PNG)

3. Salida Segura: Antes de salir, confirmaremos si deseas cerrar la aplicación.
   ![Salir](./Screenshots/CRUDsalir.PNG)