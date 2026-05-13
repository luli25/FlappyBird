# 🐦 Flappy Bird Clone

A complete recreation of the classic **Flappy Bird** game developed in **Unity 6** using **C#**.  
This project focuses on clean and optimized game architecture by implementing **Object Pooling** and the **Singleton** design pattern to improve performance, memory management, and scalability.

---

# 📖 Description

This project is a faithful clone of the original Flappy Bird game where the player controls a bird and must avoid colliding with pipes and the ground while trying to achieve the highest possible score.

The main objective of this project was to practice:

- Unity gameplay programming
- Game architecture patterns
- Performance optimization techniques
- Reusable and maintainable code structure

To optimize runtime performance, the game uses an **Object Pooling** system for spawning and recycling pipes and coins instead of constantly instantiating and destroying GameObjects.

The project also uses the **Singleton** pattern to centralize core game systems such as game management and score handling.

---

# ✨ Features

- 🎮 Classic Flappy Bird gameplay
- ♻️ Object Pooling system for obstacle spawning
- 🧩 Singleton pattern implementation
- 📈 Score tracking system
- ⚡ Optimized performance and memory usage
- 🕹️ Responsive controls
- 🔁 Endless gameplay loop
- 🎨 Simple and clean UI

---

# 🎮 How to Play

| Action | Control |
|--------|---------|
| Flap | `Space` / `Left Click` / `Tap` |
| Avoid obstacles | Don't hit pipes or the ground |
| Score points | Pass through pipes |

The game ends when the bird collides with an obstacle or the ground.

---

# 🚀 Getting Started

## Requirements

- **Unity 6**
- **Git**

---

## Installation

### 1. Clone the repository

```bash
git clone https://github.com/luli25/FlappyBird.git
```

2. Open the project
Open Unity Hub
Click Add Project
Select the cloned folder
Open the project using any version of Unity 6

---

🛠️ Built With
Unity 6
C#
Unity Physics System
Object Pooling Pattern
Singleton Pattern

---

## 🧠 Design Patterns Used

### Singleton Pattern

Used for centralized systems such as:

Game Manager
Spawn Manager

This ensures there is only one active instance accessible globally.

### Object Pooling

Instead of creating and destroying pipes repeatedly, obstacles are recycled from a pool of pre-instantiated objects, reducing:

Garbage collection
CPU overhead
Runtime instantiation costs

---

📄 License

This project is open source and available under the MIT License.

---

👨‍💻 Author

Developed by Luli25
