using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class One_span_Deep : MonoBehaviour
{
    [SerializeField] private float deep;
    [SerializeField] private int number_span;
    [SerializeField] private Check_Deep_Line[] one_line_deep = new Check_Deep_Line[4];
   // [SerializeField] private TextMeshPro text;

    private int count_line;    

    public delegate void Action_Span(int number_span);
    public event Action_Span One_Span_Deep;

    private void Start()
    {
        Add_Action();
    }

    public void Restart()
    {
        count_line = 0;
        //Close_Text();
        foreach (var line in one_line_deep)
        {
            line.Restart();
        }
    }

    public void Check_Deep()
    {
        count_line++;
        if(count_line == one_line_deep.Length)
        {
            //text.enabled = true;
            // text.text = "Глубина реки  на участке: " + deep.ToString();
            // Invoke("Close_Text", 2f);
            Player.Instance_P.Show_Error("Глубина реки  на участке: " + deep.ToString());
            One_Span_Deep?.Invoke(number_span);
        }
    }
    
    //private void Close_Text() => text.enabled = false;

    private void Add_Action()
    {
        foreach (var line in one_line_deep)
        {
            line.Action_Check += Check_Deep;
        }
    }
}
