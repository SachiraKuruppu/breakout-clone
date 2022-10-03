using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigidBody;
    void Start()
    {
        Cursor.visible = false;
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var mousePosition = new Vector3(Input.mousePosition.x, 0, 50);
        var worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        GetComponent<Rigidbody>().MovePosition(new Vector3(worldPosition.x, -17, 0));
    }
}
