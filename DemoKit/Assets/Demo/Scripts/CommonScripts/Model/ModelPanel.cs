using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelPanel : MonoBehaviour {

    //private static ModelPanel _instance;

    
    //public static ModelPanel Instance {
    //    get
    //    {
    //        if (_instance==null)
    //        {
    //            _instance = new ModelPanel();
    //        }
    //        return _instance;
    //    }
        
    //}


    public List<IModelShow> modelArray;
    public IModelShow Engine;
    public IModelShow Heart;
    public IModelShow Earth;
    public IModelShow Shanghai;


    private void Start()
    {
        modelArray.RemoveAt(5);
        modelArray.RemoveAt(4);
        modelArray.RemoveAt(3);
        modelArray.RemoveAt(2);
        modelArray.RemoveAt(1);
        //for (int i = modelArray.Count-1; i >= 0; i--)
        //{

        //    modelArray.RemoveAt(i);
        //}
        Debug.Log("modelArray " + modelArray.Count);
        //modelArray.Add(Engine);
        //modelArray.Add(Heart);
        //modelArray.Add(Earth);
        //modelArray.Add(Shanghai);
        Debug.Log("modelArray COUNT " + modelArray.Count);
        for (int i = 1; i < modelArray.Count; i++)
        {
          

                modelArray[i].RenderShow(false);
        
            
        }
        modelArray[0].RenderShow(true);
    }
    private void Update()
    {
        
    }
}
