using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLancado : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector3 velocity;
    public float speed;
    private ItemScript.ItemType itemType;
    public char owner;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
    }

    public void Throw(char controller, ItemScript.ItemType type, Vector3 direction)
    {
        spriteRenderer.sprite = GameManager.Instance.sprites[(int)type];
        itemType = type;
        velocity = direction;
        owner = controller;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

    public float GetStunTime()
    {
        switch(itemType)
        {
            case ItemScript.ItemType.Hammer: return 4.0f;
            case ItemScript.ItemType.Wool: return 1.0f;
            case ItemScript.ItemType.Wood: return 2.0f;
            case ItemScript.ItemType.IronCoin: return 3.0f;
            default: return 0.0f;
        }
    }


}
