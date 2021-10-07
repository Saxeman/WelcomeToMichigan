using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform goal;
    Vector3 start_point;
    NavMeshAgent agent;

    Collider[] hitColliders;
    Collider[] dmgColliders;

    bool player_hit = false;
    void Start()
    {
        start_point = transform.position;
        agent = GetComponent<NavMeshAgent>();
        Debug.Log(start_point);
    }

    // Update is called once per frame
    void Update()
    {
        dmgColliders = Physics.OverlapSphere(transform.position, 1.5f);
        foreach (var dmgCollider in dmgColliders)
        {
            if (dmgCollider.tag == "Player")
            {
                agent.enabled = false;
                player_hit = true;
                StartCoroutine(wait());
            }
        }

        if (player_hit == false) {
            hitColliders = Physics.OverlapSphere(transform.position, 100f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.tag == "Player")
                {
                    //Debug.Log("Player in range");
                    agent.destination = goal.position + Vector3.back;
                }
                else
                {
                    //Debug.Log("Player out of range, returning to start point");
                    //returns to spawn location
                    //possibly have it follow a route around the level.
                    agent.destination = start_point;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player") {
            Debug.Log("Collided with player");
        }
    }

    private IEnumerator wait() {
        yield return new WaitForSeconds(2.0f);
        agent.enabled = true;
        player_hit = false;
    }
}
