# ♻️ Recycled!

A competitive two-player local co-op game built with **Unity** and **C#**, where players race to collect and sort trash into the correct recycling bins.

---

## 🎮 About

Two players navigate a shared map, picking up scattered pieces of trash and depositing them into their respective recycling bins. Sort correctly to gain points — sort wrong and you'll lose one. The player with the most points when time runs out wins!

But there's a catch: if too much trash piles up on the map without being collected, **both players lose**. Teamwork and speed matter just as much as accuracy.

---

## 🕹️ Controls

| Action         | Player 1         | Player 2         |
|----------------|------------------|------------------|
| Move Up        | `W`              | `↑` Arrow        |
| Move Down      | `S`              | `↓` Arrow        |
| Move Left      | `A`              | `←` Arrow        |
| Move Right     | `D`              | `→` Arrow        |
| Jump           | `Left Shift`     | `Right Shift`    |

> Trash is picked up and deposited automatically by walking over/into the correct bin — no additional button needed.

---

## ✅ How to Win

- **+1 point** for depositing trash into the **correct** bin
- **-1 point** for depositing trash into the **wrong** bin
- **Both players lose** if too much trash accumulates on the map
- The player with the **highest score** at the end of the round wins

---

## ⚙️ Features

- **Local two-player gameplay** on a shared screen
- **Dynamic trash spawning** — trash accumulates over time, creating time pressure
- **Shared lose condition** — encourages both players to clean up, not just compete
- **Score tracking** for each player
- **WebGL build** available for browser-based play (see `WebGL Builds/`)

---

## 🛠️ Built With

- [Unity](https://unity.com/) — game engine
- **C#** — game logic and player controllers
- **ShaderLab / HLSL** — custom shaders for visual effects
- **WebGL** — browser-compatible build target

---

## 🚀 Running the Game

### Play in Browser
▶️ **[Play Recycled! on Unity Play](https://play.unity.com/en/games/c61fc308-4536-4cef-9c9d-8d0bb47b3121/webgl-builds)**

A WebGL build is also included in the `WebGL Builds/` directory. Host it on any static web server or open via a local server to play in your browser.

### Run in Unity Editor
1. Clone the repository:
   ```bash
   git clone https://github.com/mcheng1359/Recycled.git
   ```
2. Open the project in **Unity** (recommended: Unity 2021.3 LTS or later)
3. Open the main scene from the `Assets/` folder
4. Press **Play** in the Unity Editor

---

## 📁 Project Structure

```
Recycled/
├── Assets/              # Game scripts, scenes, prefabs, art, and audio
├── Packages/            # Unity package dependencies
├── ProjectSettings/     # Unity project configuration
├── WebGL Builds/        # Pre-built WebGL output for browser play
└── Recycled!.slnx       # Visual Studio solution file
```

---

## 📄 License

This project is licensed under the [Apache 2.0 License](LICENSE).
