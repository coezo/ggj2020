using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public enum ItemType {
      None = -1,
      Hammer = 0,
      IronCoin = 1,
      Wood = 2,
      Wool = 3
    };

    public ItemType itemType;

    public static GameObject ItemFromType(ItemType type)
    {
        switch(type)
        {
          case ItemType.Hammer: return Resources.Load<GameObject>("Prefabs/Hammer");
          case ItemType.IronCoin: return Resources.Load<GameObject>("Prefabs/IronCoin");
          case ItemType.Wood: return Resources.Load<GameObject>("Prefabs/Wood");
          case ItemType.Wool: return Resources.Load<GameObject>("Prefabs/Wool");
          default: return null;
        }
    }


    void Start()
    {
          // transform.Translate(position);
          
    }

}
