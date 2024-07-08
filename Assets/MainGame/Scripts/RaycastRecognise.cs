using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastRecognise : MonoBehaviour
{
    GameObject Bowl;
    GameObject Lake;
    GameObject Chest;
    GameObject Bear;
    GameObject Crate;
    GameObject Board;

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
        else if (collision.gameObject.CompareTag("Bear"))
        {
            Bear = collision.gameObject;
            Bear.GetComponent<BearControl>().Shine();
        }
        else if (collision.gameObject.CompareTag("Target"))
        {
            Crate = collision.gameObject;
            Crate.GetComponent<CrateControl>().Shine();
        }
        else if (collision.gameObject.CompareTag("Board"))
        {
            Board = collision.gameObject;
            Board.GetComponent<Board>().Shine();
        }
        else if (collision.gameObject.CompareTag("Door")&& TopDownCharacterController.isFinished)
        {
            SceneManager.LoadScene("EndScene");
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
        else if (collision.gameObject.CompareTag("Bear"))
        {
            Bear.GetComponent<BearControl>().UnShine();
            Bear = null;
        }
        else if (collision.gameObject.CompareTag("Target"))
        {
            Crate.GetComponent<CrateControl>().UnShine();
            Crate = null;
        }
        else if (collision.gameObject.CompareTag("Board"))
        {
            Board.GetComponent<Board>().UnShine();
            Board = null;
        }
    }

}
