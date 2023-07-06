using UnityEngine;
using UnityEngine.Events;

public class LineCollider : MonoBehaviour
{
    public static event UnityAction<string> ShowText;
    public static event UnityAction TryAgain;
    public static bool CanDrawOut = false;

    void Update()
    {
        Debug.Log(NumberScript.CanDraw);
        if(Input.GetMouseButtonDown(0) && NumberScript.CanDraw)
        {
            Time.timeScale = 1f;
            CanDrawOut = true;
        } 
    }

    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("checkpoint").Length == 0)
        {
            ShowText?.Invoke("Yay! You drew it!");
            Time.timeScale = 0;
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
            CanDrawOut = false;
            TryAgain?.Invoke();
            ShowText?.Invoke("Stay inside the number!");
        }
    }
}
