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
        _anim.SetBool("isRuning", _axisH != 0);
    }
}
