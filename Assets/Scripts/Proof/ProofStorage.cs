using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProofStorage : MonoBehaviour
{
    private List<IProofObject> proofObjects = new List<IProofObject>();

    [SerializeField] private GameObject proofData;
    [SerializeField] private GameObject proofData_02;

    private ProofObject thisIsProofObject;

    private void Start()
    {
        //addProofObject(scriptableObject);
        if(proofData.TryGetComponent<ProofObject>(out thisIsProofObject))
        {
            proofObjects.Add(thisIsProofObject.getProofObject());
            Debug.Log("Enter");
        }

        if (proofData_02.TryGetComponent<ProofObject>(out thisIsProofObject))
        {
            proofObjects.Add(thisIsProofObject.getProofObject());
            Debug.Log("Enter");
        }

        getListDebug();
    }

    public void addProofObject(IProofObject proofObject)
    {
        proofObjects.Add(proofObject);
    }

    public List<IProofObject> getProofObjects()
    {
        return proofObjects;
    }

    public string getNameObject(int index)
    {
        return proofObjects[index].getName();
    }

    public Sprite getImage(int index)
    {
        return proofObjects[index].GetSprite();
    }

    private void getListDebug()
    {
        foreach(var proofObject in proofObjects)
        {
            Debug.Log(proofObject.getName());
        }
    }
}
