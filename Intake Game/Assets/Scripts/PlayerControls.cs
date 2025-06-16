using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] Transform Camera;
    
    [Space]
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float stamina = 100f;

    float rotation = 0f;
    float timer;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        timer = Time.time;
    }

    void Update()
    {
        Rotation();
        Movement();
    }
    private void Rotation()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);

        rotation = Mathf.Clamp(rotation - Input.GetAxis("Mouse Y"), -90, 90);
        Camera.localEulerAngles = new Vector3(rotation, 0, 0);
    }

    bool AbleToRun;
    void Movement()
    {
        float walkSpeed;

        if (stamina <= 0)
        {
            AbleToRun = false;
        }
        else if (stamina >= 5) AbleToRun = true;

        if (Input.GetKey(KeyCode.LeftShift) && AbleToRun)
        {
            walkSpeed = moveSpeed * 2;
            if (timer <= Time.time - 0.1f)
            {
                stamina -= 0.1f;
                timer = Time.time;
            }
         
        }
        else
        {
            walkSpeed = moveSpeed;

            if (timer <= Time.time - 0.1f && stamina < 10)
            {
                stamina += 0.1f;
                timer = Time.time;
            }
        }

        transform.Translate(Input.GetAxis("Horizontal") * walkSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * walkSpeed * Time.deltaTime);
    }
}