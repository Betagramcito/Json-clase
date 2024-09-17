using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdeM.Base;
using UnityEngine.Events;

namespace UdeM.Characters { 

    public class CharacterBehaviour : CustomMonoBehaviour
    {
        protected float _moveSpeed;

        protected string _name;

        protected float _jumpForce;

        protected float _lastHeight;

        [SerializeField] protected float _height;


        [SerializeField] protected bool _isGrounded;

        [SerializeField] protected bool _isFalling;

        protected LayerMask _terrainLayer;

        protected LayerMask _layerPlayer;

        protected UnityEvent _onStartFall;

        protected UnityEvent _onLand;


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
            InitEvents();
            _terrainLayer = LayerMask.GetMask("Terrain");
            _layerPlayer = LayerMask("Player");
            CheckHeight();
            StartCoroutine(UpdateLastHeight());
        
        }  


        private void InitEvents()
        {
            _onStartFall = new UnityEvent();
            _onLand = new UnityEvent();
            _onStartFall.AddListener(OnStartFall);
            _onLand.AddListener(OnLand);
        }

        protected virtual void OnStartFall()
        {
            Debug.Log("The character satrt to fall");
        }

        protected virtual void OnStartFall()
        {
            Debug.Log("The character land");
        }

        protected override void Update()
        {
            base.Update();
            CheckHeight();
            CheckFalling();
        }

      

        protected virtual void Move(){}

        protected virtual void Jump(){}

        protected abstract void CheckHeight();


        private IEnumerator UpdateLastHeight()
        { 
            while(true)
            {
                _lastHeight = _lastHeight;
                yield return new WaitForSeconds(0.5f);
            }
        }

        protected void CheckFalling()
        {
            if(_isGrounded)
            {
                _isFalling = false;
                _lastHeight = _height;
                return;
            }

            if(_lastHeight > _height)
            {
                if (!_isFalling)
                {
                    _onStartFall.Invoke();
                }
            }
            
            _isFalling = true;
            else if (_lastHeight < _height)
            {
                _isFalling = false;
            }
        }


    }
}
