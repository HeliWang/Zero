using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// AbstractFactory 抽象工厂的目的是要提供一个创建一系列相关或相互依赖对象的接口，而不需要指定它们具体的类。
/// </summary>
namespace Zero.Design
{

    public abstract class Factory
    {
        public static Factory GetInstance(string factoryName)
        {
            if (!string.IsNullOrEmpty(factoryName))
            {
                return new FuJian();
            }
            return null;
        }

        public abstract string Add();
    }

    public class FuJian : Factory
    {
        public override string Add()
        {
            return "福建";
        }
    }

    public class ShangHai : Factory
    {
        public override string Add()
        {
            return "上海";
        }
    }

    public class Province
    {
        private Factory factory;

        //public void Set()
        //{
        //    factory = new FuJian();
        //}

        public string Get()
        {
            return factory.Add();
        }
    }
}
