using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool Activate = false;
    public static CheckPoint activeCheckpoint;


    private void OntriggerEnter2D(Collider2D other)
    {
        if (other. CompareTag("Player")&& !Activate)
        {
            Activate= true;

            activeCheckpoint = this;

            PlayerPrefs.SetFloat("PlayerPosX",other.transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY",other.transform.position.y);

            PlayerPrefs.Save();
        }
    }
}
