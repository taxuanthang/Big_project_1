using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public void StartDialouge()
    {
 /*       Debug.Log("xin chao");*/
        Object.FindObjectOfType<Dialogue>().OpenDialogue(messages, actors);
    }
    public void EndDialogue()
    {
        Object.FindObjectOfType<Dialogue>().CloseDialogue();
    }
}

[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}
