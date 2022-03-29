using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiableCube : MonoBehaviour
{
    bool IsCollected; //Kupun durum kontrolu icin gerekli degisken
    int Index; //Toplana kupun yuksekligini ayralamak icin gerekli degisken
    public Collector collector; //Yukseklik artirmak ve azaltmak icin gerekli fonksiyonu cagirma
    public Movement movement;
    

    
    void Start() //Baslangic durumu
    {
        IsCollected = false;
    }

    //Kup toplanmissa main kupun altina alma
    void Update()
    {
        if (IsCollected == true)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -Index, 0);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle") //Carpisma yasanan obje engel ise kup birakma
        {
                collector.LowerHeight();
                transform.parent = null;
                GetComponent<BoxCollider>().enabled = false;
                other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        if (other.gameObject.tag == "Finish") //Carpisma yasanan obje finish basamaklarinda biri ise kup birakma ama yukseklik azaltmamak icin gerekli yapi
        {
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        if (other.gameObject.tag == "LastLine") //Carpisilan obje finis basamaklarindan sonra gelen cizgi ise oyunun bitmesi
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().CompleteLevel();
        }
    }

    //Diger scriptlerde cagrilacak fonksiyonlar

    public bool GetIsCollected()
    {
        return IsCollected;
    }

    public void MakeCollected()
    {
        IsCollected=true;
    }

    public void SetIndex(int Index)
    {
        this.Index = Index;
    }

}
