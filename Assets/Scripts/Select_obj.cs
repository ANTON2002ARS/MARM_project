using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_obl : MonoBehaviour
{
    float Legth = 10;
    Camera fps_cam;

    private void Start()
    {
        fps_cam = this.GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 line_Origin = fps_cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        Vector3 End_Line = fps_cam.transform.position * Legth;

        Ray R = new Ray(line_Origin, End_Line);

        RaycastHit hit = new RaycastHit();

        if(Physics.Raycast(R, out hit, Legth))
        {
            GameObject game = hit.collider.gameObject;

            if (gameObject != null)
                gameObject.SetActive(false);
        }
    }
}
