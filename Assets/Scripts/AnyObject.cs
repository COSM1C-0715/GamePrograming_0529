using System;
using UnityEngine;

public class AnyObject : MonoBehaviour
{
    [SerializeField]
    private int ObjectType;

    public int p_ObjectType => ObjectType;

    Action<AnyObject> onReturn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(Action<AnyObject> onReturn)
    {
        this.onReturn = onReturn;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(""))
        {
            onReturn?.Invoke(this);
        }
    }
}
