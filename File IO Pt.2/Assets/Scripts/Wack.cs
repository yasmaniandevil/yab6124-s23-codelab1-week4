using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Wack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        transform.position =
            new Vector3(
                Random.Range(-4, 7),
                Random.Range(-1, 6));

                GameManager.Instance.Score++;
    }
}
