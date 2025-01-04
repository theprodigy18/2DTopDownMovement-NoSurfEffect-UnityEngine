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
          moveInput = context.ReadValue<Vector2>(); // initialize the moveInput with the vector from input
      }

      private void FixedUpdate()
      {
          rb.linearVelocity = moveInput * speed; // update the velocity with FixedUpdate so it will run smooth both on 30fps and 60fps
      }
  }
