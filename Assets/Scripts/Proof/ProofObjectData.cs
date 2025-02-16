using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New ProofObject", menuName = "Proof Object", order = 51)]
public class ProofObjectData : ScriptableObject, IProofObject
{
    [SerializeField] private string text;
    [SerializeField] private Sprite image;
    [SerializeField] private Image proofObject;
    public string getName()
    {
        return text;
    }

    public Image GetProofObject()
    {
        return proofObject;
    }

    public Sprite GetSprite()
    {
        return image;
    }
}
