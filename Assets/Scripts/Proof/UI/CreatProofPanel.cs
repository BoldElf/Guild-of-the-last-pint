using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CreatProofPanel : MonoBehaviour
{
    [Inject] private DiContainer container;

    [SerializeField] private GameObject panelPrefab;
    //[SerializeField] private GameObject panelPrefabForIDCard;

    private GameObject panelObject;

    public void CreatPanelDefault()
    {
        panelObject = container.InstantiatePrefab(panelPrefab, gameObject.GetComponentInParent<Canvas>().transform);
    }

    /*
    public void CreatPanelIDCard()
    {
        panelObject = container.InstantiatePrefab(panelPrefabForIDCard, gameObject.GetComponentInParent<Canvas>().transform);
    }
    */
}
