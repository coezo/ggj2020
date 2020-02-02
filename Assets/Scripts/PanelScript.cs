using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
