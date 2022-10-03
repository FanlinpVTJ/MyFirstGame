using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform patrolRoute;
    private Transform player;
    private int locationIndex = 0;
    public NavMeshAgent agent;
    public List<Transform> locations;

    // Start is called before the first frame update
    void Start()
    {
        InitializePatrolRoute();
        agent = GetComponent<NavMeshAgent>();
        Debug.Log(agent);
        player = GameObject.Find("Player_Body").transform;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player_Body")
        {
            Debug.Log("Player detected- - Attack!");
            agent.destination = player.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player_Body")
        {
            Debug.Log("Oooh no, he left!");
        }
    }
}
