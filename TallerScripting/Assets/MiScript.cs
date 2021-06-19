using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HOLA MUNDO!");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("FRAME");
    }

    private void OnApplicationQuit(){
        Debug.Log("TERMINADO");
    }

    
}
