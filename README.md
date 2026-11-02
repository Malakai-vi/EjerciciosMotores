# EjerciciosMotores

Proyecto formativo consistente en el desarrollo progresivo de un videojuego de plataformas 2D en Unity, estructurado en tres niveles de complejidad creciente. El proyecto implementa control por físicas, gestión de estados, interfaces de usuario (UI), sistemas de interacción y control del tiempo.

---

## 🛠️ Tecnologías y Configuración
* **Motor:** Unity 2D (Core)
* **Lenguaje:** C#
* **Físicas:** 2D Physics (`Rigidbody2D`, `BoxCollider2D`, `CircleCollider2D`, `PhysicsMaterial2D`)
* **UI:** Canvas con TextMeshPro y Sliders
* **Control de versiones:** Git con GitHub Desktop y plantilla `.gitignore` estándar para proyectos de Unity

---

## 📋 Desarrollo por Niveles

### Nivel 1: Mecánicas Básicas de Plataformas
* **Entorno cerrado:** Delimitación del área jugable mediante `BoxCollider2D` estáticos para evitar que el personaje salga de los límites de la pantalla.
* **Movimiento del personaje:** Control horizontal mediante `Rigidbody2D.linearVelocity` para garantizar una respuesta precisa y salto vertical con impulsos lineales.
* **Plataformas estáticas:** Estructuras fijas con colisionadores sólidos para pruebas de salto y recorrido.
* **Zona de peligro y reaparición:** Trigger que detecta el tag `Player` al caer al vacío, reiniciando su posición al `PuntoAparicion` y anulando las velocidades residuales (`linearVelocity = Vector2.zero`).
* **Sistema de monedas:** Objetos coleccionables con triggers que notifican al `GameManager` para incrementar el contador de monedas y se destruyen al recogerse.
* **Cartelería y UI inicial:** Textos en Canvas mediante TextMeshPro para mostrar información contextual y el conteo de monedas en tiempo real.

---

### Nivel 2: Físicas, Interacción y Flujo de Escenas
* **Mini nivel recolector:** Configuración de 10 monedas distribuidas y una meta interactiva que evalúa la condición de victoria para mostrar el panel de éxito.
* **Sistema de vidas:** Implementación de un gestor de daño en `GameManager` con un total de 3 vidas. Al agotarse, se bloquea el control y se despliega la pantalla de Game Over.
* **Reinicio de escena:** Integración de `SceneManagement` en un controlador de interfaz para recargar la escena activa mediante `SceneManager.LoadScene(SceneManager.GetActiveScene().name)`.
* **Mecánica de llave y puerta:** Llave interactiva (`Is Trigger`) que, al colisionar con el jugador, desactiva el collider/GameObject de la puerta para permitir el paso y destruye el coleccionable.
* **Materiales físicos 2D (`PhysicsMaterial2D`):**
  * Plataforma de hielo con fricción 0 para simular deslizamiento e inercia.
  * Plataforma de rebote con restitución elevada (`bounciness = 0.9` / `1`) para saltos impulsados tipo trampolín.
* **Cajas empujables:** Objetos físicos con `Rigidbody2D` dinámico, restricción de rotación en Z y detección de colisiones continua para ser arrastrados y empujados por el jugador sin atravesar obstáculos.
* **Menú Principal:** Escena independiente registrada en `Build Settings` con opciones para iniciar la partida o salir de la aplicación (`Application.Quit()`).

---

### Nivel 3: Mecánicas Avanzadas y Combate
* **Detección de suelo rigurosa:** Empleo de `Physics2D.OverlapBox` en un objeto hijo (`PuntoPies`) filtrado por una capa específica (`LayerMask: Suelo`), evitando saltos infinitos.
* **Doble salto con cadencia:** Sistema de saltos máximos (2) reiniciables al tocar suelo, complementado con un temporizador (`Time.time >= tiempoSiguienteSalto`) para forzar un retardo mínimo entre impulsos.
* **Eliminación de enemigos por pisotón:**
  * Cuerpo con colisionador circular (`CircleCollider2D`) que inflige daño al chocar por los laterales.
  * Trigger superior ("Cabeza") que evalúa la velocidad de caída del jugador (`linearVelocity.y <= 0`); si impacta desde arriba, destruye al enemigo y aplica un rebote vertical al personaje.
