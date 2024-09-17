using System.Collections;
using System.Collections.Generic;
using UdeM.Characters;
using UnityEngine;

public sealed class XenaBehaviour : Character2DPlayerBehaviour
{
    private GameObject _xenaModel;
    private Animator _anim;

    protected override void Start()
    {
        base.Start();
        _xenaModel = transform.Find("XenaModel").gameObject;
        _anim = _xenaModel.GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        _anim.SetBool("isRunning", _axisH != 0);
        _anim.SetBool("isFalling", _isFalling);
        _anim.SetBool("isGrounded", _isGrounded);

        if (Input.GetButtonDown("Fire1") && _isGrounded && _canAction)
        {
            Attack();
        }
    }

    protected override void OnStartFall()
    {
        _anim.SetTrigger("onStartFall");
    }

    protected override void Jump()
    {
        base.Jump();
        _anim.SetTrigger("onJump");
    }

    private void Attack()
    {
        StartCoroutine(StopMoveDueTime(1.2f));
        StartCoroutine(StopActiveDueTime(1.3f));
        _anim.SetTrigger("onAttack");
    }

   // public void AttackColliderOn()
    {
        transform.Find("AttackHitBox").GetComponent<PoligonCollider>.eneable = true;
    }
}
