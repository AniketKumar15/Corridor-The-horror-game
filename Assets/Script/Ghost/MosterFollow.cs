using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MosterFollow : MonoBehaviour
{
    private NavMeshAgent monster;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        monster.SetDestination(player.transform.position);
    }
}
