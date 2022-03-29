using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigi;

    bool left; //Dokunulan tarafin belirlenmesi icin gerekli degiskenler
    bool right;

    public float speed = 5.0f; //Dogrusal hareket hizini belirleyen degisken
    

    //public float DirectionalSpeed; //Pc hareket
    //public float VerticalSpeed;

    
    void Start()
    {
        rigi = GetComponent<Rigidbody>();

    }

    //Dokunus algilama fonksiyonu
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime); //Ileri yonlu hareket


        Vector3 GoLeft = new Vector3(transform.position.x, transform.position.y, -4.3f); //Sag ve Sol icin sinirlarin belirlenmesi
        Vector3 GoRight = new Vector3(transform.position.x, transform.position.y, 4.3f);

        if (Input.touchCount > 0) //Dokunma algilama
        {

            Touch finger = Input.GetTouch(0); //Girdiyi tutacak degisken

            if(finger.deltaPosition.x > 50.0f) //Saga gitme aktiflestirme
            {
                right = true;
                left = false;
            }

            if (finger.deltaPosition.x < -50.0f) //Sola gitme aktiflestirme
            {
                right = false;
                left = true;
            }

            if(right == true) //Saga gitme
            {
                transform.position = Vector3.Lerp(transform.position, GoRight, speed * Time.deltaTime);
                    //sağ = -5 max
                    //sol = 5 max
            }

            if (left == true) // Sola gitme
            {
                transform.position = Vector3.Lerp(transform.position, GoLeft, speed * Time.deltaTime);
                //sağ = -5 max
                //sol = 5 max
            }
        }


        //float HorizontalAxis = Input.GetAxis("Horizontal") * VerticalSpeed * Time.deltaTime; // Pc hareket
        //this.transform.Translate(HorizontalAxis, 0, DirectionalSpeed * Time.deltaTime);
    }

    

}
