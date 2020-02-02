using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    private int level;
    private Animator animator;
    private SpriteRenderer nivelSpriteRenderer;

    public int[3] Inventory;
    private int[3] LifePerLevel = {1, 2, 3};

    void Awake()
    {
        level = 1;
        animator = GetComponent<Animator>();
        nivelSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        switch(collider.gameObject.tag)
        {
            // case "Item":
            //     var itemScript = collider.gameObject.GetComponent<ItemScript>();
            //     currentItem = itemScript.itemType;
            //     Debug.Log("Tipo " + currentItem + " - " + (int)currentItem);
            //     itemCarregadoSpriteRenderer.sprite = GameManager.Instance.sprites[(int)currentItem];
            //     GameObject.Destroy(collider.gameObject);
            //     break;
            // case "ItemLancado":
            //     Debug.Log("Player atingido");
            //     // Stun
            //     break;
        }
    }

}
