using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBasedSomething : MonoBehaviour
{
    [SerializeField] private float waitTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ShowTimer(waitTime));
    }

    IEnumerator ShowTimer(float waitAmount)
    {

        yield return new WaitForSeconds(waitAmount);

        Debug.Log("Timer showing Something");
    }
}
