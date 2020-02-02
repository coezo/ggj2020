using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject instrucoes;
    public GameObject creditos;

    public void StartGame()
    {
        SceneManager.LoadScene("game");
    }

    public void ShowInstrucoes()
    {
        instrucoes.SetActive(true);
    }

    public void ShowCreditos()
    {
        creditos.SetActive(true);
    }
}
