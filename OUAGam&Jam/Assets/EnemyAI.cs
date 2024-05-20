using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
     Transform player; 
    float attackRange = 0.2f; 
     float chaseRange = 0.5f; 
     float moveSpeed = 2f; 
     float attackInterval = 1.5f; 
    private float lastAttackTime; 
    private bool isAttacking = false; 
    private Animator anim; 

    private NavMeshAgent agent; // NavMeshAgent referansı

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
        agent.speed = moveSpeed; // Düşmanın hareket hızını ayarla
        anim = GetComponent<Animator>(); 
    }

    void Update()
    {
        if (player == null) 
        {
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position); // Düşman ile oyuncu arasındaki mesafeyi hesapla

        if (distanceToPlayer <= attackRange)
        {
            // Eğer düşman saldırı menzilindeyse
            if (!isAttacking)
            {
                
                isAttacking = true;
                agent.isStopped = true; // Düşmanı durdur
                anim.SetBool("Attack", true); 
                AttackPlayer(); // Saldırı fonksiyonunu çağır
            }
        }
        else if (distanceToPlayer <= chaseRange)
        {
            // Eğer düşman takip mesafesi içinde ama saldırı menzilinde değilse
            isAttacking = false;
            agent.isStopped = false; 
            anim.SetBool("Attack", false); 
             
            
            agent.SetDestination(player.position); // Oyuncuya doğru hareket et
        }
        else
        {
            // Eğer düşman takip mesafesinden uzaktaysa
            isAttacking = false;
            agent.isStopped = false; 
            anim.SetBool("Attack", false); 
            Patrol(); // Devriye hareketine devam et
        }
    }

    void AttackPlayer()
    {
        if (Time.time > lastAttackTime + attackInterval)
        {
            
            lastAttackTime = Time.time; // Son saldırı zamanını güncelle
        }
    }

    void Patrol()
    {
        
        if (!agent.hasPath)
        {
            Vector3 randomDirection = Random.insideUnitSphere * 10; 
            randomDirection += transform.position;
            NavMeshHit navHit;
            NavMesh.SamplePosition(randomDirection, out navHit, 10, -1);
            agent.SetDestination(navHit.position); // Rastgele noktaya hareket et
        }
    }
}
