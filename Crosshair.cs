using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    [SerializeField]
    Texture2D image;
    [SerializeField]
    int size;
    [SerializeField]
    float maxAngle;
    [SerializeField]
    float minAngle;

    float lookHight;

    public void LookHeight(float value)
    {
        lookHight += value;

        if (lookHight > maxAngle || lookHight < minAngle)
            lookHight -= value;
    }
    private void OnGUI()
    {
        Vector3 screenPositopn = Camera.main.WorldToScreenPoint(transform.position);
        screenPositopn.y = Screen.height - screenPositopn.y;
        GUI.DrawTexture(new Rect(screenPositopn.x, screenPositopn.y - lookHight,size,size),image);
    }
}
