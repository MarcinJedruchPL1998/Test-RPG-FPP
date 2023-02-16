using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public bool[] doorLocked;
    bool[] doorOpened = new bool[7];
   
    [SerializeField] GameObject lockedText;

    public void CheckIfDoorLocked(GameObject door)
    {
        int doorIndex;
        int.TryParse(door.name, out doorIndex);

        if(doorLocked[doorIndex] == true)
        {
            lockedText.GetComponent<Animator>().enabled = true;
            lockedText.GetComponent<Animator>().Play("potrzebuje_klucza_anim");
            lockedText.GetComponent<Animator>().Rebind();
        }

        else
        {
            if (!doorOpened[doorIndex]) { OpenDoor(door, doorIndex); }
        }
    }

    public void OpenDoor(GameObject door, int doorIndex)
    {
        GetComponent<AudioSource>().Play();

        door.GetComponent<Animator>().enabled = true;
        door.GetComponent<Animator>().Play(door.name + "opendoor");
        doorOpened[doorIndex] = true;
    }
}
