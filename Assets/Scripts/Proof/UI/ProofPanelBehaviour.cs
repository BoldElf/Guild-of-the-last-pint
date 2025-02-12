using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class ProofPanelBehaviour : MonoBehaviour
{
    [Inject] private DiContainer container;
    [Inject] private ProofStorage proofStorage;

    [SerializeField] private GameObject cardPrefab;

    [SerializeField] private GameObject content;

    private GameObject cardPanelObject;

    private CardPanelBehaviour cardPanelBehaviour;

    private void Start()
    {
        for(int i = 0; i < proofStorage.getProofObjects().Count;i++)
        {
            cardPanelObject = container.InstantiatePrefab(cardPrefab, content.transform);

            if(cardPanelObject.TryGetComponent<CardPanelBehaviour>(out cardPanelBehaviour))
            {
                cardPanelBehaviour.setName(proofStorage.getNameObject(i));
                cardPanelBehaviour.setImage(proofStorage.getImage(i));
            }
        }
    }
}
