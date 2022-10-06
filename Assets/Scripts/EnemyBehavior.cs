using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public event Action PlayerDetected;

    [SerializeField]
    private Transform patrolRoute;

    private int locationIndex = 0;
    public NavMeshAgent agent;
    public List<Transform> locations;

    // Start is called before the first frame update
    void Start()
    {
        InitializePatrolRoute();
        agent = GetComponent<NavMeshAgent>();
        Debug.Log(agent);
        MoveToNextPatrolLocation();
    }
    
    private void InitializePatrolRoute()
    {
        foreach(Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    public void MoveToNextPatrolLocation()
    {
        agent.destination = locations[locationIndex].position;
        if (locations.Count == 0)
        {
            return;
        }
        IncrementIndexLooped();
    }

    private void IncrementIndexLooped()
    {
        locationIndex++;
        if(locationIndex == locations.Count)
        {
            locationIndex = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    //Обнаружение игрока

    private void OnTriggerEnter(Collider player)
    {
        var playerRegistration = player.gameObject.GetComponent<PlayerMovement>();

        if (playerRegistration != null)
        {
            agent.destination = playerRegistration.transform.position;
            transform.LookAt(playerRegistration.transform.position);
            PlayerDetected?.Invoke();
            Debug.Log("Attack!");
        }
    }
    private void OnTriggerExit(Collider player)
    {
        var playerRegistration = player.gameObject.GetComponent<PlayerMovement>();

        if (playerRegistration != null)
        {
            agent.destination = locations[locationIndex].position;
            
            Debug.Log("Oh no! I lost him!");
        }
    }
   
}
