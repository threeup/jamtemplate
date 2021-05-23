
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pawn : MonoBehaviour
{
    public Vector3 Velocity { get; private set; }
    public Controller PossessedByController;
    
    void Awake()
    {
        Program.Instance.Pawns.Add(this);
    }
    
    public void Die()
    {
        Program.Instance.Pawns.Remove(this);
        Destroy(this.gameObject);
    }


    public void PossessedBy(Controller inController)
    {
        PossessedByController = inController;
    }
    public void DispossesedBy(Controller lastController)
    {
        PossessedByController = null;
    }
    public void SetVelocity(Vector3 inVelocity)
    {
        Velocity = inVelocity;
    }

    public virtual void UpdatePawn(float deltaTime)
    {
        GameObject go = this.gameObject;
        go.transform.position = go.transform.position + Velocity*deltaTime;
    }
}