using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    public float GetTime()
    {
        return time;
    }
}
