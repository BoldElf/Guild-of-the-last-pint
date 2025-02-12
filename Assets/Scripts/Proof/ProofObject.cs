using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProofObject : MonoBehaviour
{
    [SerializeField] private ScriptableObject scriptableObject;

    private IProofObject proofObject;

    private void Awake()
    {
        proofObject = scriptableObject as IProofObject;
        //Debug.Log(proofObject.getName());
    }

    public IProofObject getProofObject()
    {
        return proofObject;
    }
}
