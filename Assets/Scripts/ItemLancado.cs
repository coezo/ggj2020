﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLancado : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector3 velocity;
    public float speed;
    private ItemScript.ItemType itemType;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
    }

    public void Throw(ItemScript.ItemType type, Vector3 direction)
    {
        Debug.Log("Tipo " + type + " - " + (int)type);
        spriteRenderer.sprite = GameManager.Instance.sprites[(int)type];
        itemType = type;
        velocity = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("colidiu com outra coisa");
        Destroy(gameObject);
    }
}
