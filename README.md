# Solving Movement Issues in 2D Top-Down Games

![Banner Image](https://via.placeholder.com/800x200?text=2D+Top-Down+Movement+Solution)

Have you experienced issues with 2D top-down movement, such as a lingering surf effect when the input stops? These problems can ruin the fluidity of your game, creating an unnatural player experience. Fear not, as I have the perfect solution to address this problem using Unity's new Input System!

## About This Repository
This repository is dedicated to helping developers resolve common 2D movement issues in top-down games, particularly the "surf effect" where the character continues to drift after the input has stopped. By implementing Unity's Input System and a few smart tweaks, we can achieve precise, responsive movement that feels natural.

### Key Features
- **Smooth and Instant Input Response**: Eliminate unwanted drift and ensure the character stops immediately when the input is released.
- **Customizable Input Actions**: Leverage Unity's new Input System to define actions tailored to your game.
- **Beginner-Friendly**: Clear and concise explanations with step-by-step implementation guides.

![Preview of Smooth Movement](https://via.placeholder.com/600x400?text=Smooth+Movement+Preview)

## How It Works
The core of this solution involves utilizing Unity's Input Action system to separate input detection from physics-based movement. This method ensures that:
1. Input is captured and processed in real-time.
2. Movement behavior is decoupled from frame rate, preventing unwanted lag or "surfing" effects.
3. Fine-tuning is possible for acceleration and deceleration to fit your game style.

## Getting Started
To use this solution in your project, follow these steps:

1. **Install Unity's New Input System**:
   - Open your Unity project.
   - Go to `Window` > `Package Manager`.
   - Search for `Input System` and install it.
   - Follow the prompts to enable the new Input System (you may need to restart Unity).

2. **Create Input Actions**:
   - Create an Input Action Asset by right-clicking in the Project window and selecting `Create > Input Actions`.
   - Open the Input Action editor and define a new action named `Move`.
   - Set the action type to `Value` and the control type to `Vector2` and normalized.
   - Assign bindings for keyboard (e.g., WASD or arrow keys) and/or joystick.
   - Save the asset and generate the C# files from it.

   ![Input Action Setup](https://via.placeholder.com/600x300?text=Input+Action+Setup)


3. **Update Your Player Controller Script**:
   Here is an updated script to demonstrate how Input Action is used:

```csharp
  using System;
  using UnityEngine;
  using UnityEngine.InputSystem;

  [RequireComponent(typeof(Rigidbody2D))]
  public class PlayerController : MonoBehaviour
  {
      private PlayerInputActions inputActions; // the input action
      public Vector2 moveInput; // vector that will held the input from user
      private Rigidbody2D rb; // use rigidbody to move your character instead of moving it by change the transform with deltaTime
      public float speed = 5f; // adjust your speed
  
      private void Awake()
      {
          inputActions = new PlayerInputActions(); // initialize it with new input action
          rb = GetComponent<Rigidbody2D>(); // get the rigidbody component from the same object that this script is attach on
      }
  
      private void OnEnable()
      {
          inputActions.Player.Enable(); // enable the input action
          inputActions.Player.Move.performed += OnMove; // note that input action will always updated when the input is clicked without using update function
          inputActions.Player.Move.canceled += OnMove;  // you just need to enable it on the OnEnable
      }
      private void OnDisable()
      {
          inputActions.Player.Move.performed -= OnMove;
          inputActions.Player.Move.canceled -= OnMove;
          inputActions.Player.Disable(); // disable input action if this game object is disabled
      }
  
      private void OnMove(InputAction.CallbackContext context)
      {
          moveInput = context.ReadValue<Vector2>(); initialize the moveInput with the vector from input
      }

      private void FixedUpdate()
      {
          rb.linearVelocity = moveInput * speed; update the velocity with FixedUpdate so it will run smooth both on 30fps and 60fps
      }
  }
```

4. **Test and Adjust**:
   - Play your game and ensure that movement feels responsive and consistent in all directions.
   - Adjust `moveSpeed` to find the optimal speed for your game.

---

Let's make your 2D top-down game movement feel seamless and professional! 🚀

