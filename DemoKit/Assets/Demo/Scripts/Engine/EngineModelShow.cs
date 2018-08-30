using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineModelShow : IModelShow {

    private Animator EngineAnimaotr;

    

    private void Awake()
    {
        EngineAnimaotr = this.GetComponentInChildren<Animator>();
    }



    public override void NextModelShow(IModelShow model, Transform  tra)
    {
        HasNextState = true;
        EngineAnimaotr.SetBool("Play", false);     
        base.NextModelShow(model, tra);
        
    }



    public override void ShowAnimation(IModelShow model)
    {
        switch (model.State)
        {
            case ModelState.None:
                EngineAnimaotr.SetBool("Play", true);
                model.State = ModelState.State1; 
                HasNextState = false;             
                break;
            case ModelState.State1:
                EngineAnimaotr.SetBool("Play",false);
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




}
