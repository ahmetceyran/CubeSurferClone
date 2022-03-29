using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    GameObject MainCube;
    int Height; //kup birakildiginda yuksekligin azaltilmasi icin gerekli degisken

    
    void Start()
    {
        MainCube = GameObject.Find("MainCube");
    }

    // Main kup ve toplanacak kupun pozisyon kontrolu
    void Update()
    {
        MainCube.transform.position = new Vector3(transform.position.x, Height + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -Height, 0);
    }

    //kup birakildiginda cagrilacak fonksiyon
    public void LowerHeight()
    {
        Height--;

    }

    //Carpisilan kupun tagi collect ise alinmasi ve yuksekligin arttirilmasi
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Collect" && other.gameObject.GetComponent<CollectiableCube>().GetIsCollected() == false)
        {
            Height++;
            other.gameObject.GetComponent<CollectiableCube>().MakeCollected();
            other.gameObject.GetComponent<CollectiableCube>().SetIndex(Height);
            other.gameObject.transform.parent = MainCube.transform;
        }

    }

}
