using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Movement movement;
    public GameObject firsText; // kaldirilacak text
    
    

    // Baslangicta movement script'ini aktiflestirecek fonksiyon
    void Update()
    {
        if (Input.touchCount > 0)
        {
            movement.enabled = true;
            firsText.SetActive(false);
        }

    }
}
