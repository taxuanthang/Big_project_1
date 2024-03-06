using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate_controll : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Finish")){
            Debug.Log("meomeo");
        }
    }
}
