using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LakeControl : MonoBehaviour
{
    Color curColor;
    Color targetColor;
    private bool isInterracted = false;

    public static bool isFished;

    private GameObject Holder;
    private GameObject Fish;
    private GameObject FishingRod;

    public DialogueTrigger trigger;

    public void Shine() 
    {
        Holder = GameObject.Find("/PF Player/Holder");
        try{
            FishingRod = Holder.transform.Find("FishingRod").gameObject;
        }
        catch
        {
            trigger.StartDialouge();
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

        trigger.EndDialogue();


    }

    public void Fishing()
    {
        if (Input.GetKeyDown(KeyCode.E)&& isInterracted)
        {
            Debug.Log("Fishing");
            if (FishingRod != null)
            {
                Navigation.instance.NavigationMiniGameScene();
            }
        }
        if (isFished)
        {
            try
            {
                Fish = GameObject.Find("Lake/Fish");
                Fish.transform.parent = Holder.transform;
                Fish.transform.localPosition = Vector3.zero;
            }
            catch { }
        }
    }
    private void Update()
    {
            Fishing();
    }
}
