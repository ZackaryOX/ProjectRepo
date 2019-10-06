using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;




abstract public class Command
{
    public Objects slot;
    public virtual void Execute()
    {
    }
    public void SetSlot(Objects temp)
    {
        this.slot = temp;
    }
}

public class UndoCommand : Command
{
    public UndoCommand(Objects temp) {
        this.SetSlot(temp);
    }

    public override void Execute()
    {
        Objects obj = this.slot;
        if (this.slot.UndoP.Count > 0)
        {
            obj.RedoP.Add(obj.Obj.transform.position);
            obj.RedoR.Add(obj.Obj.transform.rotation.eulerAngles);
            obj.Obj.transform.position = obj.UndoP[obj.UndoP.Count - 1];
            obj.Obj.transform.rotation = Quaternion.Euler(obj.UndoR[obj.UndoR.Count - 1]);
            obj.CurrentRecordedPos = obj.UndoP[obj.UndoP.Count - 1];
            obj.CurrentRecordedRot = obj.UndoR[obj.UndoR.Count - 1];
            obj.UndoP.RemoveAt(obj.UndoP.Count - 1);
            obj.UndoR.RemoveAt(obj.UndoR.Count - 1);
        }
    }


}

public class RedoCommand : Command
{
    
    public RedoCommand(Objects temp)
    {
        this.SetSlot(temp);
    }

    public override void Execute()
    {
        if (this.slot.RedoP.Count > 0)
        {
            this.slot.UndoP.Add(this.slot.Obj.transform.position);
            this.slot.UndoR.Add(this.slot.Obj.transform.rotation.eulerAngles);
            this.slot.Obj.transform.position = this.slot.RedoP[this.slot.RedoP.Count - 1];
            this.slot.Obj.transform.rotation = Quaternion.Euler(this.slot.RedoR[this.slot.RedoR.Count - 1]);
            this.slot.CurrentRecordedPos = this.slot.RedoP[this.slot.RedoP.Count - 1];
            this.slot.CurrentRecordedRot = this.slot.RedoR[this.slot.RedoR.Count - 1];
            this.slot.RedoP.RemoveAt(this.slot.RedoP.Count - 1);
            this.slot.RedoR.RemoveAt(this.slot.RedoR.Count - 1);

        }
    }


}

public class LogPosCommand : Command
{

    public LogPosCommand(Objects temp)
    {
        this.SetSlot(temp);
    }

    public override void Execute()
    {
        this.slot.UndoP.Add(this.slot.CurrentRecordedPos);
        this.slot.UndoR.Add(this.slot.CurrentRecordedRot);
        this.slot.CurrentRecordedPos = this.slot.Obj.transform.position;
        this.slot.CurrentRecordedRot = this.slot.Obj.transform.rotation.eulerAngles;
    }


}

public class ClearRedo : Command
{
    public ClearRedo(Objects temp)
    {
        this.SetSlot(temp);
    }

    public override void Execute()
    {
        if(this.slot.RedoP.Count > 0)
        {
            this.slot.RedoP.Clear();
            this.slot.RedoR.Clear();
        }


    }

}

public abstract class Objects
{
    public static int objectNumbr = 0;
    public int ID;
    public int typeID;
    public GameObject Obj;
    public List<Vector3> UndoP = new List<Vector3>() { };
    public List<Vector3> RedoP = new List<Vector3>() { };
    public List<Vector3> UndoR = new List<Vector3>() { };
    public List<Vector3> RedoR = new List<Vector3>() { };
    public Vector3 CurrentRecordedPos;
    public Vector3 CurrentRecordedRot;

    public Objects Clone()
    {
        Objects temp;
        temp = (Objects)this.MemberwiseClone();

        temp.ID = objectNumbr;
        GameObject newobj = MonoBehaviour.Instantiate(temp.Obj);
        newobj.transform.position = new Vector3(6.27f, 1.0f, 4.433f);
        newobj.name = this.Obj.name + temp.ID.ToString();
        temp.Obj = newobj;
        temp.typeID = this.typeID;
        temp.CurrentRecordedPos = newobj.transform.position;
        temp.CurrentRecordedRot = newobj.transform.rotation.eulerAngles;
        objectNumbr++;
        return temp;
    }
    
    ~Objects()
    {
    }
}






public class Wall : Objects
{
    public Wall()
    {
       

        GameObject newobject;
        newobject = GameObject.Find("Wall");
       
        newobject.transform.position = new Vector3(-1500, -1500, -1500);
        this.Obj = newobject;
        this.typeID = 1;

        
    }
}
public class Window : Objects
{
    public Window()
    {


        GameObject newobject;
        newobject = GameObject.Find("Window");
        newobject.transform.position = new Vector3(-1500, -1500, -1500);
        
        this.Obj = newobject;
        this.typeID = 2;
    }
}
public class Door : Objects
{
    public Door()
    {


        GameObject newobject;
        newobject = GameObject.Find("Door");
        newobject.transform.position = new Vector3(-1500, -1500, -1500);

        this.Obj = newobject;
        this.typeID = 3;
    }
}
public class ObjectManager
{
    public Wrapper saveload = new Wrapper();

    public List<Objects> AllObjects = new List<Objects>() { };
    public List<Objects> UndoObjects = new List<Objects>() { };
    public List<Objects> RedoObjects = new List<Objects>() { };
    public Dictionary<string, Objects> Prefabs = new Dictionary<string, Objects>();

