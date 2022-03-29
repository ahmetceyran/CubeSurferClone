using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Aim;
    public Vector3 Distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, Aim.transform.position + Distance, Time.deltaTime);
    }
}
