using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour {

    private void Update()
    {
        this.transform.LookAt(Camera.main.transform);
    }
}
