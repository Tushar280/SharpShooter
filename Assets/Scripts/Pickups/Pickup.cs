using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    const string PLAYER_TAG = "Player";
    [SerializeField] float rotationSpeed = 100f;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(PLAYER_TAG))
        {
            activeWeapon activeWeapon = other.GetComponentInChildren<activeWeapon>();
            OnPickup(activeWeapon);
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickup(activeWeapon activeWeapon);
}
