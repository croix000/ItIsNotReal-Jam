using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieFollowBehaviour : MonoBehaviour
{

    NavMeshAgent navMeshAgent;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        navMeshAgent.destination = player.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Collided with " + collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("Player")) {

            GameManager.Instance.ShowGameOver();
        
        }
    }

}
