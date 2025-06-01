using UnityEngine;
using UnityEngine.AI;
using TMPro; // Add this

public class AiMovement : MonoBehaviour
{
    public Transform target;
    public TextMeshProUGUI popText; 

    private NavMeshAgent agent;
    private bool hasReached = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (target != null)
            agent.SetDestination(target.position);

        if (popText != null)
            popText.gameObject.SetActive(false); 
    }

    void Update()
    {
        if (hasReached) return;

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            hasReached = true;
            agent.isStopped = true;
            Debug.Log("Treasure reached!");
            
            if (popText != null)
            {
                popText.gameObject.SetActive(true);
                popText.text = "Treasure Found!";
            }
        }
    }
}
