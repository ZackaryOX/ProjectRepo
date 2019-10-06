using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseHovor : MonoBehaviour
{
    
   
    public Material NewMat;
    public GameObject Object;
    public GameObject lookingAt;


    MeshRenderer Rend;
    Material OldMat;

    static bool mouse0down = false;
    static bool mouse1down = false;
    bool mouseOver = false;
    public static bool MovingStuff = false;
    public static GameObject ObjectMoving;


    void Awake()
    {
        //ObjectMoving = this.gameObject;
        Rend = GetComponent<MeshRenderer>();
        OldMat = Rend.material;
    }

    float ReturnGridPos(float x)
    {
        float gridtolockto = 0.25f;

        float posToSet = x;
        if (posToSet > 0)
        {
            posToSet /= gridtolockto;
            posToSet += 0.5f;
            float roundedX = (int)posToSet;
            roundedX *= gridtolockto;
            posToSet = roundedX;
        }
        else if (posToSet < 0)
        {
            posToSet /= gridtolockto;
            posToSet -= 0.5f;
            float roundedX = (int)posToSet;
            roundedX *= gridtolockto;
            posToSet = roundedX;
        }

        return posToSet;
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
                ObjectMoving = lookingAt;//this.gameObject;

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

            float XtoSet = newVec.x;
            float ZtoSet = newVec.z;

            newVec.x = ReturnGridPos(XtoSet);
            newVec.z = ReturnGridPos(ZtoSet);
            newVec.y = 1.08f;

            ObjectMoving.transform.position = newVec;

            if (Input.GetMouseButton(0) && !mouse0down)
            {
                mouse0down = true;
                Vector3 OldRot = ObjectMoving.transform.rotation.eulerAngles;
                OldRot.y += 90;
                ObjectMoving.transform.rotation = Quaternion.Euler(OldRot);
            }
            if (Input.GetMouseButtonUp(0))
            {
                mouse0down = false;
            }
            if (Input.GetMouseButton(1) && !mouse1down)
            {
                mouse1down = true;
                Vector3 OldRot = ObjectMoving.transform.rotation.eulerAngles;
                OldRot.y -= 90;
                ObjectMoving.transform.rotation = Quaternion.Euler(OldRot);
            }
            if (Input.GetMouseButtonUp(1))
            {
                mouse1down = false;
            }
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
