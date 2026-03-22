using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Start()
    {
        // MỞ KHÓA CHUỘT
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }
}
