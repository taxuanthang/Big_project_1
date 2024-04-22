using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BowlControl : MonoBehaviour
{
    Color curColor;
    Color targetColor;
    private bool isInterracted = false;
    public GameObject Bear;
    private GameObject Fish;

    public float speed = 1000000000000.0f;
    // Start is called before the first frame update
    public void Shine()
    {
        Fish = GameObject.Find("/PF Player/Holder/Fish");
        Debug.Log(Fish);
        isInterracted = true;
        curColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        targetColor = new Color(0, 0, 0, 0);
        curColor = Color.Lerp(curColor, targetColor, 3 * Time.deltaTime);
        Debug.Log("Đổi màu Highlight");
    }
    public void Unshine()
    {
        isInterracted = false;
        curColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        targetColor = new Color(0, 0, 0, 0);
        curColor = Color.Lerp(curColor, targetColor, 3 * Time.deltaTime);
        Debug.Log("Về màu ban đầu");
    }
    public void call_bear()
    {

        Rigidbody2D Bearri = Bear.GetComponent<Rigidbody2D>();
        var dist = Vector3.Distance(this.gameObject.transform.position, Bear.transform.position);

        Fish.transform.parent = this.transform;
        Fish.transform.localPosition = Vector3.zero;

        //Debug.Log(dist);
        if (dist!=0)
        {
            Bearri.velocity = (this.gameObject.transform.position - Bear.transform.position).normalized;
            Bearri.AddForce(Bearri.velocity);
        }
        else
        {
            Debug.Log("dung");
            Bearri.velocity = Vector3.zero;
            Bearri.AddForce(Bearri.velocity);
        }
        //Bearri.AddForce(Bearri.velocity);
    }
    private void Update()
    {
        if (isInterracted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Fish != null) 
                {
                    Debug.Log("call Bear");
                    InvokeRepeating("call_bear", 1f, 1f);
                }
              
            }
        }
    }

}
