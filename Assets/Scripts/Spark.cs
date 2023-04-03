using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour
{
    public float moveSpeed, timeTillTurn = 3;
    public Vector2 moveDir = new Vector2(0, -1);
    public bool movingDown = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        timeTillTurn -= Time.deltaTime;
        if (timeTillTurn <= 0)
            NewDirection();
    }

    private void NewDirection()
    {
        if (movingDown)
        {
            moveDir = Random.Range(-1, 1) == -1 ? new Vector2(-1, 0) : new Vector2(1, 0);
            movingDown = !movingDown;
            timeTillTurn = 1f;
        } else
        {
            moveDir = new Vector2(0, -1);
            movingDown = !movingDown;
            timeTillTurn = 3f;
        }
    }
}
