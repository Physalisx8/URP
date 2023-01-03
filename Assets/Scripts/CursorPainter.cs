using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPainter : MonoBehaviour
{
    [SerializeField] Texture2D cursorDefault;
    [SerializeField] Texture2D cursorZoomIn;
    [SerializeField] Texture2D cursorInteract;
    [SerializeField] Texture2D cursorZoomOut;

    void Awake(){
        Default();
    }

    public void Default(){
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
        Debug.Log("Default");
    }
    public void Zoom(){
        Cursor.SetCursor(cursorZoomIn, Vector2.zero, CursorMode.Auto);
         Debug.Log("Zoom");
    }
    public void Interact(){
        Cursor.SetCursor(cursorInteract, Vector2.zero, CursorMode.Auto);
    }

    public void ZoomOut(){
        Cursor.SetCursor(cursorZoomOut, Vector2.zero, CursorMode.Auto);
    }
}
