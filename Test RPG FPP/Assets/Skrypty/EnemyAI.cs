using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float playerDistanceLook, playerDistanceAttack;

    bool seePlayer;

    Animator anim;

    NavMeshAgent agent;

    public int life;

    [SerializeField] Material skinMaterial;

    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

    }

   
    void Update()
    {
        if(life > 0)
        {
            bool lookDistance = Vector3.Distance(transform.position, player.position) <= playerDistanceLook;
            bool attackDistance = Vector3.Distance(transform.position, player.position) <= playerDistanceAttack;

            if (lookDistance)
            {
                seePlayer = true;
            }

            if (seePlayer)
            {
                agent.updateRotation = false;

                Quaternion lookRotation = Quaternion.LookRotation(player.position - transform.position);

                if (attackDistance)
                {
                    anim.Play("przeciwnik_Attack");

                }
                else
                {
                    anim.Play("przeciwnik_Run");
                    agent.SetDestination(player.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 4 * Time.deltaTime);
                }
            }
        }

        else
        {
            anim.Play("przeciwnik_Die");
            Destroy(gameObject, 2);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ogien")
        {
            StartCoroutine(HitColor());
        }

    }

    public void HitByPlayersSword()
    {
        StartCoroutine(HitColor());
    }

    IEnumerator HitColor()
    {
        life -= 50;
        
        skinMaterial.color = Color.yellow;
        yield return new WaitForSeconds(0.4f);
        skinMaterial.color = Color.red;
    }
}
