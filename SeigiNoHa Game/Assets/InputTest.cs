using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SNH.InputManager;

public class InputTest : MonoBehaviour
{
    float h;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Controller.MainHorizontal();
        Debug.Log(h);
    }
}
