using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TurretControl : MonoBehaviour
{
    private Transform _player;
    private float _dist;
    [SerializeField] private float maxDistance;
    [SerializeField] private Transform head;
    [SerializeField] private Transform barrel;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float fireRate, nextFire;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    
    void Update()
    {
        _dist = Vector3.Distance(_player.position, transform.position);
        if (_dist <= maxDistance)
        {
            head.LookAt(_player);
            if (Time.time >= nextFire)
            {
                nextFire = Time.time + 1f/fireRate;
                Shoot();
            }
          
        }
    }

    void Shoot()
    {
       GameObject clone = Instantiate(projectile, barrel.position, barrel.rotation);
       clone.GetComponent<Rigidbody>().AddForce(barrel.forward * 1500);
       Destroy(clone, 5);
    }
}
