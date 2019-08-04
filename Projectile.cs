using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField]
    float Speed;
    [SerializeField]
    float timeToLive;
    [SerializeField]
    float damage;
    private float _timer;
    private Transform _myTrasform;

    public Transform muzzle;
    private void Awake()
    {
        muzzle = transform.Find("muzzle");

    }
    private void OnEnable()//確認時間
    {
        _timer = Time.time;

    }
    void Start () {
        //Destroy(gameObject, timeToLive);
        _myTrasform = transform;
    }
	void Update () {
        if (Time.time > _timer + timeToLive)
        {
            GameObject.Find("ObjectPool").GetComponent<ObjectPool>().Recovery(gameObject);

        }
        _myTrasform.Translate(_myTrasform.forward * Speed * Time.deltaTime);
	}
    private void OnTriggerEnter(Collider other)
    {
        //print("Hit" + other.name);
        var destrutable = other.transform.GetComponent<Destructable>();
        if (destrutable == null)
            return;

        destrutable.TakeDamage(damage);
    }
}
