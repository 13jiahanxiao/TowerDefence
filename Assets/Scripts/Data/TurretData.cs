using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretData  {
    public GameObject turretPrefab;
    public int builtCost;
    public GameObject upPrefab;
    public int upCost;
    public TurretType type;
}
public enum TurretType{
    Turret,
    Laser,
    Missile
}
