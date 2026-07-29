using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] RaycastHit hit;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name); 
                
            }
        }
        
    }
}
