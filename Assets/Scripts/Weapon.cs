using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] RaycastHit hit;
    [SerializeField] ParticleSystem muzz;
    [SerializeField] ParticleSystem hit1;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            muzz.Play();
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100))
            {   
                Instantiate(hit1,hit.point,Random.rotation);
                Debug.Log(hit.transform.gameObject.name); 
                EnemyHealth em = hit.transform.gameObject.GetComponent<EnemyHealth>();

                if(em)
                {
                    em.TakeDamage(10);
                }
            }
        }
        
    }
}
