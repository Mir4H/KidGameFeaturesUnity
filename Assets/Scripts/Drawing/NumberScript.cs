using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows.Speech;

public class NumberScript : MonoBehaviour
{
    public static bool CanDraw = false;

    private void OnMouseOver()
    {
        CanDraw = true;
    }

    private void OnMouseExit()
    {
        CanDraw = false;
    }
}
