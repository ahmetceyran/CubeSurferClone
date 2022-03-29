using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 
    bool gameHasEdned = false;

    public float restartDelay = 2f; //Restart ve yeni level'a gecerken beklenecek sureler
    public float NextLevelDelay = 5f;

    public MainCubeScript mainCubeScript; //Script ve UI'lara erisim icin gerekli degiskenler
    public GameObject completeLevelUI;
    public GameObject restartLevelUI;
    public GameObject player;
    public Text coinText;
    public Text cubeText;
    public Text CoinDisplay;

    void Update()
    {
        CoinDisplay.text = "Coins : " + mainCubeScript.points; //Coinleri anlik yazdirma
    }

    public void CompleteLevel() //Level Sonu UI'in aktiflestirilmesi ve yeni level'in yuklenmesi
    {
        CoinDisplay.text = "";
        coinText.text = "Coins Collected : " + mainCubeScript.points;
        cubeText.text = "Cubes Left After Finish : " + (player.transform.childCount-3);
        completeLevelUI.SetActive(true);
        Invoke("OpenLevel2", NextLevelDelay);
    }

    public void EndGame() //Bolum gecilemezse restart'i saglayacak fonksiyon
    {
        if(gameHasEdned == false)
        {
            CoinDisplay.text = "";
            gameHasEdned = true;
            restartLevelUI.SetActive(true);
            Invoke("Restart", restartDelay);
        }
        
    }

    void Restart() //Restart fonksiyonu
    {
        restartLevelUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenLevel2() //Ikinci level'i acmayi saglayacak fonksiyon
    {
        completeLevelUI.SetActive(false);
        SceneManager.LoadScene("Level02");
    }

    
}
