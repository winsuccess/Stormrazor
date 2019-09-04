using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCard : MonoBehaviour
{
    public PlayState ps;

    private void Start()
    {

    }
    public void OnGetCard()
    {
        ps.ChangeState(PlayState.State.DrawState);
    }


}
