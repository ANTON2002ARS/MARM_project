using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Lighthouse : MonoBehaviour
{
    [SerializeField] private int number_beacon;
    [SerializeField] private GameObject beacon;
    [SerializeField] private GameObject flage;

    public bool Is_set_beacon { get; private set; }
    public delegate void Action_Beacon(int number);
    public event Action_Beacon call_check_beacon;
    private Animator animator_beacon;

    private void Start() 
    {
        animator_beacon = GetComponent<Animator>();
    }
   
    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);         
        if (Is_set_beacon)
            return;
        Is_set_beacon = true;
        animator_beacon.SetTrigger("set_beacon");
        flage.SetActive(false);
        beacon.SetActive(true);
        // Вызвать событие, когда действие завершилось
        call_check_beacon?.Invoke(number_beacon);
    } 

    public void Restart() 
    { 
        Is_set_beacon = false;
        if(animator_beacon != null)
            animator_beacon.ResetTrigger("set_beacon");
        else
        {
            animator_beacon = GetComponent<Animator>();
            animator_beacon.ResetTrigger("set_beacon");
        }
        flage.SetActive(true);
        beacon.SetActive(false);         
    }
        
}
