using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShakerController : MonoBehaviour
{
    GameObject Player;
    NavMeshAgent nav;
    public int startingHealth = 80;
    public int currentHealth;
    bool isDead = false;


    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    private bool playerInRange = false;

    private float timer;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();

        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            nav.SetDestination(Player.transform.position);
        }

        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && currentHealth > 0)
        {
            
            Attack();
        }

        if (Player.gameObject.GetComponent<PlayerController>().currentHealth <= 0)
        {
            //todo play player death animation
        }
    }

    public void TakeDamage(int amount)
    {

        if (isDead)
        {
            return;
        }

        StartCoroutine(FlashCoRoutine());

        //IMPLEMENT AUDIO
        currentHealth -= amount;

        //IMPLEMENT PARTICLE EFFECTS
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {

        isDead = true;
        GetComponent<NavMeshAgent>().enabled = false;

        GameManager.instance.scoreSystem.ScoreUp(60);

        Destroy(gameObject, 2f);
    }

    IEnumerator FlashCoRoutine()
    {
        yield return new WaitForSeconds(.1f);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            playerInRange = false;
        }
    }

    void Attack()
    {
        timer = 0f;

        if (Player.gameObject.GetComponent<PlayerController>().currentHealth > 0)
        {
            Player.gameObject.GetComponent<PlayerController>().TakeDamage(attackDamage);
        }
    }
}
