using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPopulationModel : IModelShow {

    public override void NextModelShow(IModelShow model, Transform trs)
    {
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
    }
    public override void Show(Transform trs)
    {
        Dis = 2.9f;
        base.Show(trs);
        ShowAnimation(this);
        HasNextState = false;
    }

}
