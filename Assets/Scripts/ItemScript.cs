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
    public Vector3 velocity;
    public float speed;

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

    public void Throw(Vector3 direction)
    {
        // tansform.Rotate()
        velocity = new Vector3(1,0,0);
        GetComponent<Collider2D>().isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
    }


}
