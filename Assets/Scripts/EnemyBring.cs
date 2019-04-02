using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBring : MonoBehaviour {
    //敌人的生成，一波几个，多少秒一个，多少秒一波

    public static int enemyAliveCounts=0;
	public Wave[] waves;
    public Transform start;
    int waveRat=3;

    private void Start()
    {
        StartCoroutine(spawnEnemy());
    }
    IEnumerator spawnEnemy()
    {
        foreach(Wave wave in waves)
        {
            for(int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.enemyPrefab, start.transform.position,Quaternion.identity);
                enemyAliveCounts++;
                if(i!=(wave.count-1))
                    yield return new WaitForSeconds(wave.rats);
            }
            while (enemyAliveCounts > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waveRat);
        }
    }
}
