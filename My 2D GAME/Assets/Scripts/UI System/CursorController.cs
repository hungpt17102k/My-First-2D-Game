using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private void Start()
    {
        // lam con tro mac dinh bi an di
        Cursor.visible = false;
    }

    void Update()
    {
        //lay toa do cua con tro trong man hinh that
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //set sprite to the mouse's position
        transform.position = cursorPos;
    }
}
