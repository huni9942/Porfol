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
    private void Start()
    {
        // ** ∫ÙµÂ«“ ≈Õ∑ø¿ª ±‚∫ª ≈Õ∑ø¿∏∑Œ ¡ˆ¡§
        turretToBuild = standardTurretPrefab;
    }

    // ** ∫ÙµÂ«“ ≈Õ∑ø
    private GameObject turretToBuild;
    
    // ** ∫ÙµÂ«“ ≈Õ∑ø π›»Ø
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
