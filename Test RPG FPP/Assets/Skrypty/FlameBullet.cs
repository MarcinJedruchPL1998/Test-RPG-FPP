using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBullet : MonoBehaviour
{

    [SerializeField] float speed;

    private void OnEnable()
    {
        Destroy(gameObject, 4f);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
