using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class CheckProofs : MonoBehaviour
{
    [Inject] private ProofStorage proofStorage;
    [Inject] private DiContainer container;

    [SerializeField] private int countProof;

    [SerializeField] private GameObject prefabEndPanel;
    [SerializeField] private Canvas canvas;

    private GameObject panel;
    private TextMeshProUGUI text;

    public void checkFinal()
    {
        panel = container.InstantiatePrefab(prefabEndPanel, canvas.transform);
        text = panel.GetComponentInChildren<TextMeshProUGUI>();

        if(proofStorage.getProofObjects().Count < countProof)
        {
            text.text = "Победа!\r\nТебе удалось спастись! Но какой ценой:\r\n\r\nТеперь все узнают о том, что Йети существуют, спокойная жизнь, вероятно, закончилась:(";
        }
        else
        {
            text.text = "Победа!\r\nТебе удалось спастись и сохранить свой вид в тайне. Твои сородичи будут благодарны тебе! Ты молодец!";
        }
    }
}
