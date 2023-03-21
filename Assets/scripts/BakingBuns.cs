using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakingBuns : MonoBehaviour
{
    public float timming = 10;
    public float timeRemaining = 10;
    public bool ObjectInserted;
    public GameObject[] bulks;
    public GameObject bulk;
    public Material mat; 
    
    // Start is called before the first frame update
    void Start()
    {
        ObjectInserted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectInserted) {
            if (timeRemaining < 0)
            {
                ObjectInserted = false;
                timeRemaining = timming;
                //bulk = ;
                //2x obj x=1.212
                GameObject obj = Instantiate(bulk, new Vector3((float)5.063267, (float)0.7443826, (float)2.371027), Quaternion.identity);
                obj.GetComponent<MeshRenderer> ().material = mat;
            }
            timeRemaining -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bulks")
        {
            ObjectInserted = true;
            
            if (other.name.Split(" ")[0] == bulks[0].name) {
                bulk = bulks[0];
            } else {
                bulk = bulks[1];
            }
            
            Destroy(other.gameObject);
        }
    }
}
