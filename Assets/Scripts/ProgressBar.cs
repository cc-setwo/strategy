using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {
    GameObject g;
	// Use this for initialization
	void Start () {
        g = GameObject.Find("Power");
        InvokeRepeating("ChangeSize", 0, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
       
	}
    bool l = true;
    void ChangeSize()
    {
        if (!l)
        {
            l = true;
            g.transform.localScale = new Vector3(1.2f, g.transform.localScale.y, g.transform.localScale.z);
        }
        if (g.transform.localScale.x == 0.02000063f||g.transform.localScale.x.ToString().Contains("0.0200"))
        {
            g.transform.localScale = new Vector3(0, g.transform.localScale.y, g.transform.localScale.z);
            l = false;
            return;
        }
        g.transform.localScale = new Vector3(g.transform.localScale.x - 0.02f, g.transform.localScale.y, g.transform.localScale.z);
    }
}
