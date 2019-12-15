using UnityEngine;
using System.Collections;
using Vuforia;

public class CheckOutsideFall : MonoBehaviour
{

    private GameObject _ball;
    private Vector3 _ballFirstPos;

    // Use this for initialization
    void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("Ball");
        _ballFirstPos = _ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerExit(Collider other)
    {
        _ball.transform.Translate(_ballFirstPos);
    }
}
