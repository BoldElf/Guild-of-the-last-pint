using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CardPanelBehaviour : MonoBehaviour
{
    [Inject] private DiContainer container;
    [SerializeField] private Image imageObject;
    [SerializeField] private GameObject namePanelOject;
    [SerializeField] private Image imageProof;

    private TextMeshProUGUI namePanel;
    private GameObject imageProofObject;

    private void Awake()
    {
        namePanel = namePanelOject.GetComponentInChildren<TextMeshProUGUI>();
    }


    public void setName(string nameText)
    {
        namePanel.text = nameText;
    }

    public void setImage(Sprite sprite)
    {
        imageObject.sprite = sprite;
    }

    public void checkInfo()
    {
        imageProofObject = container.InstantiatePrefab(imageProof,GetComponentInParent<Canvas>().transform);
        imageProofObject.GetComponent<Image>().sprite = imageObject.sprite;
    }

    private void OnDestroy()
    {
        if (imageProofObject != null)
        {
            Destroy(imageProofObject);
        }
        
    }
}
