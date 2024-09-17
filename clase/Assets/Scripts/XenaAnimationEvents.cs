using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XenaAnimationEvents : MonoBehaviour
{
    public void AttackHitBoxOn()
    {
        GetComponentInParent<XenaBehaviour>().AttackHitBoxOn();
    }
    public void AttackHitBoxOff()
    {
        GetComponentInParent<XenaBehaviour>().AttackHitBoxOff();
    }
}
