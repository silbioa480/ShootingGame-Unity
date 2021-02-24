using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePosition;
    public int poolSize = 20;
    public List<GameObject> bulletObjectPool;
    void Start()
    {
        bulletObjectPool = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bulletObjectPool.Add(bullet);
            bullet.SetActive(false);
        }

        #if UNITY_ANDROID
            GameObject.Find("Joystick canvas XYBZ").SetActive(true);
        #elif UNITY_EDITOR || UNITY_STANDALONE
            GameObject.Find("Joystick canvas XYBZ").SetActive(false);
        #endif
    }

    float lastStep, timeBetweenSteps = 0.15f;
    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR || UNITY_STANDALONE
        if(Input.GetButton("Fire1"))
        {
            Fire1();
        }
        #endif
    }

    public void Fire1() {
        if(Time.time - lastStep > timeBetweenSteps)
        {
            lastStep = Time.time;
            if(bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool[0];
                if(bullet.activeSelf == false)
                {
                    bullet.SetActive(true);
                    bulletObjectPool.Remove(bullet);
                    bullet.transform.position = firePosition.transform.position;
                }
            }
        }
    }

    public void Fire2()
    {
        if(Input.GetButton("Fire1"))
        {
            if(Time.time - lastStep > timeBetweenSteps)
        {
            lastStep = Time.time;
            if(bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool[0];
                if(bullet.activeSelf == false)
                {
                    bullet.SetActive(true);
                    bulletObjectPool.Remove(bullet);
                    bullet.transform.position = firePosition.transform.position;
                }
            }
        }
        }
    }
}
