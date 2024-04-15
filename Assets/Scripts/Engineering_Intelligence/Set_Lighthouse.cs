using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Lighthouse : MonoBehaviour
{
    [SerializeField] private GameObject beacon;
    [SerializeField] private GameObject flage;
    public bool Is_set_beacon { private set; get; }
    public void Restars() => Is_set_beacon = false;

    public delegate void ActionComplete(bool is_beacon);
    public event ActionComplete OnActionComplet;

    private void Start() => Set_Beacon(false);
   
    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);
         if (Is_set_beacon)
            return;
        Is_set_beacon = true;
        Set_Beacon(true);
        // Вызвать событие, когда действие завершилось
        OnActionComplet?.Invoke(true);
    }    

    private void Set_Beacon(bool active)
    {       
        beacon.SetActive(active);
        flage.SetActive(!active);
    }
}
