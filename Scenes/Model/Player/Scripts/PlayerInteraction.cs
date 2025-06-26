using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Camera mainCam;
    public float intDistance = 10f;
    private RaycastHit hit;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;

    //flashlight

    public GameObject flashLight;


    // Update is called once per frame
    void Update()
    {
         interactionRay();
    }

    void interactionRay()
    {
        // пуск "луча" из центра экрана 
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        Vector3 mouse = Input.mousePosition;
        mouse.z = 10f;
        mouse = mainCam.ScreenToWorldPoint(mouse);

        bool hitSomething = false;

        if(Physics.Raycast(ray, out hit, intDistance)) // основная логика взаимодействия через "луч" с объектами на сцене.
        {
            INstruct inst1 = hit.collider.GetComponent<INstruct>();
            Debug.DrawRay(mainCam.transform.position, mouse - transform.position, Color.yellow);

            if (hit.collider.tag != "Untagged" && hit.collider.tag != "Stena" && hit.collider.tag != "Player" && hit.collider.tag != "ClearBox") // условие хита "луча" для взаимодействия.
            {
                hitSomething = true;

                if (hit.collider.tag == "NPC") // взаимодействие с клапаном, у которого есть тег "клап1"
                {
                    interactionText.text = inst1.getSign();

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        hit.transform.GetComponent<UseNPC>().chatId = 0;
                        hit.transform.GetComponent<UseNPC>().GetSign();
                    }
                }

                if (hit.collider.tag == "Flashlight") // взаимодействие с клапаном, у которого есть тег "клап1"
                {
                    interactionText.text = inst1.flashlight();

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Destroy(flashLight);
                        player.GetComponent<useLighting>().owned = true;
                    }

                }
            }
        }
        interactionUI.SetActive(hitSomething);
    }
}

