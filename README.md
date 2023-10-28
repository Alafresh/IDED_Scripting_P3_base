# Readme - Refactored Target Shooting Game

Este documento describe la funcionalidad de un código que implementa patrones de diseño Command y Singleton en el contexto de un juego Tiro Al Blanco desarrollado en Unity. También se explica cómo se comunica a través de eventos entre los diferentes componentes del juego.

## Resumen

El código proporcionado consiste en una refactorización del controlador del jugador. En lugar de un controlador de jugador tradicional, se ha implementado un controlador de jugador que utiliza el patrón de diseño Command para gestionar disparos del dardo y un patrón Singleton para garantizar una única instancia del controlador en ejecución. Además, se ha implementado un controlador de juego (GameController) que también utiliza el patrón Singleton y emite eventos para comunicar su estado a otros componentes del juego en este caso la UI.

## Componentes Principales

### RefactoredPlayerController

- Clase que representa el controlador de jugador refactorizado.
- Utiliza el patrón Singleton para garantizar una única instancia de este controlador en el juego.
- En el método `ProcessShot`, crea e invoca un objeto `ShotCommand` para gestionar el disparo.

### ICommand

- Interfaz que define un comando (Command) que puede ser ejecutado.
- En este contexto, se utiliza para implementar el patrón Command.

### ShotCommand

- Clase que implementa el comando de disparo y hereda de la interfaz `ICommand`.
- Recibe una posición de destino y, al ejecutar, invoca el método `ProcessShot` del controlador de juego (`RefactoredGameController`) con la posición de destino.

### RefactoredUIController

- Controlador de la interfaz de usuario.
- Se comunica con el controlador de juego (`RefactoredGameController`) para actualizar la UI en respuesta a eventos.
- Maneja el evento de final de juego y actualiza la UI en función de la puntuación, las flechas restantes y la velocidad del viento.

### RefactoredGameController

- Controlador principal del juego.
- Utiliza el patrón Singleton para garantizar una única instancia en el juego.
- Implementa eventos (`OnGameOver` y `OnArrowShot`) para comunicar el estado del juego a otros componentes.
- Procesa disparos y disminuye el número de flechas. Si se quedan sin flechas, dispara el evento `OnGameOver`.

## Uso de Patrones de Diseño

- **Singleton**: Se utiliza en `RefactoredPlayerController` y `RefactoredGameController` para garantizar que solo exista una instancia de cada controlador en el juego.
- **Command**: Se utiliza en `RefactoredPlayerController` y `ShotCommand` para encapsular y ejecutar acciones relacionadas con el disparo.

## Comunicación a través de Eventos

La comunicación entre componentes se logra a través de eventos:

- `OnGameOver`: Este evento se dispara en `RefactoredGameController` cuando el juego ha terminado, es decir, cuando se quedan sin flechas.
- `OnArrowShot`: Se dispara en `RefactoredGameController` cada vez que se realiza un disparo exitoso.
- `UpdateUIOnArrowShot`: Este método en `RefactoredUIController` se suscribe al evento `OnArrowShot` y se encarga de actualizar la interfaz de usuario en respuesta a disparos exitosos.
- `HandleGameOver`: Este método en `RefactoredUIController` se suscribe al evento `OnGameOver` y se encarga de mostrar la ventana de GameOver con su debido boton para reiniciar el juego.

## Principios de OOP

El código también implementa conceptos clave de la programación orientada a objetos (OOP):

- **Herencia**: Los controladores (`RefactoredPlayerController`, `RefactoredUIController`, `RefactoredGameController`) heredan de las clases base (`PlayerControllerBase`, `UIControllerBase`, `GameControllerBase`) para extender su funcionalidad.
- **Encapsulamiento**: Los atributos y métodos son encapsulados dentro de las clases, lo que permite ocultar detalles de implementación y facilita el mantenimiento y la extensión del código.
- **Polimorfismo**: Consiste en redefinir un metodo de una clase padre en una clase hija como podemos ver en el `Start` de la clase `RefactoredPlayerController` o en el metodo `ProcessShot` de la clase `RefactoredGameController` entre otros.

Este código representa una mejora en la estructura y mantenibilidad de un juego Unity, al aplicar patrones de diseño y principios de OOP de manera efectiva.

## Inconvenientes de usar el patrón State

1. **Complejidad adicional**: Utilizar el patrón State significa que se debera crear diferentes "estados" para el juego, como esperar, disparar, mostrar dónde aterrizó la flecha, calcular la puntuación, etc. Esto puede hacer que el juego sea más complicado de lo necesario ya que es un prototipo simple.

2. **Más tiempo de desarrollo**: Hacer un juego con el patrón State lleva más tiempo y esfuerzo. Necesitas pensar y escribir mucho más código.

3. **Más clases y más trabajo**: Para cada estado y acción del juego, necesitare escribir más código, entonces tendre más clases y por ende mas cosas para gestionar.

4. **Manejo complicado del flujo**: Con el patrón State, debes pensar mucho en cómo el juego pasa de un estado a otro, lo que puede ser un problema si solo estás haciendo un prototipo rápido.

5. **No tengo experiencia**: No tengo experincia implementando este patron entonces tampoco me iba a poner a inventar. 

**Estrategia de implementación si hubiera decidido usar el patrón State:**

1. **Decidir los estados**: Identificar los diferentes estados que necesita mi juego, como esperar a que el jugador dispare, mostrar dónde aterrizó la flecha, calcular la puntuación, etc.

2. **Hacer clases para los estados**: Crear diferentes "pedazos" de código para cada estado. Por ejemplo, una clase para "esperar" y otra para "mostrar el punto de aterrizaje".

3. **Indicar cuándo cambiar**: Deberia programar en mi juego para que cambie de un estado a otro en el momento adecuado. Si el jugador dispara, debe pasar al estado de "mostrar dónde aterrizó la flecha".

4. **Un solo trabajo**: Cada estado debe hacer su trabajo. Por ejemplo, cuando el juego está en el estado de "mostrar dónde aterrizó la flecha", debe mostrar eso en la pantalla.

Target picture: https://upload.wikimedia.org/wikipedia/commons/thumb/1/17/WA_80_cm_archery_target.svg/600px-WA_80_cm_archery_target.svg.png (retrieved on 22/10/2023)
Wind direction arrow: https://www.pngwing.com/en/free-png-tuhcc/download (retrieved on 25/10/2023)
