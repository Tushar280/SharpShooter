using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.UI;
using StarterAssets;
using TMPro;

public class activeWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO startingWeapon;
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] GameObject zoomImg;
    [SerializeField] float zoomSense;

    [SerializeField] TMP_Text currentAmmoUI;
    [SerializeField] TMP_Text totalAmmoUI;
    
    Weapon currentweapon;
    CinemachineCamera virtualCamera;
    FirstPersonController fpc;

    float initTime;
    float defaultFov = 60f;
    float defaultZoomSense;
    int currentAmmo;

    private void Start()
    {   
        currentweapon = GetComponentInChildren<Weapon>();
        SwitchWeapon(startingWeapon);
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

        if (currentweapon == null && weaponSO != null && weaponSO.weaponPrefab != null)
        {
            SwitchWeapon(weaponSO);
        }
        initTime = 10;
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
        if (weaponSO == null || currentweapon == null) return;

        if (Input.GetKey(KeyCode.Mouse0) && currentAmmo > 0)
        {
            if (initTime >= weaponSO.firerate)
            {
                currentweapon.Shoot(weaponSO);
                currentAmmo -= 1;
                currentAmmoUI.text = currentAmmo.ToString("D2");
                initTime = 0;
            }
        }
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        Debug.Log("Switched to weapon: " + weaponSO.name);

        if (currentweapon != null)
        {
            Destroy(currentweapon.gameObject);
        }
        
        if (weaponSO != null && weaponSO.weaponPrefab != null)
        {
            totalAmmoUI.text = weaponSO.magSize.ToString("D2");
            currentAmmo = weaponSO.magSize;
            currentAmmoUI.text = currentAmmo.magSize.ToString("D2");
            Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
            currentweapon = newWeapon;
            this.weaponSO = weaponSO;
        }
    }
}
