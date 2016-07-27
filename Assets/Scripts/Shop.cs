using UnityEngine;
using System.Collections;


public class Shop : MonoBehaviour
{
    public GameObject g;
    public GameObject closeButton;
    public Camera mainCamera;
    GameObject current;
    public Material RedMaterial;
   // public GameObject b;
    void Start()
    {

    }
   
    // Update is called once per frame
    void Update()
    {
       
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
     
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition;
            targetPosition = hit.point;

            if (current != null)
            {
             //   current.transform.position = targetPosition;
                current.transform.position = targetPosition;
                current.transform.position = new Vector3(current.transform.position.x,0,current.transform.position.z);
                CameraScript.ManulCoordinates = current.transform.position;
                if (Input.GetMouseButton(0))
                {
                    GameObject t = current;
                    float closestdistance = Mathf.Infinity;
                    GameObject closestObject = null;
                    GameObject[] meshGameObjects=new GameObject[2500];
                    for (int i = 0; i < 2500; i++)
                    {
                        meshGameObjects[i] = GameObject.Find(i.ToString());
                    }
                    foreach (GameObject empty in meshGameObjects)
                    {
                        float distance = Vector3.Distance(targetPosition, empty.transform.position);
                        if (distance < closestdistance) // or <= ,i will explain 2 cases.
                        {
                            closestdistance = distance;
                            closestObject = empty;
                        }

                    }
                    Debug.Log(closestObject.GetComponent<Renderer>().material.name);
                    if (closestObject.GetComponent<Renderer>().material.name == "Red (Instance)"|| closestObject.GetComponent<Renderer>().material.name == "Red")
                    {
                        Debug.Log("NEIN!");
                        return;

                    }
                   
                    closestObject.GetComponent<Renderer>().material = RedMaterial;
                    t.transform.position = closestObject.transform.position;
                    current = null;
                   
                }
            }
        }
    
    }
    public void OpenShopPanel()
    {
        closeButton.SetActive(true);
        if (!g.active)
        {
            g.SetActive(true);
        //    b.SetActive(true);
        }
        else
            g.SetActive(false);
    }
    public void CloseShop()
    {

      //  b.SetActive(false);
        g.SetActive(false);
        closeButton.SetActive(false);
    }
    public void Spawn(int id)
    {
       // b.SetActive(false);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition;
            targetPosition = hit.point;

           
            if (id == 1)
            {
                CloseShop();
                current = (GameObject)Instantiate(Resources.Load("Grass1Shop"), new Vector3(targetPosition.x, 0, targetPosition.z), Quaternion.identity);
                current.transform.position = targetPosition;
                current.name = "Manual_grass" + id.ToString();

            }
            if (id == 2)
            {
                CloseShop();
                current = (GameObject)Instantiate(Resources.Load("Tree1"), new Vector3(targetPosition.x, 0, targetPosition.z), Quaternion.identity);
                current.transform.position = targetPosition;
                current.name = "Manual_Tree1" + id.ToString();

            }
            if (id == 3)
            {
                CloseShop();
                current = (GameObject)Instantiate(Resources.Load("Tree2"), new Vector3(targetPosition.x, 0, targetPosition.z), Quaternion.identity);
                current.transform.position = targetPosition;
                current.name = "Manual_Tree2" + id.ToString();

            }
        }

        
    }
   

}

