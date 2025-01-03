using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackPlayerState : AiState
{
    private float lastShotTime = 0f;
    private float shotDelay = 2f; // 2-second delay between shots
    public AiStateId GetId()
    {
        return AiStateId.AttackPlayer;
    }
    public void Enter(AiAgent agent)
    {
        agent.GetComponent<WeaponIK>().enabled = true;
        agent.navMeshAgent.stoppingDistance = 5f;
    }
    public void Update(AiAgent agent)
    {
        agent.navMeshAgent.destination = agent.PlayerTransform.transform.position;
        if (Time.time - lastShotTime >= shotDelay)
        {

            agent.audioClip_forShoot.Play();
            ShootAtPlayer(agent);
            lastShotTime = Time.time;
        }
    }

    public void Exit(AiAgent agent)
    {
        agent.GetComponent<WeaponIK>().enabled = false;
        agent.navMeshAgent.stoppingDistance = 1.5f;
        agent.initialState = AiStateId.ChasePlayer;
    }

    private void ShootAtPlayer(AiAgent agent)
    {
            var bullet = AiAgent.Instantiate(agent.BulletTornado, agent.bulletSpawnPoint.position, agent.bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = agent.bulletSpawnPoint.forward * agent.bulletSpeed;
    }
}
