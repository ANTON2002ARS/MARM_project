using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Klick : MonoBehaviour
{
    public int is_Number_Span_of_model { set; private get; }
    [SerializeField] private Action_build action_build;
    [SerializeField] private GameObject model_children;
    [SerializeField] private List<GameObject> children_additional;
    public static Object_Klick Instance_Object_Klick { set; get; }
    private void Awake() => Instance_Object_Klick = this;

    public bool Can_Set = true;
    public void Active_Body_Object(bool _is_off) 
    {
       /* if (Can_Set != true)
            return; */           
        model_children.SetActive(_is_off);
        this.GetComponent<BoxCollider>().isTrigger = !_is_off;
    }


    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);
        //model_children.SetActive(true);
        if (GameManager.Instance.Number_Span > is_Number_Span_of_model)
            Active_Body_Object(true);

        this.GetComponent<BoxCollider>().isTrigger = false;
        if(action_build.Use_Add_Action)
            GameManager.Instance.Status_Action.Add(action_build);

        if (GameManager.Instance.is_learning_Mode)
        {
            GameManager.Instance.Show_Learn_Text(action_build.Name_Object + "\n" + action_build.Use_Object);
        }

        foreach (var item in children_additional)
            if (item != null)
                item.GetComponent<Object_Klick>().Can_Set = true;
    }

    public void Start_Test_Mode(bool is_Mode)
    {
        foreach (var add in children_additional)
            if(add != null)
            {
                Object_Klick k = add.GetComponent<Object_Klick>();
                k.Can_Set = is_Mode;
                k.Active_Body_Object(!is_Mode);
                
            }
                   
    }


}
