using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkSpawner : MonoBehaviour
{
    public GameObject sparkPrefab;
    public float timer, timerMax, screenWidth;
    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 )
        {
            timer = timerMax;
            SpawnSpark();
        }
    }

    private void SpawnSpark()
    {
        GameObject g = Instantiate(sparkPrefab);
        g.transform.SetParent(transform, false);
        g.transform.position = new Vector2(Random.Range(-8f, 9f), transform.position.y);
        Destroy(g, 10f);
        
    }
}
