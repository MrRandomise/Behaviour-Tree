# Behaviour Tree — AI Resource Collection

> **Учебный проект курса [OTUS «Разработчик игр на Unity»](https://otus.ru)**
>
> Educational project from the OTUS Unity Game Developer course.

---

## 📋 О проекте / About

**RU:** Демонстрация реализации искусственного интеллекта игрового персонажа с помощью паттерна **Behaviour Tree** (дерево поведения). Персонаж автономно добывает ресурсы на карте, перемещается к хранилищу и разгружает их — без написания сложной логики условий вручную.

**EN:** This project demonstrates AI behaviour for a game character implemented via the **Behaviour Tree** pattern. The character autonomously locates resource nodes (trees), chops them, carries resources to a barn, unloads them, and repeats the cycle — all driven by a data-driven behaviour tree.

---

## 🎮 Gameplay Overview

The AI agent follows a continuous resource-collection loop:

1. **Find the nearest tree** (active resource node on the map)
2. **Move towards it**
3. **Chop / extract resources** until the inventory is full or the tree is depleted
4. **Find the barn** (storage building)
5. **Move towards the barn**
6. **Unload resources** into the barn
7. Repeat from step 1

---

## 🌳 Behaviour Tree Structure

```
Root
└── Selector
    ├── Sequence  ──────────────────────  [Resource Gathering]
    │   ├── Condition : IsCharacterStorageEmpty
    │   ├── BTNode_FindResource     — find closest active tree
    │   ├── BTNode_MoveToTarget     — walk to the tree
    │   └── BTNode_ExtractResource  — chop until full / tree empty
    │
    └── Sequence  ──────────────────────  [Resource Unloading]
        ├── BTNode_FindBarn         — locate the barn
        ├── BTNode_MoveToTarget     — walk to the barn
        └── BTNode_UnloadResources  — deposit all resources
```

The **Selector** tries each branch in order: if the inventory is not empty the gathering branch fails its condition and control falls through to the unloading branch.

Original task diagram:

<img width="477" alt="Behaviour Tree diagram" src="https://github.com/UnityOtus/BTree-Practice/assets/156682538/24b70aac-cf33-4319-85a2-df0553cc7414">

---

## 🏗️ Architecture

The project is built on the **Atomic** framework (Entity-Component approach for Unity) combined with a custom **AIModule** that provides the Behaviour Tree runtime.

```
Assets/Scripts/
├── Content/               # MonoBehaviour scene objects
│   ├── Character.cs       # AI character (Core / View / AI sections)
│   ├── Tree.cs            # Resource node — deactivates when depleted
│   ├── Barn.cs            # Resource storage building
│   └── Axe.cs             # Melee hit detection (OverlapSphere)
│
└── Engine/
    ├── AI/
    │   ├── BTNodes/       # Custom Behaviour Tree leaf nodes
    │   │   ├── BTNode_FindResource.cs
    │   │   ├── BTNode_MoveToTarget.cs
    │   │   ├── BTNode_ExtractResource.cs
    │   │   ├── BTNode_FindBarn.cs
    │   │   └── BTNode_UnloadResources.cs
    │   ├── Conditions/    # Re-usable ScriptableObject conditions
    │   │   ├── IsCharacterStorageFull.cs
    │   │   └── IsCharacterStorageEmpty.cs
    │   ├── Actions/       # Re-usable ScriptableObject actions
    │   │   ├── GameObjectShow.cs
    │   │   └── GameObjectHide.cs
    │   └── Blackboard/    # Typed blackboard value wrapper
    │       └── BlackboardAtomicObject.cs
    ├── GameObject/        # Low-level components
    │   ├── ObjectAPI.cs   # String-key contracts for Atomic API
    │   ├── ObjectType.cs  # Object-type tags
    │   ├── ResourceStorage.cs
    │   ├── MoveComponent.cs
    │   ├── LookComponent.cs
    │   ├── ActionComponent.cs
    │   └── …
    └── System/
        └── ResourceService.cs  # Finds the closest active resource
```

### Key design decisions

| Concern | Solution |
|---|---|
| Decoupled AI logic | Each BT node is a `[Serializable]` class with no MonoBehaviour dependency |
| Shared state | `IBlackboard` key-value store — nodes communicate only via the blackboard |
| Data-driven conditions | `AICondition` ScriptableObjects configurable in the Inspector |
| Component contracts | `ObjectAPI` string constants + `[Contract]` attributes enforce type safety |
| Animation integration | `AnimatorDispatcher` bridges animation events to Atomic actions |

---

## 🛠️ Tech Stack

| Technology | Version / Notes |
|---|---|
| **Unity** | 2022.3 LTS |
| **C#** | .NET Standard 2.1 |
| **Atomic Framework** | Included as a local package (`Packages/`) |
| **AIModule** | Custom BT runtime (included via Plugins) |
| **Odin Inspector** | Editor tooling |

---

## 🚀 Getting Started

### Prerequisites

- Unity **2022.3** or newer
- Git LFS (for binary assets)

### Setup

```bash
git clone https://github.com/MrRandomise/Behaviour-Tree.git
```

1. Open the cloned folder in **Unity Hub** → *Add project from disk*.
2. Let Unity import all packages and assets.
3. Open the scene: `Assets/Scenes/`.
4. Press **Play** — the AI character will start collecting resources automatically.

---

## 📂 Project Structure (top level)

```
Behaviour-Tree/
├── Assets/          # All game content and scripts
├── Packages/        # Unity package manifest + Atomic framework
├── ProjectSettings/ # Unity editor project settings
└── README.md
```

---

## 📝 Техническое задание / Original Task

> Реализовать поведение добычи ресурсов с помощью Behaviour Tree.
>
> Implement resource-gathering AI behaviour using a Behaviour Tree.
