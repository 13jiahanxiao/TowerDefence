﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float speed = 20;
    public float mouseSpeed = 360;
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float m = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(new Vector3(-h*speed,-m*mouseSpeed,-v*speed) * Time.deltaTime,Space.World);
    }
}
