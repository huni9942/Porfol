using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public bool selectTurret;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        selectTurret = false;
    }

    public void selectSpawner(TowerSpawner turret)
    {
        buildManager.SelectTurret(turret);
        turret.rend.material.color = Color.blue;
        selectTurret = true;
    }
}
