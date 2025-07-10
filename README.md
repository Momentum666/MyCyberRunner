# CyberRunner

A polished 2D platform game built with Unity and C#. Features smooth movement, double jump, air dash, and animation integration — designed to demonstrate clean, efficient game programming skills.

---

## 🔽 Download & Play

You can download the playable demo below and try it directly:

👉 [Download Windows Demo (ZIP)](https://drive.google.com/file/d/1nkFUYEoHg22pPIfAN2oKVPAN6sRVAt9z/view?usp=sharing)

> No installation required — just unzip and run `CyberRunner.exe`

**Tested on Windows 10 & 11.**

For best experience:
- Use arrow keys or A/D to move
- Press SPACE to jump (double jump supported)
- Press SHIFT in midair to dash

---

## Features 
- **Tight controls** - responsive keyboard input and fluid movement  
- **Double Jump & Dash** - midair dash with cooldown, state-limited double jumps   
- **Animator Integration** - dynamic animations based on velocity & ground state    
- **Clean code architecture** - OOP, component-driven, inspector-exposed fields  
- **Ground detection with Raycast** - precise jumping and landing behavior  
---

## Tech Stack 

- Unity 2D Engine  
- C# MonoBehaviour architecture  
- Rigidbody2D physics & Raycasting  
- Unity Animator + State Machines  
- Git for version control  

---

## Demo 

[Click here to watch the gameplay demo on YouTube](https://drive.google.com/file/d/1dbqoEWLDyHA30q33niDTN1AivHqU5BuJ/view?usp=sharing)

> The demo shows full character control, including movement, double jump, and air dash.  


---

## Performance & Architecture
Movement Efficiency
Frame-consistent physics: Player movement and jump behavior are handled using FixedUpdate with Rigidbody2D to ensure smooth and physics-consistent control.

Lightweight flip logic: Character flipping is implemented using simple rotation rather than scale inversion to avoid animation glitches or performance spikes.

## Animation System
State-driven animations: Animations dynamically respond to velocity and grounded status using Unity’s Animator parameters.

Optimized transitions: Reused animation transitions and minimized state complexity reduce overhead and keep the animation system clean.

## Performance & Power Awareness
While currently built for desktop, the system architecture is optimized to avoid unnecessary updates and is prepared for future energy-aware enhancements:

Dash cooldown limiter: Dashing is limited by a cooldown timer to prevent rapid physics calls.

Preprocessed ground detection: isGrounded is calculated early to avoid redundant checks during the update cycle.

Conditional input handling: Jump and dash logic is only triggered on relevant input, minimizing idle frame operations.

## Code Structure & Extensibility
Modular logic: Movement, jump, dash, animation, and direction control are all separated into clean, testable methods.

Inspector-friendly: Core gameplay parameters are exposed via SerializedField to allow easy tuning in Unity Editor.

Debug utilities: Debug.Log() and Gizmos are used to visualize state and collisions during development.

## Future Architecture Readiness
This game structure is intentionally designed to support further systems:

✅ State machine system for enemies and bosses

✅ Input abstraction layer for keyboard/gamepad compatibility

✅ Cooldown manager for advanced skill systems

✅ FX trigger system for sound and particle integration
