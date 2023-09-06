using UnityEngine;

public class RTSCamera : MonoBehaviour
{
    public float panSpeed = 20.0f;
    public float panBorderThickness = 10.0f;
    public Vector2 panLimit;
    public float scrollSpeed = 20.0f;

    public float minY = 20.0f;
    public float maxY = 100.0f;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 pos = transform.position; 

        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;    
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100.0f * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);
        transform.position = pos;
    }
}
