using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    [SerializeField] Shooter assaultRifle;

     void Update()
    {
        if (GameManager.Instance.InputController.fire1==true)
        {
            assaultRifle.Fire();
        }
    }


}
