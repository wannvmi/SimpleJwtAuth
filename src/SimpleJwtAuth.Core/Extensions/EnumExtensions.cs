using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJwtAuth.Core.Extensions;
public static class EnumExtensions
{
    /// <summary>
    /// 枚举名称
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string GetName(this Enum value)
    {
        Type type = value.GetType();
        return Enum.GetName(type, value);
    }

    /// <summary>
    /// 获取枚举的描述文本
    /// </summary>
    /// <param name="e">枚举成员</param>
    /// <returns></returns>
    public static string GetEnumDescription(object e)
    {
        //获取字段信息
        System.Reflection.FieldInfo[] ms = e.GetType().GetFields();

        Type t = e.GetType();
        foreach (System.Reflection.FieldInfo f in ms)
        {
            //判断名称是否相等
            if (f.Name != e.ToString()) continue;

            //反射出自定义属性
            foreach (Attribute attr in f.GetCustomAttributes(true))
            {
                //类型转换找到一个Description，用Description作为成员名称
                System.ComponentModel.DescriptionAttribute dscript = attr as System.ComponentModel.DescriptionAttribute;
                if (dscript != null)
                    return dscript.Description;
            }

        }
        //如果没有检测到合适的注释，则用默认名称
        return e.ToString();
    }

    /// <summary>
    /// 扩展方法，获得枚举的Description
    /// </summary>
    /// <param name="value">枚举值</param>
    /// <param name="nameInstead">当枚举没有定义DescriptionAttribute,是否用枚举名代替，默认使用</param>
    /// <returns>枚举的Description</returns>
    public static string GetDescription(this Enum value, bool nameInstead = true)
    {
        Type type = value.GetType();
        string name = Enum.GetName(type, value);
        if (name == null)
        {
            return null;
        }
        FieldInfo field = type.GetField(name);
        DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
        if (attribute == null && nameInstead == true)
        {
            return name;
        }
        return attribute == null ? null : attribute.Description;
    }



}