    RemoteClass test = new RemoteClass();
    public ObjectManager()
    {
    }
    public void Undo()
    {
        
        if(UndoObjects.Count > 0)
        {
            test.SetCommand(new UndoCommand(this.UndoObjects[this.UndoObjects.Count - 1]));
            test.ButtonPressed();
            RedoObjects.Add(this.UndoObjects[this.UndoObjects.Count - 1]);
            UndoObjects.RemoveAt(this.UndoObjects.Count - 1);
            
        }
       
    }
    public void Redo()
    {
        
        if (RedoObjects.Count > 0)
        {
            test.SetCommand(new RedoCommand(this.RedoObjects[this.RedoObjects.Count - 1]));
            test.ButtonPressed();
            UndoObjects.Add(this.RedoObjects[this.RedoObjects.Count - 1]);
            RedoObjects.RemoveAt(this.RedoObjects.Count - 1);
        }
    }

    public void ClearRedo()
    {
        this.RedoObjects.Clear();
        for (int i = 0; i < this.AllObjects.Count; i++)
        {
            test.SetCommand(new ClearRedo(this.AllObjects[i]));
            test.ButtonPressed();
        }
    }
    public void LogPosition(Objects temp)
    {
        this.ClearRedo();
        this.UndoObjects.Add(temp);
        test.SetCommand(new LogPosCommand(temp));
        test.ButtonPressed();
        
    }

    public void SaveData()
    {
        saveload.ClearFile();
        for (int i = 0; i < AllObjects.Count; i++)
        {
            float x;
            float y;
            float z;
            float x2;
            float y2;
            float z2;
            int ID;

            Vector3 objposition = AllObjects[i].Obj.transform.position;
            Vector3 objrotation = AllObjects[i].Obj.transform.rotation.eulerAngles;
            x = objposition.x;
            y = objposition.y;
            z = objposition.z;
            x2 = objrotation.x;
            y2 = objrotation.y;
            z2 = objrotation.z;

            ID = int.Parse(AllObjects[i].typeID.ToString() + AllObjects[i].ID.ToString());
            saveload.SavePos(ID, x,y,z,x2,y2,z2);


        }


    }

    public void LoadData()
    {
        int lines = saveload.Count() -1;

        for (int i = 0; i < lines; i++)
        {
            saveload.LoadPos();
            string strID = saveload.ID.ToString();
            string type = strID[0].ToString();
            int typeid = int.Parse(type);
            Objects tempobj = objsetup(typeid);
            tempobj.Obj.transform.position = saveload.Pos;
            tempobj.Obj.transform.rotation = Quaternion.Euler(saveload.Rot);
           


        }
        saveload.SetLine(1);
    }

    public Objects FindObjectWithID(int ID)
    {
        for(int i = 0; i < AllObjects.Count; i++)
        {
            if(AllObjects[i].ID == ID)
            {

                return AllObjects[i];
            }
        }

        return null;
    }
    public Objects FindObjectWithName(string name)
    {
        for (int i = 0; i < AllObjects.Count; i++)
        {
            if (AllObjects[i].Obj.name == name)
            {

                return AllObjects[i];
            }
        }


        return null;
    }
    public int FindIndexWithID(int ID)
    {
        for (int i = 0; i < AllObjects.Count; i++)
        {
            if (AllObjects[i].ID == ID)
            {

                return i;
            }
        }


        return -1;
    }

    public Objects objsetup(int typeid)
    {
        Objects newobj;

        if (typeid == 2)
        {
            newobj = Prefabs["Window"].Clone();
        }
        else if (typeid == 3)
        {
            newobj = Prefabs["Door"].Clone();
        }
        else
        {
            newobj = Prefabs["Wall"].Clone();
        }
        AllObjects.Add(newobj);
        return newobj;
        
    }
    
}

public class RemoteClass
{
    Command slot;

    public RemoteClass()
    {

    }

    public void ButtonPressed()
    {
        slot.Execute();
    }

    public void SetCommand(Command temp)
    {
        slot = temp;
    }
}




public class ForDropDown : MonoBehaviour
{


    
    public static Material forclasses;
    public GameObject createButton;
    public GameObject deleteButton;
    public Material Hovermat;
    List<string> models = new List<string>() { "Wall", "Window", "Door" };
    public Dropdown drop;
    int index;
    ObjectManager SceneMgr = new ObjectManager();
    // Start is called before the first frame update
    void Start()
    {
        drop.AddOptions(models);
        forclasses = Hovermat;
        SceneMgr.Prefabs.Add("Wall", new Wall());
        SceneMgr.Prefabs.Add("Window", new Window());
        SceneMgr.Prefabs.Add("Door", new Door());

    }
    public void Create()
    {
        SceneMgr.objsetup(index + 1);
    }

    public void Save()
    {
        SceneMgr.SaveData();
    }

    public void Load()
    {
        SceneMgr.LoadData();
    }
    public void Delete(string objname)
    {
        Objects temp = SceneMgr.FindObjectWithName(objname);
        Destroy(temp.Obj);
        SceneMgr.AllObjects.RemoveAt(SceneMgr.FindIndexWithID(temp.ID));
    }
    public void setOption()
    {
        index = drop.value - 1;

        
        if(index >= 0)
        {
            createButton.SetActive(true);
            deleteButton.SetActive(true);
        }
        else
        {
            createButton.SetActive(false);
            deleteButton.SetActive(false);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (mouseHovor.MovingStuff)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                string objtofind = mouseHovor.ObjectMoving.name;
                Objects temp = SceneMgr.FindObjectWithName(objtofind);
                SceneMgr.LogPosition(temp);


            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                string objtofind = mouseHovor.ObjectMoving.name;
                mouseHovor.MovingStuff = false;
                Delete(objtofind);


            }

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneMgr.Undo();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneMgr.Redo();
        }
    }
}
