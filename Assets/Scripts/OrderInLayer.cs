using UnityEngine;
using System.Collections;

public class OrderInLayer : MonoBehaviour {

  private SpriteRenderer mainSprite;

  // Use this for initialization
  void Start () {
    mainSprite = GetComponent<SpriteRenderer> ();
  }

  void Update(){
    mainSprite.sortingOrder = (int) (-transform.position.y * 100.0f);
  }
  
}
