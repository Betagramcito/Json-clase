using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("velocidad y salto")]
    public float velMovimiento = 5f;
    public float fuerzaJump = 7f;

    [Header("Rigidbody y animator")]
    private Rigidbody2D rb;
    private Animator animator;

    [Header("movimiento y personaje")]
    public float movimientoH;

    [Header("Posición del jugador")]
    public Transform jugadorTransform;

    public bool enElSuelo = false;


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
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoH));

        if(movimientoH> 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movimientoH <0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetButton("Jump")&& enElSuelo)
        {
            animator.SetBool("Jump", true);
            rb.AddForce(new Vector2(0f, fuerzaJump), ForceMode2D.Impulse);
            enElSuelo=false;
        }      
    }

    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = true;
            Debug.Log("Estoy tocando el suelo");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Soy el enemigo");
            //gameObject.SetActive(false);
            PlayerDeath();
        }

    }

    public void PlayerDeath()
    {
        RespawnCheckpoint();
    }

    public void RespawnCheckpoint()
    {
        if (CheckPoint.activeCheckpoint != null)
        {
            float PlayerPosX = PlayerPrefs.GetFloat("PlayerPosX");
            float PlayerPosY = PlayerPrefs.GetFloat("PlayerPosY");
            
            Vector3 respawnPosition = new Vector3(PlayerPosX, PlayerPosY, jugadorTransform.position.z);
            jugadorTransform.position = respawnPosition;
        }
    }
}
