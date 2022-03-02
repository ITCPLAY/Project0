using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] Material[] material;
    Renderer rend;
    LockController lockController;
    void Start()
    {
        lockController = GetComponentInParent<LockController>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    private void Update()
    {
        MaterialChange();
    }

    public void MaterialChange() 
    {
        if (lockController.Click == true)
        {
            rend.sharedMaterial = material[1];
        }
    
    
    
    }
}
