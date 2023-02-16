using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackPlayer : MonoBehaviour
{
    InputMaster inputMaster;

    [SerializeField] GameObject playerHands;

    [SerializeField] Transform fireSpawner;
    [SerializeField] GameObject firePrefab;

    public bool canSwordAttack;
    bool swordAttack;

    [SerializeField] AudioClip fireSound, swordSound;

    GameObject attackedEnemy;


    private void Awake()
    {
        inputMaster = new InputMaster();
        inputMaster.Player.Fire.performed += ctx => AttackFire(ctx);
        inputMaster.Player.Sword.performed += ctx => AttackSword(ctx);
       
    }

    private void OnEnable()
    {
        inputMaster.Player.Fire.Enable();
        inputMaster.Player.Sword.Enable();
    }

    private void OnDisable()
    {
        inputMaster.Player.Fire.Disable();
        inputMaster.Player.Sword.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "przeciwnik")
        {
            canSwordAttack = true;
            attackedEnemy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "przeciwnik")
        {
            canSwordAttack = false;
        }
    }

    public void AttackSword(InputAction.CallbackContext ctx)
    {
        playerHands.GetComponent<Animator>().Play("Prawa_reka_Attack", 1);

        playerHands.GetComponent<AudioSource>().PlayOneShot(swordSound);

        StartCoroutine(SwordAttackBool());

        if(canSwordAttack)
        {
            attackedEnemy.GetComponent<EnemyAI>().HitByPlayersSword();
        }

    }

    public void AttackFire(InputAction.CallbackContext ctx)
    {
        if(GetComponent<LifeCoinsMana>().mana > 0)
        {
            playerHands.GetComponent<Animator>().Play("Lewa_reka_Attack", 0);

            playerHands.GetComponent<AudioSource>().PlayOneShot(fireSound);

            Instantiate(firePrefab, fireSpawner.transform.position, fireSpawner.transform.rotation);

            GetComponent<LifeCoinsMana>().RemoveMana();
        }
    }

    IEnumerator SwordAttackBool()
    {
        swordAttack = true;
        yield return new WaitForSeconds(0.4f);
        swordAttack = false;
    }
}
