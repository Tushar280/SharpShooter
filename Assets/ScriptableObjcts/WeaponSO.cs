using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public int damage;
    public float firerate;
    public float magSize;
    public GameObject weaponPrefab;
    public bool canZoom;
    public float zoomFov;
    
}
