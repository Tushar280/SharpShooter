using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] GameObject target;

    EnemyHealth em;

    UnityEngine.AI.NavMeshAgent agentRobo;
    PlayerHealth ph;

    private void Awake()
    {
        ph = FindAnyObjectByType<PlayerHealth>();
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
            ph.TakeDamage(40);
            em.SelfDestroy();
        }
    }
}
