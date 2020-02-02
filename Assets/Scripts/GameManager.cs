using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    public GameObject hammer;
    public GameObject ironCoin;
    public GameObject wood;
    public GameObject wool;

    const float SPAWN_TIME = 5.0f;
    public float spawnTime = SPAWN_TIME;
    public float range = 0.2f;

    private System.Random randomGen;
    private Transform itemPositionsComponent;
    void Start()
    {
        randomGen = new System.Random();
        itemPositionsComponent = GameObject.Find("ItemSpawPositions").transform;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0)
        {
           spawnTime = SPAWN_TIME;
           int children = itemPositionsComponent.childCount;
           int postionIndex = randomGen.Next(0, children);
            
           var position = itemPositionsComponent.GetChild(postionIndex).transform.position;
           // float xAxis = UnityEngine.Random.Range(position.x - range, position.x + range);
           // float yAxis = UnityEngine.Random.Range(position.y - range, position.y + range);
           int rand = randomGen.Next(0, 50);
           GameObject item = null;
           if(rand < 5)
           {
              item = hammer;
           }
           else if (rand < 15)
           {
              // item = ironCoin;
              item = wool;
           }
           else if (rand < 35)
           {
              item = wood;
           }
           else if (rand <= 50)
           {
              item = wool;
           }

           Instantiate(item, new Vector3(position.x, position.y, 0.0f), Quaternion.identity); 
        } 
    }

}
