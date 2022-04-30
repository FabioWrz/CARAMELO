using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {
    public GameObject options;
    public GameObject ranking;
    public GameObject creditos;
   
    public void onShowOptions() {
        options.SetActive(!options.activeSelf);
    }
    public void onShowRanking() {
        ranking.SetActive(!ranking.activeSelf);
    }
    public void onShowCreditos() {
        creditos.SetActive(!creditos.activeSelf);
    }

    public void TrocarCenas(string nome){
        SceneManager.LoadScene(nome);   
    }
}
