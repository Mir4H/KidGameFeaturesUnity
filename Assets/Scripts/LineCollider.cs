using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LineCollider : MonoBehaviour
{
    public static event UnityAction<string> ShowText;
    public static event UnityAction TryAgain;

    void Start()
    {
    }

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("checkpoint").Length == 0)
        {
            Debug.Log("good job");
            ShowText?.Invoke("Yay! You drew it!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "checkpoint")
        {
            Destroy(collision.gameObject);
            Debug.Log("reached checkpoint");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "number" && GameObject.FindGameObjectsWithTag("checkpoint").Length != 0)
        {
            TryAgain?.Invoke();
            ShowText?.Invoke("Stay inside the number, try again!");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "number")
        {
            ShowText?.Invoke("Looking Good!");
        }
    }
}
