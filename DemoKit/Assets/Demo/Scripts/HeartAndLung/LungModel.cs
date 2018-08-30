using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungModel : IModelShow {

    public override void ShowAnimation(IModelShow model)
    {
        switch (model.State)
        {
            case ModelState.None:
                model.State = ModelState.State1;
                break;
            case ModelState.State1:
                model.State = ModelState.None;
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
        Dis = 1.7f;
        base.Show(trs);
        ShowAnimation(this);
        HasNextState = false;
    }
}
