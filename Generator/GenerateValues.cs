using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace Generator
{
    class GenerateValues
    {
        Random random;
        FieldInfo[] fields;
        MemberInfo[] classes;

        int minValue, 
            maxValue,
            minLength, 
            maxLength;

        public GenerateValues(int minValue, int maxValue, int minLength, int maxLength)
        {
            this.minValue = minValue;
            this.minLength = minLength;
            this.maxValue = maxValue;
            this.maxLength = maxLength;
        }
        /// <summary>
        /// Method that fill fields of a class by types
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fields"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        T FillingClass<T>(FieldInfo[] fields, T t)
        {
            foreach (FieldInfo f in fields)
            {
                if (f.FieldType == typeof(string))
                {
                    string s = StringMaker(random, minLength, maxLength);
                    f.SetValue(t, s);
                }
                else if (f.FieldType == typeof(bool))
                {
                    bool value = false;

                    if ((int)random.Next(0, 2) == 0)
                    {
                        value = true;
                    }
                    f.SetValue(t, value);
                }
                else if (f.FieldType == typeof(char))
                {
                    string s = StringMaker(random, 1, 1);
                    f.SetValue(t, s);
                }
                else if (f.FieldType == typeof(int))
                {
                    int value = random.Next(minValue, maxValue);
                    f.SetValue(t, value);
                }
                else if (f.FieldType == typeof(float))
                {
                    float value = random.Next(minValue, maxValue);
                    f.SetValue(t, value);
                }
                else if (f.FieldType == typeof(double))
                {
                    double value = random.Next(minValue, maxValue);
                    f.SetValue(t, value);
                }
            }
            return t;
        }
        /// <summary>
        /// Main generation method that finds fields, properties and classes and
        /// returns objects into the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="listOfClasses"></param>
        public void Generator<T>(T t, out List<object> listOfClasses)
        {
            listOfClasses = new List<object>();
            random = new Random();
            classes = t.GetType().GetMembers(BindingFlags.NonPublic);
            fields =  t.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            listOfClasses.Add(FillingClass<T>(fields, t));

            foreach (MemberInfo m in classes)
            {
                object obj = Activator.CreateInstance(m as Type);
                Type type = obj.GetType();
                FieldInfo[] info = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                listOfClasses.Add(FillingClass<object>(info, obj));
            }
        }

        /// <summary>
        /// Method that makes string by length
        /// </summary>
        /// <param name="rnd"></param>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        string StringMaker(Random rnd, int minLength, int maxLength)
        {
            string s = "";

            for (int j = 0; j < rnd.Next(minLength, maxLength); j++)
            {
                s += (char)(rnd.Next(65, 122));
            }

            return s;
        }

    }
}
