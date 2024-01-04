using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIghtingEnemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyRb;
    private bool isAttacking = false;

    [SerializeField] private float enemySpeed;
    [SerializeField] private float distanceToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Distance is " + Vector3.Distance(transform.position, player.transform.position));
        if ((Vector3.Distance(transform.position,player.transform.position) < distanceToPlayer)
            && isAttacking == false)
        {
            //Enemy Attack
            Attack();
        }
    }

    public void Attack()
    {   
        if (isAttacking == false)
        {
            enemyRb.AddForce(transform.forward * enemySpeed, ForceMode.Impulse);
            isAttacking = true;
        }
    }



}
