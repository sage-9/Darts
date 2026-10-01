# Darts

A local two-player **301** darts game built in Unity. There's no free aiming: you stop two oscillating sliders with perfect timing, one for horizontal and one for vertical, and the dart lands where they cross. Pass the mouse back and forth, and be the first to bring your score to exactly zero.

![Unity](https://img.shields.io/badge/Unity-6000.0.58f2-black?logo=unity)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![Render Pipeline](https://img.shields.io/badge/URP%202D-17.0.4-blue)
![Status](https://img.shields.io/badge/status-prototype-orange)

## How to Play

1. Pick a **difficulty** and enter both **player names** in the main menu, then press Play.
2. Both players start on **301**. Players alternate, one dart per turn.
3. On your turn, a horizontal slider sweeps back and forth. **Click** to lock the horizontal position.
4. A vertical slider then starts. **Click** again to lock the vertical position and throw.
5. Your dart's score is **subtracted** from your total.
6. If a throw would take you below zero (a bust), the throw scores nothing.
7. First player to reach **exactly 0** wins. Click after the winner banner to return to the main menu.

### Difficulty

Difficulty sets how fast the sliders move.

| Difficulty | Slider speed |
| ---------- | ------------ |
| Easy       | 0.5x |
| Medium     | 1.0x |
| Hard       | 1.5x |

### Scoring

A standard dartboard layout is used, based on where the dart lands relative to the board's radius.

| Zone | Score |
| ---- | ----- |
| Bullseye | 50 |
| Outer bull | 25 |
| Single (inner and outer) | Segment value (1-20) |
| Triple ring | 3x segment value |
| Double ring | 2x segment value |
| Off the scoring area | 0 |

## Controls

| Action | Input |
| ------ | ----- |
| Lock slider / throw | Left mouse button or touchscreen press |
| Menu navigation | Mouse (UI) |

## Getting Started

### Requirements

- Unity **6000.0.58f2** (Unity 6). Newer 6000.0.x patch versions should open fine.
- Git
- Visual Studio, Rider, or VS Code with the C# extension

### Run it

```bash
git clone https://github.com/sage-9/Darts.git
cd Darts
```

1. Open **Unity Hub** > **Add** > **Add project from disk** and select the `Darts` folder.
2. Open it with editor version `6000.0.58f2` (Hub will offer to install it).
3. Open `Assets/Scenes/MainMenuScene.unity`.
4. Press **Play**.

The first open is slow because Unity regenerates the `Library/` folder.

### Build

`File > Build Profiles`. `MainMenuScene` and `Game Scene` are already in the scene list. Pick your platform, then **Build**.

## Project Structure

```
Assets/
├── Scenes/               # MainMenuScene, Game Scene
├── Scripts/
│   ├── GameManager.cs        # Turn / round loop, pause, winner flow
│   ├── SliderManager.cs      # Two-stage aiming sequence
│   ├── Slider.cs             # Ping-pong slider, speed set by difficulty
│   ├── CentreSlider.cs       # Moves the aim marker on the board
│   ├── ScoreSystem.cs        # Hit position -> segment, ring, and score
│   ├── PlayerData.cs         # ScriptableObject: name and score
│   ├── GameSettingsData.cs   # ScriptableObject: difficulty
│   ├── AudioEvent.cs         # ScriptableObject-based sound events
│   ├── InputHandler.cs       # Wraps the Input System actions
│   ├── MainMenuManager.cs    # Menu, names, difficulty
│   ├── PlayerScoreUI.cs / TurnAnnouncerUI.cs / SceneLoader.cs
├── Sprites/              # Board and dart sprites
├── Sound/                # UI sound effects
├── Prefabs/              # Slider prefab
└── *.asset               # Player1, Player2, GameSettingsData, audio events
```

## Architecture Notes

- **ScriptableObject data.** Player names and scores, game settings, and sound cues are all ScriptableObject assets, so the menu and the game scene share state without singletons passing data around.
- **Coroutine-driven turn loop.** `GameManager` runs `Game > Round > Turn` as nested coroutines that wait on flags and events. Each turn announces the player, runs the slider sequence, then scores the throw.
- **Event-based decoupling.** The input handler, slider manager, score system, and UI talk through C# events, so none of them hold direct references to each other.
- **Polar-coordinate scoring.** `ScoreSystem` turns the hit offset from the board centre into an angle and radius, maps the angle onto the 20 segments in board order, and applies ring multipliers by radius ratio.
- **New Input System** with a 2D URP renderer.

## Credits

- Code and design: [Sage](https://sage9.itch.io) ([@sage-9](https://github.com/sage-9))
- UI sound effects: JDSherbert, *Ultimate UI SFX Pack*
- Font: Liberation Sans (SIL Open Font License, included with TextMesh Pro)

## Contact

Open to collabs and freelance work.

- itch.io: https://sage9.itch.io
- Email: olayiwolaladipo@gmail.com
