using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceClicj : MonoBehaviour
{
    public GameObject Cube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Spawn(Vector3 position)
    {
        Instantiate(Cube).transform.position = position;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);

            Vector3 adjustZ = new Vector3(worldPoint.x, worldPoint.y, Cube.transform.position.z);

            Spawn(adjustZ);
        }
    }
}
