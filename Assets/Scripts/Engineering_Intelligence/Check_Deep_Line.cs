using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Deep_Line : MonoBehaviour
{
    private Animator animation_Check;
    [SerializeField] private GameObject line;
    public bool Is_Check { private set; get; }
   

    public delegate void ActionComplete(bool is_beacon);
    public event ActionComplete OnActionComplet;

    void Start() 
    { 
        animation_Check = this.GetComponent<Animator>();
       // animation_Check.enabled = false;
        Is_Check = false;        
        Material_Alpha_Set(line, 0.2f);
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);
        if (Is_Check) return;
        Is_Check = true;       
        Material_Alpha_Set(line, 1f);
        //animation_Check.enabled = true;       
        //animation_Check.Play("Animation_Check");
        animation_Check.SetBool("Check", true);
        // Вызвать событие, когда действие завершилось
        OnActionComplet?.Invoke(false);
    
    }
    public void Restart() 
    {
        Is_Check = false;
        // animation_Check.enabled = Is_Check;
        animation_Check.SetBool("Check", false);
        line.SetActive(!Is_Check);
        Material_Alpha_Set(line, 0.2f);        
    }

    private void Material_Alpha_Set(GameObject gameObject, float alpha)
    {
        Material newMat = new Material(gameObject.GetComponent<Renderer>().material);
        Color color = newMat.color;
        color.a = alpha;
        newMat.color = color;
        gameObject.GetComponent<Renderer>().material = newMat;
    }
}
