using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


public class RunData
{
    public int Index;
    public List<NamedList> AllData;

    public RunData()
    {
        AllData = new List<NamedList>();
    }
    public RunData(List<NamedList> list)
    {
        AllData = list;
    }
    public RunData(string name, List<float> list)
    {
        AllData = new List<NamedList>();
        AddDataList(name, list);
    }


    public void AddDataList(NamedList nl)
    {
        AllData.Add(nl);
    }
    public void AddDataList(string name, float[] array)
    {
        NamedList nl = new NamedList(name);

        float min, max;
        min = array[0];
        max = array[0];

        for (int i = 0; i < array.Length; i++)
        {
            nl.Add(array[i]);
            if (array[i] < min)
                min = array[i];
            else if (array[i] > max)
                max = array[i];
        }
        nl.MinVal = min;
        nl.MaxVal = max;

        AllData.Add(nl);
    }
    public void AddDataList(string name, List<float> list)
    {
        NamedList nl = new NamedList(name, list);

        float min, max;
        min = list[0];
        max = list[0];

        foreach (float index in list)
            if (index < min)
                min = index;
            else if (index > max)
                max = index;
        nl.MinVal = min;
        nl.MaxVal = max;

        AllData.Add(nl);
    }


    public List<float> GetDataList(string name)
    {
        foreach (NamedList index in AllData)
            if (index.Name == name)
                return index;
        return null;
    }

}

public class NamedList : List<float>
{
    public string Name { get; set; }
    public float MinVal { get; set; }
    public float MaxVal { get; set; }

    public bool IsEmpty
    {
        get { if (Count == 0) return true; return false; }
    }


    public NamedList(string name) : base()
    {
        Name = name;
        MinVal = 0;
        MaxVal = 0;
    }
    public NamedList(string name, IEnumerable<float> list) : base()
    {
        AddRange(list);
        Name = name;
        MinVal = 0;
        MaxVal = 0;
    }


    public new void Add(float value)
    {
        base.Add(value);

        if (value < MinVal)
            MinVal = value;
        else if (value > MaxVal)
            MaxVal = value;
    }
    public new void AddRange(IEnumerable<float> range)
    {
        base.AddRange(range);

        foreach (float i in range)
            if (i < MinVal)
                MinVal = i;
            else if (i > MaxVal)
                MaxVal = i;
    }

    public bool Equals(NamedList nl)
    {
        if (nl.Name == Name)
            return true;

        return false;
    }

}
/*public class NamedList
{
    public string Name = "";
    public List<float> Data;

    public float MinVal = 0;
    public float MaxVal = 0;


    public NamedList(string name)
    {
        Name = name;
        Data = new List<float>();

    }
    public NamedList(string name, List<float> list)
    {
        Name = name;
        Data = list;
    }


    public void AddData(float value)
    {
        Data.Add(value);
        if (value > MaxVal)
            MaxVal = value;
        else if (value < MinVal)
            MinVal = value;
    }

    public List<float> GetData()
    {
        return Data;
    }
    public float GetSingleValue(int index)
    {
        return Data[index];
    }
    public int Count()
    {
        return Data.Count;
    }
    public bool IsEmpty()
    {
        if (Data.Count > 0)
            return true;
        return false;
    }
}*/

public struct Polynom
{
    public float[] Coefficients;
    public bool Visible;
    public Color _color;
    public Color Color
    {
        get { return _color; }
        set { _color = value; }
    }
}

public struct DataSet
{
    public string Name;
    public bool Visible;
    public NamedList DataX;
    public NamedList DataY;
    public Color LineColor;
    public List<Polynom> Polynoms;
}



public class RandomColor
{
    private Color[] warmColors = new Color[]
    {
        Color.Coral,
        Color.DarkRed,
        Color.DarkOrange,
        Color.Brown,
        Color.Fuchsia,
        Color.Red,
        Color.Chocolate,
        Color.IndianRed,
        Color.Tomato,
        Color.Firebrick,
        Color.DeepPink,
        Color.Magenta,
        Color.Violet
    };
    private Color[] coolColors = new Color[]
    {
        Color.Blue,
        Color.Purple,
        Color.BlueViolet,
        Color.LightSeaGreen,
        Color.MediumOrchid,
        Color.Navy,
        Color.DarkGreen,
        Color.Green,
        Color.DarkViolet,
        Color.DarkSlateGray,
        Color.SteelBlue,
        Color.Teal,
        Color.DodgerBlue
    };

    private int[] timesUsedWarm;
    private int[] timesUsedCool;
    private int leastTimesUsed;

    private Random tempRandom = new Random();


    public RandomColor()
    {
        timesUsedWarm = new int[warmColors.Length];
        timesUsedCool = new int[coolColors.Length];
        leastTimesUsed = 0;
    }

    public Color GetColor(bool cool = true, bool colorIsUdes = true)
    {
        int[] timesUsed;
        if (cool)
            timesUsed = timesUsedCool;
        else
            timesUsed = timesUsedWarm;


        List<int> usableColors = new List<int>();

        for (int i = 0; i < timesUsed.Length; i++)
            if (timesUsed[i] == leastTimesUsed)
                usableColors.Add(i);

        int chosenColorIndex = usableColors[tempRandom.Next(usableColors.Count)];

        if (usableColors.Count == 1)
            leastTimesUsed++;

        timesUsed[chosenColorIndex]++;

        if (cool)
            return coolColors[chosenColorIndex];
        else
            return warmColors[chosenColorIndex];

    }

}