using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float Leigth = 30;
    Camera fps_cam;

    public static float Sensitivity; //250
    [SerializeField] private Transform _character;
    public bool can_rotation;
    private float _xRotation;

    void Start()
    {
        if (Sensitivity < 1)
            Sensitivity = 250;
        fps_cam = this.GetComponent<Camera>();
        can_rotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {   
        Tracking();        
    }

    private void Tracking()
    {
        if (!can_rotation)
            return;
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _character.Rotate(Vector3.up * mouseX);       
    }

    public GameObject Select_obj()
    {
        Vector3 line_Origin = fps_cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Vector3 End_Line = fps_cam.transform.forward * Leigth;
        Ray R = new Ray(line_Origin, End_Line);
        Debug.DrawLine(line_Origin, End_Line, Color.black);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(R, out hit, Leigth))
        {
            GameObject game = hit.collider.gameObject;
            return game;
        }
        return null;
    }
}