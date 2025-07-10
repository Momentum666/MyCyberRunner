# CyberRunner

A polished 2D platformer built with Unity and C#. Features smooth movement, double jump, air dash, and animation integration — designed to demonstrate clean, efficient game programming skills.


---

## 🎮 Features | 游戏特色
- **Tight controls** - responsive keyboard input and fluid movement  
- **Double Jump & Dash** - midair dash with cooldown, state-limited double jumps   
- **Animator Integration** - dynamic animations based on velocity & ground state    
- **Clean code architecture** - OOP, component-driven, inspector-exposed fields  
- **Ground detection with Raycast** - precise jumping and landing behavior  
---

## 🧑‍💻 Tech Stack | 技术栈

- Unity 2D Engine  
- C# MonoBehaviour architecture  
- Rigidbody2D physics & Raycasting  
- Unity Animator + State Machines  
- Git for version control  

---

## 🎥 Demo | 游戏演示

[Click here to watch the gameplay demo on YouTube](https://youtu.be/your-demo-video-link)  

> The demo shows full character control, including movement, double jump, and air dash.  


---

## 🧩 How it works | 实现原理简述

Player movement is handled through input polling and Rigidbody2D velocity manipulation. Ground checking is done via raycasting, and all animations are tied to velocity and grounded state.

```csharp
if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
{
    rb.velocity = new Vector2(rb.velocity.x, jumpforce);
    jumpCount--;
}
