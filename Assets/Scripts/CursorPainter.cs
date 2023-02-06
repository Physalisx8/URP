using UnityEngine;

public class CursorPainter : MonoBehaviour
{
    [SerializeField] Texture2D cursorDefault;
    [SerializeField] Texture2D cursorZoomIn;
    [SerializeField] Texture2D cursorInteract;


    void Awake(){
        Default();
    }

    public void Default(){
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
    }
    public void Zoom(){
        Cursor.SetCursor(cursorZoomIn, Vector2.zero, CursorMode.Auto);
    }
    public void Interact(){
        Cursor.SetCursor(cursorInteract, Vector2.zero, CursorMode.Auto);
    }

    //zoom out brauchen wir nicht, weil wir ja mit rechtsklick rausgehen und da ne UI drunter ballern
}
