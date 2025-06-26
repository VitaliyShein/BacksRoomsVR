using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useLighting : MonoBehaviour
{
    public Light Light;
    public bool owned;
    public bool on;
    // Start is called before the first frame update
    void Start()
    {
        Light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Invoke("lighting", 0.5f);
        }
        
    }

    public void lighting()
    {
            on = !on;
            Light.enabled = on;
        
    }
}
