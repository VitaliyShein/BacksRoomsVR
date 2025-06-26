using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UseNPC : MonoBehaviour
{
    [SerializeField] GameObject Human;
    [SerializeField] Camera mainCam;
    [SerializeField] TextMeshProUGUI Sign;
    [SerializeField] Button Button;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] Image image;

    [SerializeField] TextMeshProUGUI interactionUI;
    [SerializeField] Image cursor;


    public bool isSign;
    public int chatId;
    // Start is called before the first frame update
    void Start()
    {
        Sign.gameObject.SetActive(false);
        Button.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
    }
    
    public  void GetSign()
    {

        interactionUI.gameObject.SetActive(false);
        cursor.gameObject.SetActive(false);

        mainCam.GetComponent<CinemachineBrain>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        image.gameObject.SetActive(true);
        Sign.gameObject.SetActive(true);
        Button.gameObject.SetActive(true);
        buttonText.text = "Дальше ->";
        chatId++;
        Debug.Log(chatId);
        if (chatId > 4)
        {
            mainCam.GetComponent<CinemachineBrain>().enabled = true;
            interactionUI.gameObject.SetActive(true);
            cursor.gameObject.SetActive(true);

            chatId = 0;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            image.gameObject.SetActive(false);
            Sign.gameObject.SetActive(false);
            Button.gameObject.SetActive(false);
        }
        switch (chatId)
        {
            case 1:
                Sign.text = "Привет!";
                break;

            case 2:
                Sign.text = "Как ты уже понял - это другое измерение";
                break;

            case 3:
                Sign.text = "Возьми фонарик на всякий случай и походи пооглядывайся тут. \n" +
                    "Как закончишь - иди по линии на полу к двери. За ней будут ожидать тебя опер. группа Ястреб.";
                break;

            case 4:
                Sign.text = "Удачи!";
                break;
        }
        
    }
}
