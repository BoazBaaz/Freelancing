using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceClicj : MonoBehaviour
{
    [SerializeField]
    private GameObject Cube;

    private Vector2 mousePos;

    [SerializeField]
    private LayerMask allTilesLayer;
          
    public void Spawn(Vector3 position)
    {
        Instantiate(Cube).transform.position = position;
    }


    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);

        //    Vector3 adjustZ = new Vector3(worldPoint.x, worldPoint.y, Cube.transform.position.z);

        //    Spawn(adjustZ);
        //}


        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseRay = Camera.main.ScreenToWorldPoint(transform.position);
            RaycastHit2D rayHit = Physics2D.Raycast(mouseRay, Vector2.zero, Mathf.Infinity, allTilesLayer);
            if (rayHit.collider != null)
            { 
                if (rayHit.collider.gameObject.tag == "GrassTile" && this.gameObject.tag == "HouseTemplate")
                {
                    Instantiate(Cube, transform.position, Quaternion.identity);
                }
            }
           
            else if (rayHit.collider == null && this.gameObject.tag == "GrassTemplate")
            {
                Instantiate(Cube, transform.position, Quaternion.identity);
            }
        }

    }
}
