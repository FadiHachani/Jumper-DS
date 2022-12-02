using System;
using System.Collections.Generic;
using UnityEngine;

public class UpLimit : MonoBehaviour {

    public Transform StartTransform;

	private void Update () {
        RaycastHit hit;

        Debug.DrawRay(StartTransform.position, -transform.forward * 5f, Color.red);

        if (!Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z + 2f), -transform.forward * 5f, out hit))
        {
            GetComponent<HelixPieceCreator>().ResetNewPiece();
            print("Change pos");
        }
	}
}
