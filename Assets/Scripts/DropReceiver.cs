using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropReceiver : MonoBehaviour
{
    [SerializeField]
    List<GameObject> dropElementsList;

    [SerializeField]
    GameObject dropReceiverGO;
    private void OnEnable()
    {
        DragAndDrop.OnObjectDragged += DraggedToMe;
    }
    private void OnDisable()
    {
        DragAndDrop.OnObjectDragged -= DraggedToMe;
    }

    public void DraggedToMe(GameObject gameObj, Vector3 position)
    {
        for (int i = 0; i < dropElementsList.Count; i++)
        {
            if (dropElementsList[i] == gameObj)
            {
                if(Vector3.Distance(dropReceiverGO.transform.position, gameObj.transform.position) < 2)
                {
                    ObjectDropped(gameObj);
                }
                else
                {
                    BackToItsPlace(gameObj);
                }
            }
        }
    }
    public virtual void ObjectDropped(GameObject gameObj)
    {

    }

    void BackToItsPlace(GameObject obj)
    {
        obj.transform.position = obj.GetComponent<DragAndDrop>().StartPosition;
    }
}
