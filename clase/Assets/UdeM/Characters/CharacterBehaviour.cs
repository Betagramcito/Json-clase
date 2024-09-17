using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdeM.Base;
using UnityEngine.Events;

namespace UdeM.Characters {
    public abstract class CharacterBehaviour : CustomMonoBehaviour
    {
       protected float _moveSpeed;
       protected float _jumpForce;
       protected float _latHeight;
       [SerializeField] protected float _height;
       [SerializeField] protected bool _isGrounded;
       [SerializeField] protected bool _isFalling;
       [SerializeField] protected bool _canMove;
       [SerializeField] protected bool _canAction;
       protected LayerMask _terrainLayer;
       protected LayerMask _playerLayer;
       protected UnityEvent _onStartFalling;
       protected UnityEvent _onLand;

       protected override void Awake()
       {
            base.Awake();
            _moveSpeed = 5f;
            _jumpForce = 10f;
            _isGrounded = false;
            _canAction = true;
            _canMove = true;

       }

        protected override void Start()
        {
            base.Start();
            InitEvent();
            _terrainLayer = LayerMask.GetMask("Terrain");
            _playerLayer = LayerMask.GetMask("Player");
            CheckHeight();
            StartCoroutine(UpdateLastHeight());
        }

        private void InitEvent()
        {
            _onStartFalling = new UnityEvent();
            _onLand = new UnityEvent();
            _onStartFalling.AddListener(OnStartFalling);
            _onLand.AddListener(OnLand);    
        }

        protected override void Update()
        {
            base.Update();
            CheckHeight();
            CheckFalling();
        }

        protected virtual void OnStartFalling()
        {
            Debug.Log("The character start falling");
        }

        protected virtual void OnLand()
        {
            Debug.Log("The character landed");
        }

        protected virtual void Move(){}
        protected virtual void Jump(){}

        protected abstract void CheckHeight();

        protected void CheckFalling()
        {
            if(_isGrounded)
            {
                if(_isFalling)
                {
                    _onLand.Invoke();
                }
                _isFalling = false;
                _latHeight = _height;
                return;
            }
            if(_latHeight > _height)
            {
                if (!_isFalling)
                {
                    _onStartFalling.Invoke();
                }

                _isFalling = true;
            }
            else if(_latHeight < _height)
            {
                _isFalling = false;
            }
        }

        private IEnumerator UpdateLastHeight()
        {
            while(true)
            {
                _latHeight = _height;
                yield return new WaitForSeconds(0.5f);
            }
        }

        protected IEnumerator StopMoveDueTime(float time)
        {
            _canMove = false;
            yield return new WaitForSeconds(time);
            _canMove = true;
        }
        protected IEnumerator StopActionDueTime(float time)
        {
            _canAction = false;
            yield return new WaitForSeconds(time);
            _canAction = true;
        }
    }
}
