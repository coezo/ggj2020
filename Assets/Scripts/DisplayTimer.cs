 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 
 public class DisplayTimer : MonoBehaviour {
 
     Text txt;
     // Use this for initialization
     void Start () {
         txt = gameObject.GetComponent<Text>(); 
     }
     
     // Update is called once per frame
     void Update () {
         txt.text = "" + (int)GameManager.Instance.gameTime;
     }
 }