using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {
    //寻路点

    public static Transform[] wayPointPosition;
    private void Awake()
    {
        wayPointPosition = new Transform[this.transform.childCount];
        for(int i = 0; i < wayPointPosition.Length; i++)
        {
            wayPointPosition[i] = this.transform.GetChild(i);
        }
    }
}
