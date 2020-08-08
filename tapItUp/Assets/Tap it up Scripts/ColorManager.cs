using System;
using UnityEngine;



//COLOR MANAGER FOR OBSTACLES, BALL, WALLS AND SWITCH

public class ColorManager : MonoBehaviour
{
	public enum Colors
	{
		Yellow = 1,
		Cyan,
		Magenta,
		Pink
	}

	private static Color32 Yellow;

	private static Color32 Cyan;

	private static Color32 Magenta;

	private static Color32 Pink;

	private static Color32 Red;

	private void Awake()
	{
		ColorManager.Yellow = new Color32(245, 218, 17, 255);
		ColorManager.Cyan = new Color32(46, 222, 240, 255);
		ColorManager.Magenta = new Color32(106, 34, 206, 255);
		ColorManager.Pink = new Color32(255, 0, 117, 255);
		ColorManager.Red = new Color32(241, 19, 53, 255);
	}

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static Color32 SetColor(int index)
	{
		switch (index)
		{
		case 1:
			return ColorManager.Yellow;
		case 2:
			return ColorManager.Cyan;
		case 3:
			return ColorManager.Magenta;
		case 4:
			return ColorManager.Pink;
		case 5:
			return ColorManager.Red;
		default:
			throw new Exception("invalid color");
		}
	}

	public static Color32 SetRandomColor()
	{
		return ColorManager.SetColor(UnityEngine.Random.Range(1, 6));
	}
}
