using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsUI : MonoBehaviour, INstruct
{
    public bool sign;
    public bool take;
    // Start is called before the first frame update

    void Update()
    {
        getSign();
        flashlight();
    }
    public string getSign()
    {
        if (sign == false)
        {
            return "Нажмите [F] чтобы <color=green>говорить</color>.";
        }
        else
        {
            return "";
        }
    }
    public string flashlight()
    {
        if (take == false)
        {
            return "Нажмите [F] чтобы подобрать <color=green>фонарик</color>.";
        }
        else
        {
            return "";
        }
    }

}
