using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    public bool condition;
    public int maxHealth = 10;
    public int playerHealth = 5;

    public GameObject[] cubePrefabs;
    public int gridLength = 100;
    private int gridCenter;
    int randomIndex;
    [SerializeField]private MovePlayer mp;
    // Start is called before the first frame update
    void Start()
    {
        mp.Test();
        gridCenter = gridLength / 2;
        for (int x = 0; x < gridLength; x++)
        {   
            for (int z = 0; z < gridLength; z++)
            {
                if (IsEdge(x,z) /*|| IsCenter(x,z)*/)
                {
                    Instantiate(cubePrefabs[Random.Range(0, cubePrefabs.Length)],
                        new Vector3(x, 0, z), Quaternion.identity);

                }

                //SpawnCubeLayers(x, z);
                

            }
        }
        StartCoroutine(StackPyramid());

    }
    private bool IsEdge(int x, int z)
    {
        return x == 0 || x == gridLength-1 || z == 0 || z == gridLength-1;
    }

    private bool IsCenter(int x, int z)
    {
        return x == gridCenter && z == gridCenter;
    }

    public void SpawnCubeLayers(int x, int z, int height = 8)
    {
        for (int h = height; h >= 0; h--)
        {
            for (int i = h; i > 0; i--)
            {
                if (x >= gridCenter - i && x <= gridCenter + i && z >= gridCenter - i && z <= gridCenter + i)
                {
                    Instantiate(cubePrefabs[Random.Range(0, cubePrefabs.Length)],
                        new Vector3(x, height - h, z), Quaternion.identity);
                }
            }
        }


    }
    private void SpawnCubes(int x, int z)
    {
        if (z % 2 == 0 && x % 2 == 0)
        {
            Instantiate(cubePrefabs[0], new Vector3(x, 0, z), Quaternion.identity);
        }
        else if (x % 2 != 0 && z % 2 != 0)
        {
            Instantiate(cubePrefabs[1], new Vector3(x, 0, z), Quaternion.identity);
        }
        else
        {
            Instantiate(cubePrefabs[2], new Vector3(x, 0, z), Quaternion.identity);
        }
    }

    private void SpawnCubesAtRandom(int x, int z)
    {
        if (Random.value > 0.7)
        {
            Instantiate(cubePrefabs[Random.Range(0, cubePrefabs.Length)],
                new Vector3(x, 0, z), Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UseWhileLoop()
    {
        while (maxHealth < 5)
        {
            Debug.Log("While Loop is ongoing");
            maxHealth++;
        }
    }

    private void UseDoWhileLoop()
    {
        do
        {
            Debug.Log("Doing Something Before While Loop Starts");
            maxHealth++;
        } while (maxHealth < 5);
    }

    private void RegenPlayerHealth()
    {
        while (playerHealth < maxHealth)
        {

            playerHealth++;
        }
    }

    private IEnumerator StackPyramid()
    {
        // Generate a pyramid made of stacked cubes using the borderCubePrefabs array
        int pyramidHeight = 8;

        for (int y = pyramidHeight - 1; y >= 0; y--)
        {
            // Loop through each row of the current layer (x-axis)
            for (int x = gridCenter - y; x <= gridCenter + y; x++)
            {
                // Loop through each column of the current layer (z-axis)
                for (int z = gridCenter - y; z <= gridCenter + y; z++)
                {
                    // Randomly choose an index from the borderCubePrefabs array
                    randomIndex = Random.Range(0, cubePrefabs.Length);

                    // Calculate the position of the current cube in the pyramid
                    // The x and z values are adjusted based on the current layer to create a pyramid shape
                    // The y value represents the height of the current layer
                    Vector3 cubePosition = new Vector3(x, pyramidHeight - 1 - y, z);

                    // Instantiate a cube at the calculated position with a random color

                    Instantiate(cubePrefabs[randomIndex], cubePosition, Quaternion.identity);

                    yield return new WaitForSeconds(.1f);
                }

                yield return new WaitForSeconds(1f);
            }

            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator SpawnStuff(Vector3 cubePosition)
    {
        yield return new WaitForSeconds(3);

        Instantiate(cubePrefabs[randomIndex], cubePosition, Quaternion.identity);
    }
}
