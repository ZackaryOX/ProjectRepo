using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseHovor : MonoBehaviour
{
    
   
    public Material NewMat;
    public GameObject Object;
    public GameObject lookingAt;

    Renderer Rend;
    Material OldMat;


    bool mouseOver = false;
    public static bool MovingStuff = false;
    public static GameObject ObjectMoving;


    void Awake()
    {
        ObjectMoving = this.gameObject;
        Rend = GetComponent<Renderer>();
        OldMat = Rend.material;
    }

    void Update()
    {
        lookingAt = GameObject.Find(rayFromCamera.lookingAt);
        

        if (mouseOver && !MovingStuff)
        {

            Rend.material = NewMat;
            if (Input.GetKey(KeyCode.E))
            {
                MovingStuff = true;
                ObjectMoving = this.gameObject;

            }
        }

        if (MovingStuff)
        {
            if (Input.GetKeyUp(KeyCode.E)) {
                MovingStuff = false;
                return;
            }
            Vector3 worldpos = new Vector3(0, 0, 5);

            Vector2 mousePos = Input.mousePosition;
            worldpos.x = mousePos.x;
            worldpos.y = mousePos.y;
            Vector3 newVec = Camera.main.ScreenToWorldPoint(worldpos);
            gameObject.transform.position = newVec;
        }
    }

    void OnMouseOver()
    {
        lookingAt = GameObject.Find(rayFromCamera.lookingAt);
        mouseOver = true;
        

    }



    void OnMouseExit()
    {

        mouseOver = false;
        if (!MovingStuff)
        {
            Rend.material = OldMat;
        }
        

    }

}
