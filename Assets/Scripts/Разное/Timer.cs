using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeToDiactivate = 5;
    float carrentTime;
    private void Start() 
    {
        carrentTime = timeToDiactivate;
    }
    void Update()
    {
        if(carrentTime <= 0)
        {
            carrentTime = timeToDiactivate;
            gameObject.SetActive(false);
        }
        carrentTime -= Time.deltaTime;
    }
}
