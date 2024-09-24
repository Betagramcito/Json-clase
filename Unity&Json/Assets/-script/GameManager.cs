using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Contador Item")]
    public static GameManager instance;
    public TMP_Text ContadorText;
    public int itemCount = 0;
    
    void Awake ()
    {
        instance = this;
    }
    public void CollectableItem(int value)
    {
         itemCount=value;
        UpdateItemCount();
    }
    void UpdateItemCount()
    {
        ContadorText.text = ":" + itemCount.ToString(); 
    }
}
