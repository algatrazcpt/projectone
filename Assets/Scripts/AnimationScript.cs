using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Transform targetPostion;
    Vector3 startPosition;
    void Start()
    {
        startPosition= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction= targetPostion.position - transform.position;
        if (Vector3.Distance(transform.position, targetPostion.position)>0.2f)
        {
            transform.position += direction.normalized * Time.deltaTime * 5f;
        }
        else
        {
            Debug.Log("target arrived");
            transform.position = startPosition;
        }


    }
}
