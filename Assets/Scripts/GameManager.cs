using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject hammer;
    public GameObject ironCoin;
    public GameObject wood;
    public GameObject wool;

    public GameObject CatWon;
    public GameObject DogWon;

    public GameObject CatHouse;
    public GameObject DogHouse;

    public Sprite[] sprites;

    const float SPAWN_TIME = 5.0f;
    public float spawnTime = SPAWN_TIME;
    public float range = 0.2f;

    public float gameTime;

    private System.Random randomGen;
    public GameObject itemSpawnPositions;
    private Transform itemPositionsComponent;

    private bool finishingGame = false;

    public GameObject timer;

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
        if(!finishingGame)
        {
            UpdateRunningGame();
        }

        if(gameTime <= 0)
        {
            gameTime = 0;
            FinishGame();
        }
    }

    void UpdateRunningGame()
    {
        spawnTime -= Time.deltaTime;
        gameTime -= Time.deltaTime;
        timer.GetComponent<Text>().text = "" + (int)gameTime;

        if (spawnTime <= 0)
        {
            spawnTime = SPAWN_TIME;
            
            // float xAxis = UnityEngine.Random.Range(position.x - range, position.x + range);
            // float yAxis = UnityEngine.Random.Range(position.y - range, position.y + range);
            int rand = randomGen.Next(0, 50);
            GameObject item = null;
            if (rand < 2)
            {
                item = hammer;
            }
            else if (rand < 8)
            {
                item = ironCoin;
            }
            else if (rand < 20)
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

    private void FinishGame()
    {
       finishingGame = true;
       Time.timeScale = 0;
       if(true){
          CatWon.SetActive(true);
          DogWon.SetActive(false);
       }else{
          DogWon.SetActive(false);
          CatWon.SetActive(true);
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
