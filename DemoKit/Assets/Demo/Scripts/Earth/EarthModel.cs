using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthModel : IModelShow {


    public Action ShowAnimationHandler;


    public override void NextModelShow(IModelShow model, Transform trs)
    {
        Satellite.Play = false;
        base.NextModelShow(model, trs);
    }

    public override void ShowAnimation(IModelShow model)
    {
       
        switch (model.State)
        {
            case ModelState.None:          
                model.State = ModelState.State1;
                Satellite.Play = true;
                break;
            case ModelState.State1:
                model.State = ModelState.None;
                Satellite.Play = false;
                break;
            case ModelState.State2:
                break;
            case ModelState.Stop:
                break;
            default:
                break;
        }
 
        if (ShowAnimationHandler!=null)
        {
            ShowAnimationHandler();
        }
        
    }


    public override void Show(Transform trs)
    {
        Dis = 3f;
        base.Show(trs);
        ShowAnimation(this);
        HasNextState = false;
    }

}
