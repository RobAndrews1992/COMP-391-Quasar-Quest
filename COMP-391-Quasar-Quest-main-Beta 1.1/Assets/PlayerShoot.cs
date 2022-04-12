using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shootSpeed, shootTimer;

    private bool isShooting;
    
    public Transform shootpos;
    public GameObject laser;
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            StartCoroutine(Shoot());
        }  
    }

    IEnumerator Shoot()
    {
        isShooting = true;
        Debug.Log("Shoot");
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
}
