using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] GameObject target;

    UnityEngine.AI.NavMeshAgent agentRobo;

    private void Awake()
    {
        agentRobo = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        agentRobo.SetDestination(target.transform.position);
    }
}
