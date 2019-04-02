using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage;
    public int speed=10;
    Transform target;
    public GameObject explosionEffect;
	
    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }
    private void Update()
    {
        try
        {
            transform.LookAt(target.position);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        catch
        {
            Destroy(this. gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(20);
            GameObject effect= GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(effect);
            Destroy(this.gameObject);
        }
    }
}
