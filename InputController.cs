using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public float Vertical;//WS前後
    public float Horizontal;//AD左右
    public Vector2 MouseInput;//滑鼠輸入
    public bool fire1;

     void Update()
    {
        Vertical = Input.GetAxis("Vertical");//getWA
        Horizontal = Input.GetAxis("Horizontal");//getAD
        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        fire1 = Input.GetButton("Fire1");
    }
}
