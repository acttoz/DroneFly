using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMission : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (Manager.isPlaying)
        {
            if (other.tag == "box")
            {
                switch (Constant.missionNum) {
                    case 6:
                Manager.mgr.checkMission();
                        break;
                    case 7:
                        Constant.isClearSubMission = true;
                        break;
                }
            }
            if (other.tag == "fireext")
            {
                other.transform.SetParent(gameObject.transform);
            }

            if (other.tag == "Player")
            {
                switch (Constant.missionNum)
                {
                    case 7:
                        Manager.mgr.checkMission();
                        break;
                }
            }
        }
    }
}
