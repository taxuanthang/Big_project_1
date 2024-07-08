using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public DialogueTrigger trigger;

    public void Shine()
    {
        try
        {
            trigger.StartDialouge();
        }
        catch { }
    }
    public void UnShine()
    {
        try
        {
            trigger.EndDialogue();
        }
        catch { }
    }
}
