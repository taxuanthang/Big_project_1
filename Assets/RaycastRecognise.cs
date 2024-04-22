using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastRecognise : MonoBehaviour
{
    GameObject Bowl;
    GameObject Lake;
    GameObject Chest;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bowl"))
        {
            Bowl = collision.gameObject;
            Bowl.GetComponent<BowlControl>().Shine();
        }
        else if (collision.gameObject.CompareTag("Lake"))
        {
            Lake = collision.gameObject;
            Lake.GetComponent<LakeControl>().Shine();
        }
        else if (collision.gameObject.CompareTag("Chest"))
        {
            Chest = collision.gameObject;
            Chest.GetComponent<ChestControl>().Shine();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bowl"))
        {
            Bowl.GetComponent<BowlControl>().Unshine();
            Bowl = null;
        }
        else if (collision.gameObject.CompareTag("Lake"))
        {
            Lake.GetComponent<LakeControl>().UnShine();
            Lake = null;
        }
        else if (collision.gameObject.CompareTag("Chest"))
        {
            Chest.GetComponent<ChestControl>().UnShine();
            Chest = null;
        }
    }

}
