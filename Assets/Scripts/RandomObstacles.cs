using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacles : MonoBehaviour
{
    [SerializeField]
    private PlayerController pc;

    [SerializeField]
    private GameObject obsPrefab;

    [SerializeField]
    private Transform[] spawnPoints;

    private float timer = 6f;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * pc.moveSpeed);

        if ( timer <= 0 )
        {
            Instantiate(obsPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            timer = Random.Range(3, 8);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
