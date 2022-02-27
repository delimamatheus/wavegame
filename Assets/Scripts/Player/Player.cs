using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Vector3 dir;
    public Transform spawnpointBullets;
    public PoolManager poolManager;
    public bool canMove = false;
    
    void Update()
    {
        if (!canMove) return;

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(dir * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-dir * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SpawnBullets();
        }
    }

    private void SpawnBullets()
    {
        var obj = poolManager.getListedObject();

        obj.SetActive(true);
        obj.GetComponent<Bullet>().startBullet();
        obj.transform.SetParent(null);
        obj.transform.position = spawnpointBullets.transform.position;
    }
}
