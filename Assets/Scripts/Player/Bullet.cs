using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 dir;
    public Rigidbody rb;
    public float destroyTime = 2f;

    public void finishBullet()
    {
        gameObject.SetActive(false);
    }

    public void startBullet()
    {
        Invoke(nameof(finishBullet), destroyTime);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.velocity = Vector3.zero;
    }

    void Update()
    {
        rb.MovePosition(transform.position + dir * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
        finishBullet();
        Destroy(collision.gameObject);
        }
    }
}
