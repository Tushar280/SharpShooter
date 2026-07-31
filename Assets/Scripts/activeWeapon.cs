using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.UI;
using StarterAssets;

public class activeWeapon : MonoBehaviour
{
    Weapon weapon;
    CinemachineCamera virtualCamera;
    GameObject currentWeaponInstance;
    FirstPersonController fpc;
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] GameObject zoomImg;
    [SerializeField] float zoomSense;
    
    

    float initTime;
    float defaultFov = 60f;
    float defaultZoomSense;

    private void Start()
    {
        weapon = GetComponentInChildren<Weapon>();
        virtualCamera = FindAnyObjectByType<CinemachineCamera>();
        fpc = FindAnyObjectByType<FirstPersonController>();
        defaultZoomSense = 1f;
        
        if (virtualCamera != null)
        {
            defaultFov = virtualCamera.Lens.FieldOfView;
        }
        else if (Camera.main != null)
        {
            defaultFov = Camera.main.fieldOfView;
        }

        if (weapon == null && weaponSO != null && weaponSO.weaponPrefab != null)
        {
            SwitchWeapon(weaponSO);
        }
        initTime = 0;
    }

    private void Update()
    {
        initTime += Time.deltaTime;
        HandleShoot();
        HandleZoom();
    }

    private void HandleZoom()
    {
        if (weaponSO == null || !weaponSO.canZoom) return;

        if (virtualCamera == null)
        {
            virtualCamera = FindAnyObjectByType<CinemachineCamera>();
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (virtualCamera != null)
            {
                virtualCamera.Lens.FieldOfView = weaponSO.zoomFov;
            }
            else if (Camera.main != null)
            {
                Camera.main.fieldOfView = weaponSO.zoomFov;
            }

            if (zoomImg != null) zoomImg.SetActive(true);

            fpc.ChangeSense(zoomSense);
        }
        else
        {
            if (virtualCamera != null)
            {
                virtualCamera.Lens.FieldOfView = defaultFov;
            }
            else if (Camera.main != null)
            {
                Camera.main.fieldOfView = defaultFov;
            }

            if (zoomImg != null) zoomImg.SetActive(false);

            fpc.ChangeSense(defaultZoomSense);
        }
    }

    private void HandleShoot()
    {
        if (weaponSO == null || weapon == null) return;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (initTime >= weaponSO.firerate)
            {
                weapon.Shoot(weaponSO);
                initTime = 0;
            }
        }
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        Debug.Log("Switched to weapon: " + weaponSO.name);

        if (weapon != null)
        {
            Destroy(weapon.gameObject);
        }
        if (weaponSO != null && weaponSO.weaponPrefab != null)
        {
            Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
            weapon = newWeapon;
            this.weaponSO = weaponSO;
        }
    }
}
