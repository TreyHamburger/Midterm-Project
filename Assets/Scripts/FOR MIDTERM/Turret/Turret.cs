using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.XR;
using System;

public class Turret : MonoBehaviour
{
    public float attackDistance = 10f;
    public float damage = 10f;
    public LayerMask playerLayer;
    public LayerMask obstacleLayer;
   // public Color laserColor = Color.red;

    //public float attackCooldown = 1f;
    //private float attackTimer = 0f;

    private ITurretState currentState;
    private LineRenderer laserLine;


    // Start is called before the first frame update
    void Start()
    {
        laserLine = gameObject.AddComponent<LineRenderer>();
        laserLine.startWidth = 0.1f;
        laserLine.endWidth = 0.1f;
        /*laserLine.startColor = laserColor;
        laserLine.endColor = laserColor;*/
        laserLine.enabled = false;
        ChangeState(new IdleState() );
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();

        /*if(attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
        }*/
    }

    public void ChangeState(ITurretState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter(this);
    }

    public bool CanSeePlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackDistance, playerLayer);
        foreach (var hitCollider in hitColliders)
        {
            Vector3 direction = (hitCollider.transform.position - transform.position).normalized;
            if(!Physics.Raycast(transform.position, direction, attackDistance, obstacleLayer))
            {
                return true;
            }
        }
        return false;
    }

    public void StartShooting()
    {
            laserLine.enabled = true;
            laserLine.SetPosition(0, transform.position);
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackDistance, playerLayer);

            foreach (var hitCollider in hitColliders)
            {
                Vector3 direction = (hitCollider.transform.position - transform.position).normalized;
                if (!Physics.Raycast(transform.position, direction, attackDistance, obstacleLayer))
                {
                    laserLine.SetPosition(1, hitCollider.transform.position);

                    Health playerHealth = hitCollider.GetComponent<Health>();
                    if (playerHealth != null)
                    {
                        playerHealth.DeductHealth(damage);
                    }
                }
            }
        

  
    }

    public void StopShooting()
    {
        laserLine.enabled = false;
    }
}



