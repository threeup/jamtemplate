using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Controller
{
    
    public override void Awake()
    {
        base.Awake();
        Program.Instance.Humans.Add(this);
    }
    
    public override void Die()
    {
        Program.Instance.Controllers.Remove(this);
        Program.Instance.Humans.Remove(this);
        Destroy(this.gameObject);
    }

    public override void Update()
    {
        base.Update();
        if(ControlledPawn)
        {
            ControlledPawn.SetVelocity(new Vector3(1,0,0));
        }
    }
}