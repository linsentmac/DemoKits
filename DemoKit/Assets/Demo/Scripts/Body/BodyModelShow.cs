using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyModelShow : IModelShow {

    [SerializeField]
    private Transform Nervous_System;

    [SerializeField]
    private Transform CardioVascular;



    public override void NextModelShow(IModelShow model, Transform trs)
    {
        HasNextState = true;
        Nervous_System.localPosition = Vector3.zero;
        CardioVascular.localPosition = Vector3.zero;
 

       base.NextModelShow(model, trs);
        State = ModelState.None;
       
    }

    public override void ShowAnimation(IModelShow model)
    {
       
        switch (model.State)
        {
            case ModelState.None:             
                model.State = ModelState.State2;
                HasNextState = false;
                break;
            case ModelState.State1:             
                model.State = ModelState.State2;
                break;
            case ModelState.State2:
                model.State = ModelState.State1;
               
                break;
            case ModelState.Stop:
                break;
            default:
                break;
        }
    }


    private void FixedUpdate()
    {
        switch (State)
        {
            case ModelState.None:
               
                break;
            case ModelState.State1:
                Nervous_System.localPosition = Vector3.Lerp(Nervous_System.localPosition, new Vector3(0, 0, 0), Time.fixedDeltaTime * 2);
                CardioVascular.localPosition = Vector3.Lerp(CardioVascular.localPosition, new Vector3(0, 0, 0), Time.fixedDeltaTime * 2);
             
                break;
            case ModelState.State2:        
                Nervous_System.localPosition = Vector3.Lerp(Nervous_System.localPosition, new Vector3(-1.2f, 0, 0), Time.fixedDeltaTime * 2);
                CardioVascular.localPosition = Vector3.Lerp(CardioVascular.localPosition, new Vector3(1.2f, 0, 0), Time.fixedDeltaTime * 2);
                break;
            case ModelState.Stop:
                break;
            default:
                break;
        }
    }

    public override void Show(Transform trs)
    {
        Dis = 2f;
        base.Show(trs);
    }

}
