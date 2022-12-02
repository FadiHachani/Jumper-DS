using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour {

    public Color[] BackgroundColors;
    public Color[] BallsColors;
    public Color[] PieceColors;
    public Color[] FailPieceColors;
    public Color[] CylinderColors;

    public Material BallMaterila;
    public Material PieceMaterila;
    public Material FailPieceMaterila;
    public Material CylinderMaterila;

    public Camera MainCamera;

    public static Color BallColor;

    private int _colorID;

	void Start () {
        _colorID = Random.Range(0, BackgroundColors.Length);
        MainCamera.backgroundColor = BackgroundColors[_colorID];
        BallMaterila.color = BallsColors[_colorID];
        PieceMaterila.color = PieceColors[_colorID];
        FailPieceMaterila.color = FailPieceColors[_colorID];
        CylinderMaterila.color = CylinderColors[_colorID];

        BallColor = BallsColors[_colorID];
    }
	
}
