using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    public float textSpeed;

    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActor;
    int activeMessages = 0;

    private bool isActive= false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        messageText.text = string.Empty;
        currentActor = actors;
        currentMessages = messages;
/*        Debug.Log(currentMessages[0].message);*/
        activeMessages = 0;
        isActive = true;

/*        Debug.Log("Started conversation! Loaded messages" + messages.Length);*/
        StartCoroutine(DisplayMessage());
        backgroundBox.LeanScale(Vector3.one, 0.5f);
    }

    public void CloseDialogue() 
    {
        isActive = false;
        currentMessages = null;
        currentActor = null;
        backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
    }
    private void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive == true)
        {
            if (messageText.text == currentMessages[activeMessages].message) //nếu hiện hết rồi thì qua câu sau
            {
                NextMessage();
            }
            else //không thì hiện full câu
            {
                StopAllCoroutines();
                messageText.text = currentMessages[activeMessages].message; 
            }
        }
    }

    IEnumerator DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessages];

        Actor actorToDisplay = currentActor[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        foreach(char c in messageToDisplay.message.ToCharArray())
        {
            if (isActive)
            {
/*                Debug.Log(c);*/
                messageText.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
            else
            {
                break;
            }
        }
    }
    void NextMessage()
    {

        if (activeMessages < currentMessages.Length - 1)
        {
            activeMessages++;
            messageText.text = string.Empty;
            StartCoroutine (DisplayMessage());
        }
        else
        {
            CloseDialogue();
/*            gameObject.SetActive(false);*/
        }
    }
}
