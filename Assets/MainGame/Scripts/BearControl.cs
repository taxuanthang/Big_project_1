using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearControl : MonoBehaviour
{
    public DialogueTrigger trigger;

    private GameObject Holder;
    private GameObject Fish;
    public void Shine()
    {
        Holder = GameObject.Find("/PF Player/Holder");
        try
        {
            Fish = Holder.transform.Find("Fish").gameObject;
        }
        catch
        {
            trigger.StartDialouge();
        }

        //Debug.Log(Holder);
    }
    public void UnShine()
    {
        Holder = null;
        trigger.EndDialogue();
    }
}
