using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateControl : MonoBehaviour
{
    public GameObject Door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Finish")){
            open_door();
        }
    }
    public void open_door()
    {
        Collider2D Door_colli = Door.GetComponent<Collider2D>();
        Door_colli.enabled = false;
        Debug.Log("Open the door");
    }

}
