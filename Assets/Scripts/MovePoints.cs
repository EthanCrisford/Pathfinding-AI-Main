using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePoints : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
          
    }

    public void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}
