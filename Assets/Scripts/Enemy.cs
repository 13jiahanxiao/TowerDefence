using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    float health = 100;
    float maxHealth = 100;

    Slider hp;

    public GameObject dieEffect;

    public float moveSpeed = 2;
    Transform[] wayPointPosition;
    int index = 0;
	void Start () {
        hp = GetComponentInChildren<Slider>();
        hp.value = health / maxHealth;
        wayPointPosition = WayPoint.wayPointPosition;
	}
	
	void Update () {
        Move();
        BeAttack();
	}

    void Move()
    {
        if (index > (wayPointPosition.Length - 1))
        {
            Die();
            return;
        }
        transform.Translate((wayPointPosition[index].position - transform.position).normalized *Time.deltaTime*moveSpeed);
        if (Vector3.Distance(wayPointPosition[index].position, transform.position) < 0.1f)
            index++;
    }
    void ReachDestination()
    {
        GameObject.Destroy(this.gameObject);
    }
    void EnemyDestory()
    {
        EnemyBring.enemyAliveCounts--;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    void Die()
    {
        EnemyDestory();
        ReachDestination();
    }
    void BeAttack()
    {
        hp.value = health / maxHealth;
        if (health <= 0)
        {
            GameObject effect = GameObject.Instantiate(dieEffect, this.transform.position, Quaternion.identity);
            Destroy(effect, 1.5f);
            Die();
        }
    }
}
