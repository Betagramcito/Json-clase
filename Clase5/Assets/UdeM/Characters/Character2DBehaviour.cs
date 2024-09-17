using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdeM.Characters 
{
    public class Character2DBehaviour : CharacterBehaviour
    {
        protected Rigidbody2D _rb;
        protected float _radiusOverlap;

        protected override void Awake()
        {
            base.Awake();
            _radiusOverlap = 0.2f;
        }

        protected override void Start()
        {
            base.Start();
            _rb = GetComponent<Rigidbody2D>();
            if(_rb == null) {
                Debug.LogError("The character2D object must contain a RigidBody2D component");
            }
            _rb.freezeRotation = true;
        }

        protected override void Update()
        {
            base.Update();
            Flip();
            CheckGrounded();
        }

        protected virtual void CheckGrounded() 
        {
            _isGrounded = Physics2D.OverlapCircle(transform.position, _radiusOverlap, _terrainLayer) != null;
        }

        protected virtual void Flip() {}
    }
}