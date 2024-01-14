using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    [SerializeField] private float speed = 2.0f;

    [SerializeField] private Transform spawnOffset;

    [SerializeField] private BuildHouse[] house;
    [SerializeField] private int coins = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(horizontalInput, 0f, verticalInput);
        transform.position += moveDir * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (coins >= 5)
            {
                BuyHouse();
            }
            else
            {
                Debug.Log("Not Enough Coins");
            }

;       }
    }

    private void BuyHouse()
    {
        coins -= 5;
        BuildHouse houseBuilt = Instantiate(house[Random.Range(0, house.Length)], spawnOffset.position, Quaternion.identity);
        houseBuilt.StartBuild();
        Debug.Log("Bought with 5 coins, house has started building");
    }

    public void Test()
    {

    }
}
