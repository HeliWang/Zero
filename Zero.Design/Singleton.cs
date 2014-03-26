using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 单件模式：保证有一个类且仅有一个实例，并且提供一个全局访问点
namespace Zero.Design
{
    
    /// <summary>
    /// 安全的线程 
    /// </summary>
    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static object padlock = new object();

        Singleton()
        {
        }

        public static Singleton Instance
        {
            get 
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
    }


    /// <summary>
    /// 静态初始化（推荐使用）
    /// </summary>
    public sealed class Singleton2
    {
        private static readonly Singleton2 instance = new Singleton2();

        Singleton2()
        {
        }

        public static Singleton2 Instance
        {
            get
            {
                return instance;
            }
        }
    }


    public class CountSigleton
    {
        private static readonly CountSigleton instance = new CountSigleton();

        private int totNum = 0;

        CountSigleton()
        {
        }

        public static CountSigleton Instance
        {
            get
            {
                return instance;
            }
        }

        public void Add()
        {
            totNum++;
        }
    }

    public class Test
    {
        public void Add()
        {
            CountSigleton c = CountSigleton.Instance;
            c.Add();
        }
    }
}
