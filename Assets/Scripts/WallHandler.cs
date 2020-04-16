using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] wallPrefabs;

    [SerializeField]
    private GameObject player;

    int currentPossition = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (((int)player.transform.position.y) %4 == 0 
            && currentPossition != (int)player.transform.position.y )
        {
            currentPossition = (int)player.transform.position.y;
            GameObject newWall = Instantiate(wallPrefabs[Random.Range(0, 2)], new Vector3(transform.position.x,gameObject.transform.GetChild(transform.childCount - 1 ).transform.position.y + 4,0), Quaternion.identity);
            newWall.transform.parent = gameObject.transform;
            Destroy(gameObject.transform.GetChild(0).gameObject);
        }
    }
}
