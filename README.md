# 🚀 Proyecto de Simulación Espacial en Unity

## 🎮 Descripción General

El proyecto comenzó con la intención de desarrollar un **simulador de parqueo en realidad virtual (VR)** utilizando el **volante Logitech G25 Wheels** como dispositivo principal de control.  
Durante las primeras etapas, se logró establecer la conexión entre el hardware y el motor gráfico **Unity**, permitiendo que el volante funcionara como un joystick personalizado.  

Sin embargo, debido a limitaciones técnicas de compatibilidad —como el reconocimiento incompleto de las marchas y la falta de respuesta funcional del pedal del embrague—, se decidió replantear el enfoque del proyecto.  
A partir de este cambio, se **desarrolló y finalizó un videojuego espacial en Unity**, totalmente **jugable en realidad virtual con gafas Oculus Rift** y **controlado mediante el volante Logitech G25**.  
El resultado fue una experiencia inmersiva y fluida, que aprovecha la infraestructura inicial del simulador y la transforma en un entorno dinámico y atractivo de exploración espacial.

---

## 🧩 Desarrollo Inicial

- Se registró el **Logitech G25** como dispositivo de tipo joystick en Unity.  
- Se construyeron **controles personalizados** para mapear cada acción del volante a funciones dentro del simulador.  
- Se desarrolló un **script en C#** encargado de capturar las señales del volante y traducirlas en movimientos dentro del entorno 3D.  
- El script fue vinculado al objeto principal (la nave), permitiendo una **interacción directa entre hardware y software**.

Este paso marcó la base para el sistema de control utilizado en el videojuego espacial final.

---

## ⚙️ Limitaciones Técnicas Encontradas

Durante la fase inicial se identificaron las siguientes limitaciones:

- El G25 **solo reconocía la marcha 1 y 2**, mientras que las demás y la reversa no eran detectadas por Unity.  
- El **pedal del embrague** se registraba como un botón, pero no enviaba información funcional.  
- Estos problemas persistieron incluso después de varias pruebas y configuraciones, debido a incompatibilidades entre las librerías de Unity y el hardware del G25.  

Estas restricciones motivaron el cambio hacia un proyecto más creativo y viable técnicamente.

---

## 🌌 Videojuego Espacial en VR

El resultado final fue un **videojuego espacial completamente funcional**, jugado en primera persona con **gafas Oculus Rift** y controlado por el **volante Logitech G25**.  

### Características principales:
- **Terreno espacial y cielo estrellado** con sensación realista de profundidad.  
- **Nave controlable** con movimientos precisos y sensibilidad ajustada.  
- **Cámara en primera persona**, simulando la vista desde el interior de la nave.  
- **Interacción en realidad virtual**, permitiendo una experiencia inmersiva y estable.  

### Dinámicas del juego:

1. **Disparo a objetivos y recuperación de vida:**  
   El jugador debía **acertar a diferentes objetivos distribuidos en el entorno espacial** mientras **recuperaba vida progresivamente**, buscando alcanzar la **mayor cantidad de puntos posible** antes de que se agotara el tiempo.  
   Esta mecánica permitió evaluar la precisión de los controles, la respuesta del volante G25 y la estabilidad del sistema VR.

2. **Maniobras de vuelo** suaves y calibradas para evitar mareos en VR.  
3. **Sistema de control híbrido**, combinando volante y gafas Oculus Rift para una sensación de conducción espacial única.

---

## 🔧 Desarrollo Técnico

Durante el desarrollo se trabajó en:
- **Calibrar la sensibilidad de la nave** en ascensos, descensos y giros.  
- **Optimizar los movimientos** para que fueran cómodos y naturales dentro del entorno VR.  
- **Implementar scripts personalizados** para traducir las señales del G25 a rotaciones y desplazamientos de la nave.  
- **Integrar las gafas Oculus Rift** al entorno de Unity para permitir la visualización inmersiva en tiempo real.  
- **Ajustar el rendimiento gráfico y la estabilidad** del entorno espacial.

---

## 🎥 Video Demo

> 🎬 **Demo del videojuego en acción:**  
> [Ver video en GitHub](https://github.com/user-attachments/assets/d6be2f17-cd1a-4ed4-9419-fead64238d14)

---

## 📚 Referencias

- [Configuración básica de controles personalizados en Unity](https://youtu.be/ST8meQg1-04?si=sG-fkp8jw1L82Yi7)  
- [Tutorial de detección de input con joystick](https://youtu.be/2N6BFeVzbDY?si=xu5QGM0nr81kJSSM)  
- [Simulación de vuelo en Unity (control de nave)](https://youtu.be/CLttqDJ9O5M?si=1KPFmNo7-fsHZ_iD)

---

## 👨‍💻 Autor

**Juan David Ríos Nisperuza**  

Proyecto desarrollado como parte del curso de **Realidad Mixta – Universidad de los Andes**  

Bogotá, Colombia 🇨🇴  


