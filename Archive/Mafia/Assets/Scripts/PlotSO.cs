using UnityEngine;

[CreateAssetMenu(fileName = "PlotSO", menuName = "ScriptableObject/PlotSO")]
public class PlotSO : ScriptableObject 
{


    [Header("Gameplay")]
    private int temp;
    [SerializeField] private Component logic;

    [Header("Visual")]
    [SerializeField] private Sprite sprite;


    public Sprite GetSprite()
    {
        return sprite;
    }
}
