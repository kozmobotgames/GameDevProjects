using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    public float timeToDestroy;

    // Update is called once per frame
    void Update()
    {
        Invoke("destroyMe", timeToDestroy);
    }

    void destroyMe()
    {
        Destroy(gameObject);
    }
}
