using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{

    public Pawn ControlledPawn { get; private set;}
    public virtual void Awake()
    {
        Program.Instance.Controllers.Add(this);
    }
    public virtual void Die()
    {
        Program.Instance.Controllers.Remove(this);
        Destroy(this.gameObject);
    }

    public void Possess(Pawn inPawn)
    {
        if(ControlledPawn != null)
        {
            ControlledPawn.DispossesedBy(this);
        }
        ControlledPawn = inPawn;
        if(ControlledPawn != null)
        {
            ControlledPawn.PossessedBy(this);
        }
    }

    public virtual void Update()
    {
        float dt = Time.deltaTime;
        if(ControlledPawn)
        {
            ControlledPawn.UpdatePawn(dt);
        }
    }
}