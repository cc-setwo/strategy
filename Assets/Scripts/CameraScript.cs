using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    int edgeBoundary = 10;
    RaycastHit hit;
    private float raycastLength = 500;
    public static Vector3 ManulCoordinates;





    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;
    float z = 0.0f;
    // Use this for initialization
    void Start()
    {
       
    }
    void LeftMouseDrag()
    {
        
        current_position.z = hit_position.z = camera_position.y;

       
        Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);

       
        direction = direction * -1;

        Vector3 position = camera_position + direction;

        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit_position = Input.mousePosition;
            camera_position = transform.position;

        }
        if (Input.GetMouseButton(0))
        {
            current_position = Input.mousePosition;
            LeftMouseDrag();
        }
        Ray ray = transform.GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, raycastLength))
        {
           
            if (hit.collider.name == "Terrain" || hit.collider.name == "Plane(Clone)" || IsNumeric(hit.collider.name))
            {

                if (Input.mousePosition.y < Screen.height / edgeBoundary)
                    transform.position += new Vector3(0, 0, -1f);


                if (Input.mousePosition.y > Screen.height - Screen.height / edgeBoundary)
                    transform.position += new Vector3(0, 0, 1f);


                if (Input.mousePosition.x < Screen.width / edgeBoundary)
                    transform.position += new Vector3(-1f, 0, 0);


                if (Input.mousePosition.x > Screen.width - Screen.width / edgeBoundary)
                    transform.position += new Vector3(1f, 0, 0);

            }
            else if (hit.collider.name.Contains("Manual") || hit.collider.name.Contains("Grass"))
            {

                if (ManulCoordinates.x <= 500 && ManulCoordinates.x >= 0 && ManulCoordinates.z <= 500 && ManulCoordinates.z >= 0)
                {
                    if (Input.mousePosition.y < Screen.height / edgeBoundary)
                        transform.position += new Vector3(0, 0, -1f);


                    if (Input.mousePosition.y > Screen.height - Screen.height / edgeBoundary)
                        transform.position += new Vector3(0, 0, 1f);


                    if (Input.mousePosition.x < Screen.width / edgeBoundary)
                        transform.position += new Vector3(-1f, 0, 0);


                    if (Input.mousePosition.x > Screen.width - Screen.width / edgeBoundary)
                        transform.position += new Vector3(1f, 0, 0);
                }
            }
        }
     

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) 
        {
            
            if (transform.position.y <= 50 )
                return;
            transform.position = new Vector3(transform.position.x, transform.position.y - 5,transform.position.z);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) 
        {
           
            if (transform.position.y >= 120)
                return;
            transform.position = new Vector3(transform.position.x, transform.position.y + 5,transform.position.z);
        }
        if (Input.GetMouseButtonDown(2))
        {
           
            transform.position = new Vector3(transform.position.x,85.5f,transform.position.z);
        }

        
       
    }
    public  bool IsNumeric(this string s)
    {
        float output;
        return float.TryParse(s, out output);
    }
}