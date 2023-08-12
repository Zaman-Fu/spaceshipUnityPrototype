using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSettings : MonoBehaviour
{
    static private OptionSettings Instance;
    bool gamepadEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public static bool isGamepadEnabled()
    {
        return Instance.gamepadEnabled;
    }
    
}
