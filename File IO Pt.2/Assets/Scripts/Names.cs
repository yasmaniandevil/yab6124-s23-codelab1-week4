using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class Names : MonoBehaviour
{

    public static Names Instance;

    public TextMeshPro Username;
    public TMP_InputField Username_input;

    public string player_name;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //public TextMeshPro username;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void setName()
    {
        //Username.text = Username_input.text;
        Debug.Log(Username_input.text);
    }*/

    public void setPlayerName()
    {
        player_name = Username_input.text;
    }
 
}
