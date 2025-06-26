using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Cinemachine;

public class isTrigger : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Camera mainCam;
    [SerializeField] TextMeshProUGUI endText;
    [SerializeField] Image Image;
    [SerializeField] Button Button;
    [SerializeField] TextMeshProUGUI buttonName;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerEnter(Collider trigger)
    {
        if(trigger.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            endText.gameObject.SetActive(true);
            Image.gameObject.SetActive(true);
            Button.gameObject.SetActive(true);

            buttonName.text = "����� �� ����";
            mainCam.GetComponent<CinemachineBrain>().enabled = false;
            endText.text = "������� �� ����! \n" +
                "������ ����������� ��������� ���-23-1� ������� �������";
        }
    }
}
