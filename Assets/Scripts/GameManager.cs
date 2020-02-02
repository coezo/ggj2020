using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject hammer;
    public GameObject ironCoin;
    public GameObject wood;
    public GameObject wool;

    public Sprite[] sprites;

    const float SPAWN_TIME = 5.0f;
    public float spawnTime = SPAWN_TIME;
    public float range = 0.2f;

    private System.Random randomGen;
    public GameObject itemSpawnPositions;
    private Transform itemPositionsComponent;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        randomGen = new System.Random();
        itemPositionsComponent = itemSpawnPositions.transform;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            spawnTime = SPAWN_TIME;
            
            // float xAxis = UnityEngine.Random.Range(position.x - range, position.x + range);
            // float yAxis = UnityEngine.Random.Range(position.y - range, position.y + range);
            int rand = randomGen.Next(0, 50);
            GameObject item = null;
            if (rand < 5)
            {
                item = hammer;
            }
            else if (rand < 15)
            {
                item = ironCoin;
            }
            else if (rand < 35)
            {
                item = wood;
            }
            else if (rand <= 50)
            {
                item = wool;
            }

            SpawnItem(item);
        }
    }

    private void SpawnItem(GameObject item)
    {
        int children = itemPositionsComponent.childCount;
        int positionIndex = randomGen.Next(0, children);
        var positionContainer = itemPositionsComponent.GetChild(positionIndex);

        if (positionContainer.childCount == 0)
        {
            var instance = Instantiate(item, positionContainer.transform.position, Quaternion.identity);
            instance.transform.parent = positionContainer.transform;
        }
    }

}
