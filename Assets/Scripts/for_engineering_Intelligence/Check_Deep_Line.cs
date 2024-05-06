using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Deep_Line : MonoBehaviour
{
    [SerializeField] private GameObject line;
    
    private Animator animation_Check;    
    private bool Is_Check;
   
    public delegate void Action_Status ();
    public event Action_Status  Action_Check;

    void Start() 
    { 
        animation_Check = this.GetComponent<Animator>();
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);
        if (Is_Check) return;
        Is_Check = true;       
        Material_Alpha_Set(line, 1f);        
        animation_Check.SetTrigger("set_deep");
        line.SetActive(false);
        // Вызвать событие, когда действие завершилось
        Action_Check?.Invoke();
    }

    public void Restart() 
    {
        Is_Check = false;         
        animation_Check.ResetTrigger("set_deep");
        line.SetActive(true);
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
