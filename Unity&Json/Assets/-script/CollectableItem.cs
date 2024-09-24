using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [Header("Item Sandía")]
    public int value = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Estoy tocando la fruta");
            GameManager.instance.CollectableItem(value);
            Destroy(gameObject);
        }
    }
}
