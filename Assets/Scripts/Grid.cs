using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

   public Dictionary<int, bool> dic;
    bool isEnbledd = true;
    // Use this for initialization
    public GameObject prefab;
   
    void Awake()
    {

        dic = new Dictionary<int, bool>();
        Vector3 v = new Vector3(5, 0, 5);
        Vector3 dwn=new Vector3(15, 0, 5);
        Vector3 up = new Vector3(5, 0, 15);

        int idd = 0;
        for (int i = 1; i < 50; i++)
        {
            Instantiate(prefab, new Vector3(v.x , 0.1f, v.z), Quaternion.identity).name=idd.ToString();
            idd++;
            dic.Add(idd, true);
           
            for (int k = 0; k < i; k++)
            {
                int incr = 10 * k;
               
                Instantiate(prefab, new Vector3(dwn.x, 0.1f, incr + dwn.z), Quaternion.identity).name = idd.ToString();
                idd++;
                dic.Add(idd, true);
               


                Instantiate(prefab, new Vector3(incr+up.x, 0.1f, up.z), Quaternion.identity).name = idd.ToString();
                idd++;
                dic.Add(idd, true);
               

            }
            dwn.x += 10;
            up.z += 10;
            v = new Vector3(v.x+10f, 0.1f, v.z+10f);
        }
        Instantiate(prefab, new Vector3(v.x, 0.1f, v.z), Quaternion.identity).name = idd.ToString();
        idd++;
        dic.Add(idd, true);
      
    }



	
	// Update is called once per frame
	void Update () {



      
        
    }
    public void TrunOnGrid()
    {
        Debug.Log(dic.Count.ToString());
        if (isEnbledd)
        {
            for (int i = 0; i < dic.Count; i++)
            {

                GameObject g = GameObject.Find(i.ToString());
                g.GetComponent<Renderer>().enabled = true;
            }
            isEnbledd = false;
        }
        else
        {
            for (int i = 0; i < dic.Count; i++)
            {

                GameObject g = GameObject.Find(i.ToString());
                g.GetComponent<Renderer>().enabled = false;
            }
            isEnbledd = true;
        }

    }
}

