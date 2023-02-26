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
    

    //public TextMeshPro username;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setName()
    {
        //Username.text = Username_input.text;
        Debug.Log(Username_input.text);
    }

 
}
