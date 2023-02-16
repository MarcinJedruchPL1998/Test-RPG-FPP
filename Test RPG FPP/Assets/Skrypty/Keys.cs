using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [SerializeField] DoorManager doorManager;
    public void GotKey(GameObject key)
    {
        GetComponent<AudioSource>().Play();

        int keyIndex;
        int.TryParse(key.name, out keyIndex);

        doorManager.doorLocked[keyIndex] = false;

        Destroy(key);
    }
}
