using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CreatProofPanel : MonoBehaviour
{
    [Inject] private DiContainer container;

    [SerializeField] private GameObject panelPrefab;

    private GameObject panelObject;

    public void CreatPanel()
    {
        panelObject = container.InstantiatePrefab(panelPrefab, gameObject.GetComponentInParent<Canvas>().transform);
    }
}
