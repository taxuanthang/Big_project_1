using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class ChestControl : MonoBehaviour
{
    Color curColor;
    Color targetColor;
    private bool isInterracted = false;

    private GameObject Item;
    private GameObject Holder;

    public void Shine()
    {
        Holder = GameObject.Find("/PF Player/Holder");
        Item = this.transform.Find("FishingRod").gameObject;
        //Debug.Log(Holder);
        isInterracted = true;
        curColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        targetColor = new Color(0, 0, 0, 0);
        curColor = Color.Lerp(curColor, targetColor, 3 * Time.deltaTime);
        Debug.Log("Đổi màu Highlight");
    }
    public void UnShine()
    {
        isInterracted = false;
        curColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        targetColor = new Color(0, 0, 0, 0);
        curColor = Color.Lerp(curColor, targetColor, 3 * Time.deltaTime);
        Debug.Log("Về màu ban đầu");
        Holder = null;
    }
    public void TakeObject()
    {
        Item.transform.parent = Holder.transform;
        Item.transform.localPosition = Vector3.zero;
    }
    private void Update()
    {
        if (isInterracted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Item != null)
                {
                    Debug.Log("Taking Object");
                    TakeObject();
                }

            }
        }
    }
}