* **Barra de vida tipo Slider:** Sustitución del texto numérico por un componente `Slider` de UI desvinculado de interacción manual, sincronizado directamente con la clase `SaludPlayer`.
* **Invulnerabilidad temporal con parpadeo:** Corrutina que activa un estado invulnerable tras recibir daño, alternando la visibilidad del `SpriteRenderer` a intervalos fijos antes de rehabilitar el daño.
* **Menú de Pausa:** Interfaz activable con la tecla **P** que congela el flujo de físicas y tiempo del motor mediante `Time.timeScale = 0`, ofreciendo opciones para reanudar la partida o regresar al menú principal restaurando la escala a 1.

---

## 🎮 Controles
* **Moverse:** Teclas `A` / `D` o Flechas de dirección
* **Saltar / Doble salto:** Tecla de salto configurada (`Espacio` o `Escape`)
* **Pausa:** Tecla `P`

---

## 🛠️ Dificultades Encontradas y Soluciones Técnicas

A lo largo del desarrollo del proyecto surgieron varios retos técnicos relacionados con la gestión de eventos de UI, el orden de colisiones en físicas 2D y la sincronización del ciclo de vida de los scripts. A continuación se detallan los principales problemas y su resolución:

### 1. Desvinculación de eventos UI en el botón de reinicio
* **Problema:** Al configurar el evento `On Click ()` del botón de reinicio, la escena no recargaba y en el Inspector aparecía la llamada bloqueada en `MonoScript.name`.
* **Causa:** Se había arrastrado el archivo de script `.cs` directamente desde la carpeta de Assets del proyecto al campo de evento, en lugar de una instancia viva del GameObject en la jerarquía.
* **Solución:** Se adjuntó el script `ControladorEscena` como componente a un GameObject presente en la escena activa y se arrastró dicho objeto desde la ventana *Hierarchy* al evento `On Click ()`, permitiendo la correcta exposición y llamada del método `ReiniciarNivel()`.

### 2. Intangibilidad física de los pinchos frente a objetos dinámicos
* **Problema:** Los pinchos restaban vida al jugador, pero las cajas con `Rigidbody2D` los atravesaban sin colisionar.
* **Causa:** El collider de los pinchos estaba configurado como `Is Trigger`, lo que en el motor de físicas de Unity anula la respuesta de colisión sólida para todos los cuerpos físicos.
* **Solución:** Se implementó una solución de doble collider en el objeto de los pinchos: un colisionador sólido para bloquear cajas y elementos del entorno, y un colisionador configurado como `Is Trigger` para gestionar exclusivamente el daño al jugador.

### 3. Conflicto de colisiones simultáneas en los enemigos
* **Problema:** Al duplicar enemigos, el jugador recibía daño en ocasiones al intentar saltar sobre ellos desde arriba, en lugar de eliminarlos.
* **Causa:** Al caer sobre el enemigo, el motor de físicas registraba la colisión sólida del cuerpo lateral milésimas antes (o simultáneamente) que el trigger de la cabeza. Además, las esquinas vivas del collider del cuerpo provocaban impactos indeseados.
* **Solución:** Se realizaron dos ajustes:
  1. Se sustituyó el collider del cuerpo por un `CircleCollider2D` para suavizar las esquinas y evitar registros anticipados.
  2. Se añadió una condición en el script de daño que comprueba si la velocidad vertical del jugador es negativa (`linearVelocity.y < -0.1f`) y su posición está por encima del enemigo, ignorando el daño lateral para dar prioridad absoluta al pisotón.

### 4. Ciclo de vida y detección de inputs en el menú de pausa
* **Problema:** Al pulsar la tecla configurada (**P**), el menú de pausa no se activaba.
* **Causa:** El script gestor de la pausa estaba adjunto al propio `PanelPausa`, el cual iniciaba el juego desactivado (`SetActive(false)`). Al estar el GameObject inactivo, Unity suspende la ejecución de su método `Update()`, imposibilitando la captura de eventos de teclado.
* **Solución:** Se desacopló la lógica a un GameObject gestor independiente (`GestorPausa`) que permanece siempre activo en la jerarquía, manteniendo activa la escucha de inputs por teclado y encargándose de conmutar la visibilidad del panel y el estado de `Time.timeScale`.