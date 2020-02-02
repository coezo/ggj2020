using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public enum ItemType {
      None,
      Hammer,
      IronCoin,
      Wood,
      Wool
    };

    public ItemType itemType;

    public static GameObject ItemFromType(ItemType type)
    {
        switch(type)
        {
          case ItemType.Hammer: return Resources.Load<GameObject>("Prefabs/Hammer");
          // case ItemType.IronCoin: return Resources.Load<GameObject>("Prefabs/IronCoin");
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
