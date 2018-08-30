using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModelState
{
    None,
    State1,
    State2,
    Stop,
}

public abstract class IModelShow:MonoBehaviour  {

    protected ModelState state = ModelState.None;
    public ModelState State { get { return state; } set { state = value; } }
    private Renderer[] render;
    protected  float yangle =0 ;
    protected float Dis = 3f;
    protected float YHight = 0f;
    protected bool hasNextState = true;

    public bool HasNextState
    {
       get { return hasNextState; }
       protected set { hasNextState = value; }
    }

    public  Renderer[] Render
    {
        get
        {
            if (render == null)
            {
                render = this.GetComponentsInChildren<Renderer>();
            }
            return render;
        }
    }

    public  virtual void NextModelShow(IModelShow model,Transform trs)
    {
        RenderShow(false);
        model.Show(trs);
       
        StartCoroutine(ModelScalChange(Vector3.one,model));
    }

    IEnumerator ModelScalChange(Vector3 scal,IModelShow model)
    {
        model.transform.localScale = Vector3.zero;
        float dis = Vector3.Distance(model.transform.localScale,scal);
        while (dis>0.02f)
        {
            model.transform.localScale += new Vector3(scal.x- model.transform.localScale.x, scal.y - model.transform.localScale.y, scal.z- model.transform.localScale.z)*0.1f;
            //model.transform.localScale = Vector3.Lerp(model.transform.localScale,scal,Time.fixedDeltaTime*1.5f);
            dis = Vector3.Distance(model.transform.localScale, scal);
            yield return new WaitForFixedUpdate();
        }

    }

    public abstract void ShowAnimation(IModelShow model);


    public virtual void Show(Transform trs)
    {
        RenderShow(true);
        Vector3 forward = trs.forward * Dis;
        forward.y = 0;
        transform.position = new Vector3(trs.position.x,trs.position.y+YHight, trs.position.z) + forward;//+trs.up*YHight;
       transform.rotation = Quaternion.Euler(0, trs.eulerAngles.y + yangle, 0);
       State = ModelState.None;
    }
        

    public void RenderShow(bool Show = false)
    {

        for (int i = 0; i < Render.Length; i++)
        {
            if (Render[i]==null)
            {
                continue;
            }
            Render[i].enabled = Show;
        }
    }

}
