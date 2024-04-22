using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class LakeControl : MonoBehaviour
{
    Color curColor;
    Color targetColor;
    private bool isInterracted = false;

    private GameObject Holder;
    private GameObject Fish;
    private GameObject FishingRod;

    public void Shine() 
    {
        Holder = GameObject.Find("/PF Player/Holder");
        try{
            FishingRod = Holder.transform.Find("FishingRod").gameObject;
        }
        catch
        {
        }

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

    public void Fishing()
    {
        Fish = GameObject.Find("Lake/Fish");
        Fish.transform.parent = Holder.transform;
        Fish.transform.localPosition = Vector3.zero;
    }
    private void Update()
    {
        if (isInterracted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (FishingRod != null)
                {
                    Debug.Log("Fishing");
                    Fishing();
                }

            }
        }
    }
}
