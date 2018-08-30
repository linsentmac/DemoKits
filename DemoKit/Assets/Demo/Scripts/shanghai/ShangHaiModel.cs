using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShangHaiModel : IModelShow {

    public GameObject info1;
    public GameObject info2;

    public override void NextModelShow(IModelShow model, Transform trs)
    {
        info1.SetActive(false);
        info2.SetActive(false);
        base.NextModelShow(model, trs);
        HasNextState = true;
    }


    public override void ShowAnimation(IModelShow model)
    {
        switch (model.State)
        {
            case ModelState.None:
                model.State = ModelState.State1;
               
                break;
            case ModelState.State1:
                info1.SetActive(true);
                info2.SetActive(false);
                //model.State = ModelState.State2;
                model.State = ModelState.None;
                HasNextState = false;
                break;
            case ModelState.State2:
                info1.SetActive(false);
                info2.SetActive(true);
                model.State = ModelState.None;
                HasNextState = false;
                break;
            case ModelState.Stop:
                break;
            default:
                break;
        }
    }

    public override void Show(Transform trs)
    {
        YHight = -0.4f;
        Dis =2.86f;
        base.Show(trs);
        ShowAnimation(this);
       
    }

}
