using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeDeHierbasPuzzle : DropReceiver
{
    [SerializeField] GameObject HojasRobles;
    [SerializeField] GameObject AguaHirviendo;
    [SerializeField] GameObject Miel;
    [SerializeField] GameObject Alistair;


    [SerializeField] TextMeshProUGUI HojasRoblesTxt;
    [SerializeField] TextMeshProUGUI AguaHirviendoTxt;
    [SerializeField] TextMeshProUGUI MielTxt;

    [SerializeField] SpriteRenderer VasoObjeto;
    [SerializeField] Sprite VasoHojas;
    [SerializeField] Sprite VasoAgua;
    [SerializeField] Sprite VasoMiel;
    [SerializeField] Sprite AlistairGood;

    public BaseNode nodeAfterDrinked;

    public int phase; // 0 needs hojas, 1 needs agua, 2 needs honey
    public override void ObjectDropped(GameObject gameObj)
    {
        base.ObjectDropped(gameObj);
        if(phase == 0 && gameObj == HojasRobles)
        {
            VasoObjeto.sprite = VasoHojas;
            phase++;
            HojasRoblesTxt.color = Color.green;
            gameObj.SetActive(false);
        }
        if(phase == 1 && gameObj == AguaHirviendo)
        {
            VasoObjeto.sprite = VasoAgua;
            phase++;
            AguaHirviendoTxt.color = Color.green;
            gameObj.SetActive(false);
        }
        if(phase == 2 && gameObj == Miel)
        {
            VasoObjeto.sprite = VasoMiel;
            phase++;
            MielTxt.color = Color.green;
            gameObj.SetActive(false);
            uCore.Audio.PlaySFX("DrinkingTea");
            Alistair.GetComponent<SpriteRenderer>().sprite = AlistairGood;
            Invoke("Drinked", 3.0f);
        }
    }
    void Drinked()
    {
        FindObjectOfType<GameLoader>().LoadNode(nodeAfterDrinked);
        HojasRobles.SetActive(false);
        AguaHirviendo.SetActive(false);
        Miel.SetActive(false);

        HojasRoblesTxt.gameObject.SetActive(false);
        AguaHirviendoTxt.gameObject.SetActive(false);
        MielTxt.gameObject.SetActive(false);

        VasoObjeto.gameObject.SetActive(false);
        Alistair.SetActive(false);
    }
}
