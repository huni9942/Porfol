using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // ** ΩÃ±€≈Ê ¿ŒΩ∫≈œΩ∫ ª˝º∫
    public static BuildManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    // ** ±‚∫ª ≈Õ∑ø «¡∏Æ∆È
    public GameObject standardTurretPrefab;

    public GameObject MissileLauncherPrefab;

    // ** ∫ÙµÂ«“ ≈Õ∑ø
    private GameObject turretToBuild;
    
    // ** ∫ÙµÂ«“ ≈Õ∑ø π›»Ø
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    // ** ∫ÙµÂ«“ ≈Õ∑ø ºº∆√
    public void SetTurretToBuild ( GameObject turret)
    {
        turretToBuild = turret;
    }
}
