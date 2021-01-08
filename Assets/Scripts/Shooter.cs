using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public bool autoShoot;
    public float shootCadenceSecs = 1f;

    public float coolingDownSecs = 1f;
    private float auxSecs;


    void Awake()
    {
        coolingDownSecs = Mathf.Abs(coolingDownSecs);
        auxSecs = 0;
    }

    private void Start()
    {
        if (autoShoot) InvokeRepeating("AutoShoot", 3, shootCadenceSecs); //Disparo automatico
    }

    void Update()
    {
        auxSecs -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (auxSecs <= 0)
        {
            Instantiate<GameObject>(bulletPrefab, transform.position, transform.rotation);
            auxSecs = coolingDownSecs;
        }
    }

    public void AutoShoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    //Cancelar todas las invocaciones pendientes 
    private void OnDestroy()
    {
        CancelInvoke();
    }
}
