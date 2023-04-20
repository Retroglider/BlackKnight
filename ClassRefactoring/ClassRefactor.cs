/*
 * SOLID Principle: Open to extension, closed to change
 * DRY Principle
 * Code smell: SWITCH
 * Maintenance: Expressive modelling, extensible, decoupled, testable
 * Comments: Iterative approach.  Did not know ahead of time approach, but instead responded to code smells and perceived maintainability issues as we went along and favored more easily comprehensible(expressive) and maintainable(decoupled) code.
 */
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DeveloperSample.ClassRefactoring;

public enum SwallowType
{
    African, European
}

public enum SwallowLoad
{
    None, Coconut
}

public class SwallowFactory
{
    public ISwallow GetSwallow(SwallowType swallowType) {
        Dictionary<SwallowType, Type> swallowTypes = GetSwallowTypes();
        ISwallow result = (ISwallow)swallowTypes[swallowType]
            .GetConstructor(Type.EmptyTypes)
            .Invoke(null);
        return result; 
    }

    public Dictionary<SwallowType, Type> GetSwallowTypes()
    {
        Dictionary<SwallowType, Type> list = new ();
        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        {
            SwallowTypeAttribute attr = type.GetCustomAttribute<SwallowTypeAttribute>();
            if (attr != null)
            {
                list.Add(type.Name.ToEnum<SwallowType>(), type);
            }
        }
        return list;
    }
}


#region Setup
[AttributeUsage(AttributeTargets.Class)]
public class SwallowTypeAttribute: Attribute { 
    public string Name { get; set; }
    public SwallowTypeAttribute()
    {
        Type currentType = MethodBase.GetCurrentMethod().DeclaringType;
        Name = currentType.Name;
    }
}
public interface ISwallow
{
    double GetAirspeedVelocity();

    void ApplyLoad(SwallowLoad load);
}
/// <summary>
/// Base class for all swallows containing default behaviors.
/// </summary>
abstract class SwallowBase :ISwallow
{
    protected  Dictionary<SwallowLoad, double> speeds;
    protected SwallowLoad Load;
    public double GetAirspeedVelocity()
    {
        return speeds[Load];
    }

    public void ApplyLoad(SwallowLoad load)
    {
        Load = load;
    }
}
#endregion
#region Swallow Types
[SwallowType]
class African : SwallowBase
{
    public African()
    {
        speeds = new()
        {
            { SwallowLoad.None, 22 },
            { SwallowLoad.Coconut, 18 }
        };
    }
}
[SwallowType]
class European : SwallowBase
{
    public European()
    {
        speeds = new()
        {
            { SwallowLoad.None, 20 },
            { SwallowLoad.Coconut, 16 }
        };
    }
}
#endregion
//[Obsolete("Refactored to use polymorphism", true)]
//public class Swallow
//{
//    public SwallowType Type { get; }
//    public SwallowLoad Load { get; private set; }

//    public Swallow(SwallowType swallowType)
//    {
//        Type = swallowType;
//    }

//    public void ApplyLoad(SwallowLoad load)
//    {
//        Load = load;
//    }

//    public double GetAirspeedVelocity()
//    {
//        if (Type == SwallowType.African && Load == SwallowLoad.None)
//        {
//            return 22;
//        }
//        if (Type == SwallowType.African && Load == SwallowLoad.Coconut)
//        {
//            return 18;
//        }
//        if (Type == SwallowType.European && Load == SwallowLoad.None)
//        {
//            return 20;
//        }
//        if (Type == SwallowType.European && Load == SwallowLoad.Coconut)
//        {
//            return 16;
//        }
//        throw new InvalidOperationException();
//    }
//}