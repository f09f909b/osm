using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] InputMaster _controls;
   [SerializeField] private Rigidbody2D _rb;
   [SerializeField] private float _speed;
   [SerializeField] private float _jumpStrength;
   private Vector2 _movementInput;
   private bool _isGrounded;
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
      _rb.velocity = _movementInput * _speed;
   }
   private void Jump()
   {
      Debug.Log("I am now jumping Mike!");
      _rb.AddForce(Vector2.up * _jumpStrength);
   }
   private void Strike()
   {
      Debug.Log("I am one strike mike!");
   }
}
