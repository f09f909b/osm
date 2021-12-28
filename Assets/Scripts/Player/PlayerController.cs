using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   [SerializeField] InputMaster _controls;
   [SerializeField] private Rigidbody2D _rb;
   [SerializeField] private Transform groundCheck;
   [SerializeField] private LayerMask groundLayer;
   
   [SerializeField] private float _speed;
   [SerializeField] private float _jumpStrength;
   private Vector2 _movementInput;
   
   private bool _hasJumped;


   private void Awake()
   {
      _rb = gameObject.GetComponent<Rigidbody2D>(); 
      _controls = new InputMaster();
   }

   private void Start()
   {
      _controls.Player.Movement.performed += _ => Movement();
      _controls.Player.Jump.performed += _ => Jump();
      _controls.Player.Strike.performed += _ => Strike();
   }

   private void FixedUpdate()
   {
      Movement();
   }

   private void OnEnable()
   {
      _controls.Enable(); 
   }

   private void OnDisable()
   {
      _controls.Disable();
   }
   private void Movement()
   {
      _movementInput = _controls.Player.Movement.ReadValue<Vector2>();
      _rb.velocity = new Vector2(_movementInput.x * _speed, _rb.velocity.y);
   }
   private void Jump()
   {
      if (IsGrounded())
      {
         _rb.AddForce(new Vector2(_rb.velocity.x,_jumpStrength));
      }
   }

   private bool IsGrounded()
   {
      return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
   }

   private void Strike()
   {
      Debug.Log("I am one strike mike!");
   }
}
