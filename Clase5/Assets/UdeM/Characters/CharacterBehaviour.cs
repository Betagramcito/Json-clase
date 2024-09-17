using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdeM.Base;

namespace UdeM.Characters {
    public class CharacterBehaviour : CustomMonoBehaviour
    {
       protected float _moveSpeed;
       protected float _jumpForce;
       [SerializeField] protected bool _isGrounded;
       protected LayerMask _terrainLayer;

        protected override void Awake()
        {
            base.Awake();
            _moveSpeed = 5f;
            _jumpForce = 10f;
            _isGrounded = false;
        }

        protected override void Start()
        {
            base.Start();
            _terrainLayer = LayerMask.GetMask("Terrain");
        }

        protected virtual void Move(){}
        protected virtual void Jump(){}
    }
}
