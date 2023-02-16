using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleManager : MonoBehaviour
{
    [SerializeField] GameObject button_r, button_g, button_b;
    [SerializeField] GameObject riddle_r, riddle_g, riddle_b;
    [SerializeField] float rotateSpeed;

    bool[] rotate = new bool[3];

    [SerializeField] int riddle_r_pos, riddle_g_pos, riddle_b_pos;

    bool riddleOK;

    [SerializeField] GameObject rotBridge;

    public void ButtonClicked(GameObject button)
    {
        if(riddleOK == false)
        {
            button.GetComponent<Animator>().enabled = true;
            button.GetComponent<Animator>().Play(button.name + "_click");
            button.GetComponent<Animator>().Rebind();

            bool r = button.name.EndsWith("r");
            bool g = button.name.EndsWith("g");
            bool b = button.name.EndsWith("b");

            if (r)
            {
                riddle_r_pos += 1;
                if (riddle_r_pos > 3)
                {
                    riddle_r_pos = 0;
                }

                rotate[0] = true;
            }

            if (g)
            {
                riddle_g_pos += 1;
                if (riddle_g_pos > 3)
                {
                    riddle_g_pos = 0;
                }

                rotate[1] = true;
            }

            if (b)
            {
                riddle_b_pos += 1;
                if (riddle_b_pos > 3)
                {
                    riddle_b_pos = 0;
                }

                rotate[2] = true;
            }
        }


        if(riddle_r_pos == 3 && riddle_g_pos == 0 && riddle_b_pos == 3)
        {
            riddleOK = true;
            rotBridge.GetComponent<Animator>().enabled = true;
            rotBridge.GetComponent<Animator>().Play("most_rotate");

            button_r.GetComponent<BoxCollider>().enabled = false;
            button_g.GetComponent<BoxCollider>().enabled = false;
            button_b.GetComponent<BoxCollider>().enabled = false;

            GetComponent<AudioSource>().Play();
        }
    }

    private void Update()
    {
        if(rotate[0])
        {
            riddle_r.transform.rotation = Quaternion.AngleAxis(riddle_r_pos * 90f, Vector3.right);
        }
        if(rotate[1])
        {
            riddle_g.transform.rotation = Quaternion.AngleAxis(riddle_g_pos * 90f, Vector3.right);
        }
        if(rotate[2])
        {
            riddle_b.transform.rotation = Quaternion.AngleAxis(riddle_b_pos * 90f, Vector3.right);
        }
    }
}
