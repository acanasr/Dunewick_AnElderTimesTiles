using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ForjarArmaPuzzle : DropReceiver
{
    public int phase = 0;
    public int clicksForge = 0;

    [SerializeField] TextMeshProUGUI Text1;
    [SerializeField] TextMeshProUGUI Text2;
    [SerializeField] TextMeshProUGUI Text3;
    [SerializeField] TextMeshProUGUI Text4;
    [SerializeField] TextMeshProUGUI Text5;

    [SerializeField] GameObject Iron;
    [SerializeField] GameObject IronI;
    [SerializeField] GameObject IronII;
    [SerializeField] GameObject IronIII;
    [SerializeField] GameObject SwordCold;
    [SerializeField] GameObject ColdSwordInTable;
    [SerializeField] GameObject Mango;
    [SerializeField] GameObject FinishedSwordInTable;

    private void Update()
    {
        if(phase == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                clicksForge++;
                switch (clicksForge)
                {
                    case 1:
                        IronI.SetActive(false);
                        IronII.SetActive(true);
                        break;
                    case 2:
                        IronII.SetActive(false);
                        IronIII.SetActive(true);
                        Text2.color = Color.green;
                        phase++;
                        break;
                }
            }
        }
    }
    public override void ObjectDropped(GameObject gameObj)
    {
        base.ObjectDropped(gameObj);
        if (phase == 0 && gameObj == Iron)
        {
            Iron.SetActive(false);
            IronI.SetActive(true);
            phase++;
            Text1.color = Color.green;
        }
        if(phase == 2 && gameObj == IronIII)
        {
            IronIII.SetActive(false);
            SwordCold.SetActive(true);
            Text3.color = Color.green;
            phase++;
        }
        if (phase == 3 && gameObj == SwordCold)
        {
            SwordCold.SetActive(false);
            ColdSwordInTable.SetActive(true);
            Text4.color = Color.green;
            phase++;
        }
        if (phase == 4 && gameObj == Mango)
        {
            Mango.SetActive(false);
            FinishedSwordInTable.SetActive(true);
            Text5.color = Color.green;

            uCore.Audio.PlaySFX("SwordSoundEffect");
            Invoke("Finished", 3.0f);
        }
    }
    void Finished()
    {
        //tendra que llamar a la transicion 4-5
        FindObjectOfType<EndNodeFunctions>().TransitionActIVActV();
    }
}
