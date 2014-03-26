using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Core.Pattern
{
    #region 简单实现
    /// <summary>
    /// 这种方式的实现对于线程来说并不是安全的，因为在多线程的环境下有可能得到Singleton类的多个实例。
    /// 如果同时有两个线程去判断（instance == null），并且得到的结果为真，这时两个线程都会创建类Singleton的实例，这样就违背了Singleton模式的原则。
    /// 实际上在上述代码中，有可能在计算出表达式的值之前，对象实例已经被创建，但是内存模型并不能保证对象实例在第二个线程创建之前被发现。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SimpleSingleton<T> where T : class,new()
    {
        static T _instance = default(T);

        public static T GetInstance()
        {
            if (_instance == null)
            {
                _instance = new T();
            }

            return _instance;
        }
    }
    #endregion

    #region 安全的线程
    /// <summary>
    /// 这种方式的实现对于线程来说是安全的。
    /// 我们首先创建了一个进程辅助对象，线程在进入时先对辅助对象加锁然后再检测对象是否被创建，这样可以确保只有一个实例被创建，因为在同一个时刻加了锁的那部分程序只有一个线程可以进入。
    /// 这种情况下，对象实例由最先进入的那个线程创建，后来的线程在进入时（instence == null）为假，不会再去创建对象实例了。
    /// 但是这种实现方式增加了额外的开销，损失了性能。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LockSingleton<T> where T : class,new()
    {
        static T _instance = default(T);
        static readonly object padlock = new object();

        public static T GetInstance()
        {
            lock (padlock)
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
            }

            return _instance;
        }
    }
    #endregion

    #region 双重锁定
    /// <summary>
    /// 这种实现方式对多线程来说是安全的，同时线程不是每次都加锁，只有判断对象实例没有被创建时它才加锁，有了我们上面第一部分的里面的分析，我们知道，加锁后还得再进行对象是否已被创建的判断。
    /// 它解决了线程并发问题，同时避免在每个 Instance 属性方法的调用中都出现独占锁定。它还允许您将实例化延迟到第一次访问对象时发生。
    /// 实际上，应用程序很少需要这种类型的实现。大多数情况下我们会用静态初始化。这种方式仍然有很多缺点：无法实现延迟初始化。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoubleLockSingleton<T> where T : class,new()
    {
        static T _instance = default(T);
        static readonly object padlock = new object();

        public static T GetInstance()
        {
            if (_instance == null)
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                }
            }

            return _instance;
        }
    }
    #endregion

    #region 静态初始化
    /// <summary>
    /// 看到上面这段富有戏剧性的代码，我们可能会产生怀疑，这还是Singleton模式吗？在此实现中，将在第一次引用类的任何成员时创建实例。公共语言运行库负责处理变量初始化。该类标记为 sealed 以阻止发生派生，而派生可能会增加实例。此外，变量标记为 readonly，这意味着只能在静态初始化期间（此处显示的示例）或在类构造函数中分配变量。
    /// 该实现与前面的示例类似，不同之处在于它依赖公共语言运行库来初始化变量。它仍然可以用来解决 Singleton 模式试图解决的两个基本问题：全局访问和实例化控制。公共静态属性为访问实例提供了一个全局访问点。此外，由于构造函数是私有的，因此不能在类本身以外实例化 Singleton 类；因此，变量引用的是可以在系统中存在的唯一的实例。
    /// 由于 Singleton 实例被私有静态成员变量引用，因此在类首次被对 Instance 属性的调用所引用之前，不会发生实例化。
    /// 这种方法唯一的潜在缺点是，您对实例化机制的控制权较少。在 Design Patterns 形式中，您能够在实例化之前使用非默认的构造函数或执行其他任务。由于在此解决方案中由 .NET Framework 负责执行初始化，因此您没有这些选项。在大多数情况下，静态初始化是在 .NET 中实现 Singleton 的首选方法。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StaticSingleton<T> where T : class,new()
    {
        static readonly T _instance = new T();

        public static T GetInstance()
        {
            return _instance;
        }
    }
    #endregion

    #region 延迟初始化(懒加载)
    /// <summary>
    /// 这里，初始化工作有Nested类的一个静态成员来完成，这样就实现了延迟初始化，并具有很多的优势，是值得推荐的一种实
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T : class,new()
    {
        public static T GetInstance()
        {

            return Nested.instance;
        }

        public class Nested
        {
            internal static readonly T instance = new T();
        }
    }
    #endregion

    #region 延迟初始化(懒加载)
    /// <summary>
    /// 这里，初始化工作有Nested类的一个静态成员来完成，这样就实现了延迟初始化，并具有很多的优势，是值得推荐的一种实
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton
    {
        public static T GetInstance<T>() where T:class,new()
        {
            return Nested<T>.instance;
        }

        class Nested<T> where T : class,new()
        {
            internal static readonly T instance = new T();
        }
    }
    #endregion
}
