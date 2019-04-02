using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {

    public TurretData laser;
    public TurretData turret;
    public TurretData missile;

    TurretData selectTurret;

    GameObject TurretMode;

    public Text moneyText;
    public Animator moneyAnimator;

    public int money = 1000;

    public GameObject upGradeCanvas;
    public Button buttonUpGrade;

    Animator UpGradeCanvasAnimator;
    private void Start()
    {
        moneyText = GameObject.Find("Money").GetComponent<Text>();
        UpGradeCanvasAnimator = upGradeCanvas.GetComponent<Animator>();
    }
    void UpdateMoney(int change)
    {
        money += change;
        moneyText.text =money.ToString();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isColldier = Physics.Raycast( ray,out hit, 1000, LayerMask.GetMask("MapCube"));
                if (isColldier)
                {
                    MapCubeManager mapCube = hit.collider.GetComponent<MapCubeManager>();
                    if (mapCube.turret == null)
                    {
                        if (money >= selectTurret.builtCost)
                        {
                            UpdateMoney(-selectTurret.builtCost);
                            mapCube.BuildTurret(selectTurret.turretPrefab);
                            mapCube.isUpGrade = false;
                        }
                        else
                        {
                            moneyAnimator.SetTrigger("Flicker");
                        }
                    }
                    else if(mapCube.turret!=null)
                    {
                        if (TurretMode == mapCube.turret && upGradeCanvas.activeInHierarchy)
                        {
                            StartCoroutine(HideUpGradeUi());
                        }
                        else
                        {
                            ShowUpGradeUi(mapCube.transform.position, mapCube.isUpGrade);
                        }
                        TurretMode = mapCube.turret;
                    }
                }
            }
        }
    }
    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            selectTurret = laser;
        }
    }
    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectTurret = missile;
        }
    }
    public void OnTurretSelected(bool isOn)
    {
        if (isOn)
        {
            selectTurret = turret;
        }
    }
    void ShowUpGradeUi(Vector3 position, bool isDisableUpGrade=false)
    {
        StopCoroutine("HideUpGradeUi");
        upGradeCanvas.SetActive(false);
        upGradeCanvas.SetActive(true);
        upGradeCanvas.transform.position = new Vector3(position.x,position.y+2.5f,position.z);
        buttonUpGrade.interactable = !isDisableUpGrade;
    }
    IEnumerator HideUpGradeUi()
    {
        UpGradeCanvasAnimator.SetTrigger("Trigger");
        yield return new WaitForSeconds(0.8f);
        upGradeCanvas.SetActive(false);
    }
    public void OnUpGradeButtonDown()
    {

    }
    public void OnDIsableButtonDown()
    {

    }
}
