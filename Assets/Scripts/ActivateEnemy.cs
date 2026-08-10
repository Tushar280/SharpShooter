using UnityEngine;

public class ActivateEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyTrigger;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            enemyTrigger.SetActive(true);
        }
    }
}
