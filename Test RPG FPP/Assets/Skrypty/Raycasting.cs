using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    InputMaster inputMaster;
    bool fClicked;

    [SerializeField] float rayDistance;
    [SerializeField] Camera cam;

    [SerializeField] GameObject pressF;

    [SerializeField] DoorManager doorManager;
    [SerializeField] RiddleManager riddleManager;

    void Awake()
    {
        inputMaster = new InputMaster();
    }

    private void OnEnable()
    {
        inputMaster.Player.Use.Enable();
    }

    private void OnDisable()
    {
        inputMaster.Player.Use.Disable();
    }

    void Update()
    {
        fClicked = inputMaster.Player.Use.WasPerformedThisFrame();

        RaycastHit rayhit;
       
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out rayhit, rayDistance))
        {
            if(rayhit.transform.gameObject.tag == "przycisk")
            {
                pressF.SetActive(true);
                
                if(fClicked)
                {
                    riddleManager.ButtonClicked(rayhit.transform.gameObject);
                }

            }

            else if(rayhit.transform.gameObject.tag == "dzwignia")
            {
                pressF.SetActive(true);

                if (fClicked)
                {
                    rayhit.transform.gameObject.GetComponent<Animator>().enabled = true;
                    rayhit.transform.gameObject.GetComponent<Animator>().Play("dzwignia_on");
                    doorManager.doorLocked[5] = false;
                }
            }

            else if(rayhit.transform.gameObject.tag == "drzwi")
            {
                pressF.SetActive(true);

                if (fClicked)
                {
                    doorManager.CheckIfDoorLocked(rayhit.transform.gameObject);
                }
            }
            
        }

        else
        {
            pressF.SetActive(false);
        }
    }
}
