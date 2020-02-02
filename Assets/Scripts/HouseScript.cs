using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    public char owner;

    private SpriteRenderer spriteRenderer;
    public Sprite[] spritesCasa;
    public Sprite[] spritesUpgrades;
    public float life;
    public float lifeUpgrade;
    public int upgradeLevel;

    public int inventoryWool;
    public int inventoryWood;
    public int inventoryIron;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var gameObject = collision.gameObject;
        if (gameObject.CompareTag("ItemLancado") && gameObject.GetComponent<ItemLancado>().owner != owner)
        {
            Dano(gameObject.GetComponent<ItemLancado>().GetDamage());
        }
    }

    private void Upgrade()
    {
        if(upgradeLevel < 3)
        {
            upgradeLevel++;
            spriteRenderer.sprite = spritesUpgrades[upgradeLevel - 1];
            switch (upgradeLevel)
            {
                case 1:
                    lifeUpgrade = 1.0f;
                    break;
                case 2:
                    lifeUpgrade = 2.0f;
                    break;
                case 3:
                    lifeUpgrade = 3.0f;
                    break;
            }
        }
        VerificaUpgrade();
    }

    private void Downgrade()
    {
        if(upgradeLevel > 0)
        {
            upgradeLevel--;
            if (upgradeLevel == 0)
            {
                spriteRenderer.sprite = spritesCasa[1];
            }
            else
            {
                spriteRenderer.sprite = spritesUpgrades[upgradeLevel - 1];
            }
        }
        VerificaUpgrade();
    }

    private void Dano(float damage)
    {
        if(upgradeLevel > 0)
        {
            lifeUpgrade -= damage;
            if(lifeUpgrade <= 0)
            {
                lifeUpgrade = 0;
                Downgrade();
            }
        } else
        {
            life--;
            spriteRenderer.sprite = spritesCasa[0];
            if (life < 0) life = 0;
        }
        VerificaUpgrade();
    }

    public bool StoreItem(ItemScript.ItemType item)
    {
        var success = false;
        switch (item)
        {
            case ItemScript.ItemType.Wool:
                if(inventoryWool == 3)
                {
                    success = false;
                }
                else
                {
                    inventoryWool++;
                    success = true;
                    VerificaUpgrade();
                }
                break;
            case ItemScript.ItemType.Wood:
                if (inventoryWood == 3)
                {
                    success = false;
                }
                else
                {
                    inventoryWood++;
                    success = true;
                    VerificaUpgrade();
                }
                break;
            case ItemScript.ItemType.IronCoin:
                if (inventoryIron == 3)
                {
                    success = false;
                }
                else
                {
                    inventoryIron++;
                    success = true;
                    VerificaUpgrade();
                }
                break;
            case ItemScript.ItemType.Hammer:
                success = true;
                Upgrade();
                break;
        }

        return success;
    }

    private void VerificaUpgrade()
    {
        switch (upgradeLevel)
        {
            case 0:
                if (life == 0)
                {
                    if (inventoryWool == 3)
                    {
                        life++;
                        spriteRenderer.sprite = spritesCasa[1];
                        inventoryWool = 0;
                    }
                    else if (inventoryWood == 3)
                    {
                        life++;
                        spriteRenderer.sprite = spritesCasa[1];
                        inventoryWood = 0;
                    }
                    else if (inventoryIron == 3)
                    {
                        life++;
                        spriteRenderer.sprite = spritesCasa[1];
                        inventoryIron = 0;
                    }
                }
                else
                {
                    if (inventoryWool == 3)
                    {
                        inventoryWool = 0;
                        Upgrade();
                    }
                }
                break;
            case 1:
                if(inventoryWood == 3)
                {
                    inventoryWood = 0;
                    Upgrade();
                }
                break;
            case 2:
                if (inventoryIron == 3)
                {
                    inventoryIron = 0;
                    Upgrade();
                }
                break;
        }
    }

}
