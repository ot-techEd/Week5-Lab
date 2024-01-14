using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHouse : MonoBehaviour
{
    [SerializeField] private GameObject[] house;
    [SerializeField] private float spawnTime = 5.0f;

    private bool isBuilding = false;


    public void StartBuild()
    {
        StartCoroutine(Build());
    }

    public IEnumerator Build()
    {
        if (isBuilding) { yield return null; } //Guard clause

        isBuilding = true;
        for (int i = 0; i < house.Length; i++)
        {
            if (i > 0)
                house[i-1].SetActive(false);

            house[i].SetActive(true);
            SetSpawnTime();

            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void SetSpawnTime()
    {
        if (house.Length < 5)
        {
            spawnTime *= 2;
        }
        else
        {
            spawnTime += 5;
        }

    }

}
