using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
    public int amountOfFirstTree;
    public int amountOfSecondTree;
    public int amountOfGrass;
    public float RandomRangeMin;
    public float RandomRangeMax;
    public Material RedMaterial;
    void Awake()
    {
       
    }
	// Use this for initialization
	void Start () {
        int id = 0;
        for (int i = 0; i < amountOfFirstTree; i++)
        {
            int RandCell = Random.Range(0, 2500);
            GameObject g = GameObject.Find(RandCell.ToString());
            g.GetComponent<Renderer>().material = RedMaterial;
            id = i;
            Instantiate(Resources.Load("Tree1"), new Vector3(g.transform.position.x, 0, g.transform.position.z), Quaternion.identity).name = "t1_" + i.ToString();
        }
        id++;
        
        int idsec = 0;
        for (int i = id; i < amountOfSecondTree + id; i++)
        {
            int RandCell = Random.Range(0, 2500);
            GameObject g = GameObject.Find(RandCell.ToString());
            g.GetComponent<Renderer>().material = RedMaterial;
            idsec = i;
            Instantiate(Resources.Load("Tree2"), new Vector3(g.transform.position.x, 0, g.transform.position.z), Quaternion.identity).name = "t2_" + i.ToString();
        }
        int idgrass = idsec;
        for (int i = idsec; i < amountOfGrass + idsec; i++)
        {
            int RandCell = Random.Range(0, 2500);
            GameObject g = GameObject.Find(RandCell.ToString());
            g.GetComponent<Renderer>().material = RedMaterial;
            id = i;
            Instantiate(Resources.Load("Grass1"), new Vector3(g.transform.position.x, 0, g.transform.position.z), Quaternion.identity).name = "g1_" + i.ToString();
        }
       
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
