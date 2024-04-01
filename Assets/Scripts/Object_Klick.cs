using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Klick : MonoBehaviour
{
    public int is_Number_Span_of_model { set; private get; }
    [SerializeField] private Action_build action_build;
    [SerializeField] private GameObject model_children;
    [SerializeField] private List<GameObject> children_additional;
   
    
    // Можем ли установить обьект\\
    public bool Can_Set = true;
    private bool is_set;
    // Для проверки  установлен ли обьект и устанавливаем его\\
    public bool Check_Set 
    { 
        private set 
        {
            if (!Can_Set) return;
            Enable_Modeil(value);
            is_set = value; 
        }
        get => is_set;
    }

    private void Enable_Modeil(bool enable)
    {
        model_children.SetActive(enable);
        this.GetComponent<BoxCollider>().isTrigger = !enable;
    }

    public void is_children_madeil(bool is_Mode)
    {
        Can_Set = !is_Mode;
        Enable_Modeil(!is_Mode); 
    }
    // true = test || false = not test\\
    public void Start_Test_Mode(bool is_Mode)
    {
        this.Check_Set = !is_Mode;
        foreach (var add in children_additional)
            if(add != null)
                add.GetComponent<Object_Klick>().is_children_madeil(is_Mode);        
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);
        Learn_Mode();      
        // Если устанавливаем детали у того который поставлен\\
        if (GameManager.Instance.Number_Span > is_Number_Span_of_model)
        { 
            Check_Set = true;
            foreach (var item in children_additional)
                if (item != null)
                    item.GetComponent<Object_Klick>().Can_Set = true;
        }           
    }

    private void Learn_Mode()
    {
        // Если нужно добавляем действие в список\\
        var gameManager = GameManager.Instance;
        if(action_build.Use_Add_Action)
            gameManager.Status_Action.Add(action_build);
        // Открываем окно информации у игрока\\
        if (gameManager.is_learning_Mode)
            gameManager.Show_Learn_Text(action_build.Name_Object + "\n" + action_build.Use_Object);     
    }



    


}
