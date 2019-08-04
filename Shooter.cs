using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField]
    float rateOfFire;
    [SerializeField]
    float nextFireAllowed;
    [SerializeField]
    Projectile projectile;

    public ObjectPool pool;
    bolletController bollet;

    //[HideInInspector]
    public Transform muzzle;

    public bool canFire;

    private void Awake()
    {
        //muzzle = transform.Find("muzzle");

    }
    public virtual void Fire()
    {
        
        canFire = false;
        if (Time.time < nextFireAllowed)
            return;

        nextFireAllowed = Time.time + rateOfFire;

        pool.ReUse(muzzle.position,muzzle.rotation);//按下射出
        //Instantiate(projectile, muzzle.position, muzzle.rotation);
        print("firing" + Time.time);
        canFire = true;

    }


}
