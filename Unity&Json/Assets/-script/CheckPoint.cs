using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool Activate = false;
    public static ChackPoint activeCheckpoint;

    private void OntriggerEnter2D(Collider2D other)
    {
        if (other. CompareTag("Player")&& !Activate)
        {
            Activate= true;

            activeCheckpoint = this;

            PlayerPrefbs.setFloat("PlayerPosX".other.transform.position.x);
            PlayerPrefbs.setFloat("PlayerPosY".other.transform.position.y);

            PlayerPrefs.Save();
        }
    }
}
