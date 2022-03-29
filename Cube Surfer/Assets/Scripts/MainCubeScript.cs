using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCubeScript : MonoBehaviour
{
    public int points = 0;
    public int StartChilds; //Engele carpma durumunda kontrol icin gerekli degisken
    public int ChildInPlay; //Kontrol degiskeni

    public Movement movement;

    
    void Start()
    {
        StartChilds = transform.childCount; //Ilk bastaki child sayisinin daha sonrasi icin belirlenmesi
    }

    
    void Update()
    {
        ChildInPlay = transform.childCount; //Child degisimi kontrolu
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin") //Carpisilan obje coin ise puan artmasi
        {
            points++;
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.tag == "Obstacle" && StartChilds == transform.childCount) //Carpisilan obje engel ve kup sayisi baslangic ile ayniysa oyunun bitmesi
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }

        if (other.gameObject.tag == "Finish" && StartChilds == transform.childCount) //Carpisilan obje finis basamaklarindan biri ise ve toplanan kupler bitmis ise oyunun bitmesi
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().CompleteLevel();
        }

        if(other.gameObject.tag =="LastLine") //Main kupun carptigi obje finis basamaklarindan sonra gelen cizgi ise oyunun bitmesi
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().CompleteLevel();
        }
    }
    

    
}
