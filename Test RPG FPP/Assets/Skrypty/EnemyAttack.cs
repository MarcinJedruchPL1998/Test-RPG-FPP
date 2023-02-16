using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] LifeCoinsMana lcm;
    [SerializeField] AttackPlayer attackPlayer;
    [SerializeField] EnemyAI enemyAI;

    public bool canAttackPlayer;
    
    public void AttackPlayer()
    {
        if(canAttackPlayer)
        {
            lcm.RemoveLife();
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canAttackPlayer = true;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canAttackPlayer = true;

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canAttackPlayer = false;
        }
    }

}
