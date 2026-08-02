using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] GameObject target;

    EnemyHealth em;

    UnityEngine.AI.NavMeshAgent agentRobo;

    private void Awake()
    {
        em = GetComponent<EnemyHealth>();
        agentRobo = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        agentRobo.SetDestination(target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            em.SelfDestroy();
        }
    }
}
