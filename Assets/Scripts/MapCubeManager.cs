using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCubeManager : MonoBehaviour {
    [HideInInspector]
    public GameObject turret;

    public GameObject buildEffect;

    Renderer renderer;

    public bool isUpGrade = false;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    public void BuildTurret(GameObject turretPrefab)
    {
        turret= GameObject.Instantiate(turretPrefab, transform.position, Quaternion.identity);
        GameObject effect =GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1);
    }
    private void OnMouseEnter()
    {
        if(turret==null && EventSystem.current.IsPointerOverGameObject()==false)
        {
            renderer.material.color = Color.blue;
        }
    }
    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
