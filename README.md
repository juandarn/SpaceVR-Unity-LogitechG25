# 🚀 Space Simulation Project in Unity

## 🎮 Overview

The project began with the goal of developing a **virtual reality (VR) parking simulator** using the **Logitech G25 Wheel** as the main control device.  
During the initial stages, the connection between the hardware and the **Unity** game engine was successfully established, allowing the wheel to function as a customized joystick.  

However, due to technical compatibility limitations—such as incomplete gear detection and the lack of a functional clutch pedal—the project was redefined.  
Following this change, a **fully developed space video game in Unity** was created, **playable in virtual reality with Oculus Rift** and **controlled using the Logitech G25 wheel**.  
The result is an immersive and smooth experience that builds upon the simulator’s initial foundation and transforms it into a dynamic and engaging space exploration environment.

---

## 🧩 Initial Development

- The **Logitech G25** was registered as a joystick-type device in Unity.  
- **Custom controls** were created to map each wheel action to simulator functions.  
- A **C# script** was developed to capture the wheel’s signals and translate them into 3D movement within the environment.  
- The script was linked to the main object (the spaceship), allowing **direct interaction between hardware and software**.

This stage established the foundation for the control system later used in the final space game.

---

## ⚙️ Technical Limitations

During the early stages, the following limitations were identified:

- The G25 **only detected gears 1 and 2**, while the remaining gears and reverse were not recognized by Unity.  
- The **clutch pedal** was detected as a button but didn’t send functional input data.  
- These issues persisted even after several tests and adjustments, mainly due to incompatibilities between Unity’s input libraries and the G25 hardware.  

These constraints motivated a shift toward a more creative and technically viable project.

---

## 🌌 Space VR Game

The final result was a **fully functional space video game**, played in first-person view with **Oculus Rift** and controlled using the **Logitech G25 wheel**.  

### Main Features:
- **Space terrain and starfield** with realistic depth perception.  
- **Controllable spaceship** with fine-tuned sensitivity and precise movements.  
- **First-person camera**, simulating the pilot’s cockpit view.  
- **Full VR interaction**, providing a stable and immersive experience.  

### Gameplay Mechanics:

1. **Target shooting and health recovery:**  
   The player must **hit different targets placed throughout the space environment** while **gradually recovering health**, aiming to **score as many points as possible** before time runs out.  
   This mechanic tested the wheel’s precision, responsiveness, and the overall stability of the VR system.

2. **Smooth flight maneuvers**, carefully calibrated to prevent motion sickness in VR.  
3. **Hybrid control system**, combining the Logitech wheel and Oculus Rift headset for a unique spatial driving experience.

---

## 🔧 Technical Development

Throughout development, the following work was done:
- **Calibrated spaceship sensitivity** in ascending, descending, and rotational movements.  
- **Optimized motion controls** to ensure comfortable and natural VR gameplay.  
- **Implemented custom C# scripts** to translate G25 input signals into spaceship motion.  
- **Integrated Oculus Rift** into Unity for real-time immersive visualization.  
- **Adjusted performance and graphical stability** within the space environment.

---

## 🎥 Demo Video

> 🎬 **Gameplay demo:**  
> [Watch on GitHub](https://github.com/user-attachments/assets/d6be2f17-cd1a-4ed4-9419-fead64238d14)

---

## 🧠 Open Lab Presentation

The video game was **officially presented at the Open Lab of Universidad de los Andes**,  
as part of the final showcase for the **Mixed Reality** course.  

During the event, attendees could **experience the game in real time** using the **Oculus Rift headset** and **Logitech G25 wheel**,  
testing the spaceship controls and the interactive health-recovery mechanics.  

The presentation received positive feedback for its immersive environment,  
smooth control responsiveness, and the balance achieved between gameplay challenge and comfort in VR.

---

## 📚 References

- [Basic configuration of custom controls in Unity](https://youtu.be/ST8meQg1-04?si=sG-fkp8jw1L82Yi7)  
- [Joystick input detection tutorial](https://youtu.be/2N6BFeVzbDY?si=xu5QGM0nr81kJSSM)  
- [Unity flight simulation (spaceship control)](https://youtu.be/CLttqDJ9O5M?si=1KPFmNo7-fsHZ_iD)

---

## 👨‍💻 Author

**Juan David Ríos Nisperuza**  

Developed as part of the **Mixed Reality course – Universidad de los Andes**  

Bogotá, Colombia 🇨🇴  

---
