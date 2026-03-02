using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2.5f;

    [Header("Mouse Look")]
    public float mouseSensitivity = 120f;
    public Transform cam;

    CharacterController cc;
    float pitch = 0f;

    bool lookEnabled = false;

    void Start()
    {
        cc = GetComponent<CharacterController>();

        // Começa com cursor livre (não olha)
        SetCursorLocked(false);

        // Começa olhando reto
        pitch = 0f;
        if (cam != null) cam.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void Update()
    {
        // RMB ativa o modo olhar (segurando ou clicando; aqui é "segurar")
        if (Input.GetMouseButtonDown(1))
        {
            lookEnabled = true;
            SetCursorLocked(true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            lookEnabled = false;
            SetCursorLocked(false);
        }

        // ESC sempre libera
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            lookEnabled = false;
            SetCursorLocked(false);
        }

        // Movimento (WASD) pode ficar sempre ligado (ou você pode bloquear também)
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = (transform.right * h + transform.forward * v) * moveSpeed;
        cc.SimpleMove(move);

        // Só olha se lookEnabled = true
        if (lookEnabled && cam != null)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            pitch -= mouseY;
            pitch = Mathf.Clamp(pitch, -80f, 80f);

            cam.localRotation = Quaternion.Euler(pitch, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }

    void SetCursorLocked(bool locked)
    {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
    }
}