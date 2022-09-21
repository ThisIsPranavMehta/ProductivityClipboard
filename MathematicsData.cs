using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace learningForms
{
    internal class MathematicsData
    {
        public Double Resultant { get; set; }
        public List<Double> Values=new List<Double>();
        public void AddValues(Double num)
        {
            Values.Add(num);
        }
        public List<Double> GetAllValues() 
        { 
            return Values; 
        }
        public void RemoveValue(int index)
        {
            if (index < Values.Count())
            {
                Resultant -= Values[index];
                Values.RemoveAt(index);
            }
        }
        
    }
}
// it can contain the resultant as well as the values..
// 