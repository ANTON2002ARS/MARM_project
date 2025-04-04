using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engineering_Intelligencs_Line : MonoBehaviour
{
    [SerializeField] private bool is_review;
    public bool is_set { private set; get; }
    [SerializeField] private Mistake_build mistake;
    public Mistake_build Get_Mistake => mistake;
    private Animator animator_line;

    private void Start()
    {
        animator_line = GetComponent<Animator>();
        if(is_review)
            animator_line.SetTrigger("is_pull_up");
    }
    
    public void On_Click()
    {
        if (is_review)
            return;        
        is_set = true;
        animator_line.SetTrigger("is_pull_up");  
    }        
}
