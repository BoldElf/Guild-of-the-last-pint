using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShowProofControllerOnScene : MonoBehaviour
{
    [Inject] private ProofStorage proofStorage;
    [Inject] private DiContainer container;

    [SerializeField] private Canvas canvas;

    private Image image;

    public void ShowObject(ProofObject proofObject)
    {
        var gameObjectProof = container.InstantiatePrefab(proofObject.getProofObject().GetProofObject(), canvas.transform);
        image = gameObjectProof.GetComponent<Image>();

        image.sprite = proofObject.getProofObject().GetSprite();
    }
}
