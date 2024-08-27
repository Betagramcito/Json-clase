using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("velocidad y salto")]
    public float velMovimiento = 5f;
    public float fuerzaSalto = 7f;

    [Header("Rigidbody y animator")]
    private Rigidbody2D rb;
    private Animator animator;

    [Header("movimiento y personaje")]
    public float movimientoH;

    [Header("Posición del jugador")]
    public Transform jugadorTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (rb == null)
        {
            Debug.Log("No se encontró componente RigidBody 2D" + gameObject.name);
        }
        if(animator == null)
        {
            Debug.Log("No se encontró componente de animación del objeto" + gameObject.name);
        }
    }

    void Update()
    {
        movimientoH = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimientoH*velMovimiento, rb.velocity.y);
        //animator.setFloat("Horizontal", Mathf.Abs(movimientoH));

        if(movimientoH> 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movimientoH <0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
