using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Lighthouse : MonoBehaviour
{
    [SerializeField] private GameObject beacon;
    [SerializeField] private GameObject flage;
    public bool Is_set_beacon { private set; get; }
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
        // ������� �������, ����� �������� �����������
        OnActionComplet?.Invoke(true);
    } 

    public void Restart() 
    { 
        Is_set_beacon = false;
        Set_Beacon(Is_set_beacon);
    }
    
    private void Set_Beacon(bool active)
    {       
        beacon.SetActive(active);
        flage.SetActive(!active);
    }
}
