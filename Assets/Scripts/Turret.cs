using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public float attackRate = 1;
    public float timer = 1;
    public GameObject bullet;
    public GameObject firePosition;
    public Transform head;

    public List<GameObject> enemys=new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Remove(other.gameObject);
        }
    }
    private void Update()
    {
        UpDateEnemy();
        if(enemys.Count>0 && enemys[0] != null)
        {
            Vector3 targetPosition = enemys[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);
        }
        timer += Time.deltaTime;
        if (enemys.Count>0 && timer >= attackRate)
        {
            timer = 0;
            Attack();
        }
    }
    void Attack()
    {
        if (enemys[0] == null)
        {
            UpDateEnemy();
        }
        if (enemys.Count > 0)
        {
            GameObject gunBullet = GameObject.Instantiate(bullet, firePosition.transform.position, Quaternion.identity);
            gunBullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
        }
        else
        {
            timer = 0;
        }
    }
    void UpDateEnemy()
    {
        List<int> emptyIndex = new List<int>();
        for(int index = 0; index < enemys.Count; index++)
        {
            if (enemys[index] == null)
            {
                emptyIndex.Add(index);
            }
        }
        for(int i = 0; i < emptyIndex.Count; i++)
        {
            enemys.RemoveAt(emptyIndex[i]-i);
        }
    }
}
