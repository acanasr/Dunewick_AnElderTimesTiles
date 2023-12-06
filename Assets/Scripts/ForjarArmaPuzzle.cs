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

    [SerializeField] GameObject Iron;
    [SerializeField] GameObject IronI;
    [SerializeField] GameObject IronII;
    [SerializeField] GameObject IronIII;

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
                        break;
                    case 2:
                        break;
                    case 3: 
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
    }

 }
