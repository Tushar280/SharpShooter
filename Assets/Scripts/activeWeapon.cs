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
        if (startingWeapon != null)
        {
            SwitchWeapon(startingWeapon);
        }
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
            if (virtualCamera == null && Camera.main != null)
            {
                var brain = Camera.main.GetComponent<CinemachineBrain>();
                if (brain != null && brain.ActiveVirtualCamera is CinemachineCamera vcam)
                {
                    virtualCamera = vcam;
                }
            }

            if (virtualCamera != null)
            {
                float currentCamFov = virtualCamera.Lens.FieldOfView;
                if (currentCamFov > 0) defaultFov = currentCamFov;
            }
            else if (Camera.main != null && Camera.main.fieldOfView > 0)
            {
                defaultFov = Camera.main.fieldOfView;
            }
        }

        if (defaultFov <= 0) defaultFov = 60f;

        bool isZooming = Input.GetKey(KeyCode.Mouse1);
        float targetFov = isZooming ? (weaponSO.zoomFov > 0 ? weaponSO.zoomFov : 15f) : defaultFov;

        if (virtualCamera != null)
        {
            var lens = virtualCamera.Lens;
            lens.FieldOfView = targetFov;
            virtualCamera.Lens = lens;
        }

        if (Camera.main != null)
        {
            Camera.main.fieldOfView = targetFov;
        }

        if (zoomImg != null) zoomImg.SetActive(isZooming);
        if (fpc != null) fpc.ChangeSense(isZooming ? zoomSense : defaultZoomSense);
    }

    private void HandleShoot()
    {
        if (weaponSO == null || currentweapon == null) return;

        if (Input.GetKey(KeyCode.Mouse0) && currentAmmo > 0)
        {
            if (initTime >= weaponSO.firerate)
            {
                currentweapon.Shoot(weaponSO);
                ChangeAmmo(-1);
                initTime = 0;
            }
        }
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if (weaponSO == null) return;

        Debug.Log("Switched to weapon: " + weaponSO.name);

        if (currentweapon != null)
        {
            Destroy(currentweapon.gameObject);
        }
        
        if (weaponSO != null && weaponSO.weaponPrefab != null)
        {
            currentAmmo = weaponSO.magSize;
            currentAmmoUI.text = weaponSO.magSize.ToString("D2");
            Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
            currentweapon = newWeapon;
            this.weaponSO = weaponSO;
        }
    }

    public void ChangeAmmo(int amount)
    {
        currentAmmo += amount;
        currentAmmoUI.text = currentAmmo.ToString("D2");
    }
}
