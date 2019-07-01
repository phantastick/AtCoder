using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    //int[] split = Console.ReadLine().Split().Select(int.Parse).ToArray();
    static void Main(string[] args)
    {


    }
}

class Util
{
    static long GCD(long a, long b)
    {
        if (a < b)
            swap(ref a, ref b);
        if (a % b == 0) return b;
        return GCD(b, a % b);

    }
    static int GCD(int a, int b)
    {
        if (a < b)
            swap(ref a, ref b);
        if (a % b == 0) return b;
        return GCD(b, a % b);
    }

    static void swap<T>(ref T a, ref T b)
    {
        T temp = b;
        b = a;
        a = temp;

    }
    static long LCM(long a, long b)
    {
        return a * b / GCD(a, b);
    }
    static long LCM(int a, int b)
    {
        return Math.BigMul(a, b) / GCD(a, b);
    }


    private int M = 1000000007;
    private int[] factorial_modM;
    public int Multiple_modM(int a, int b)
    {
        return (int)(Math.BigMul(a, b) % M);
    }
    public void factorial_modM_Prepare(int n)
    {
        factorial_modM = new int[n + 1];
        factorial_modM[0] = 1;
        for (int i = 1; i <= n; ++i)
        {
            factorial_modM[i] = Multiple_modM(factorial_modM[i - 1], i);
        }
    }
    public int Factorial(int n)
    {
        return factorial_modM[n];
    }
    public int Pow(int a, int m)
    {
        switch (m)
        {
            case 0:
                return 1;
            case 1:
                return a;
            default:
                int p1 = Pow(a, m / 2);
                int p2 = Multiple_modM(p1, p1);
                return ((m % 2) == 0) ? p2 : Multiple_modM(p2, a);
        }
    }
    public int Div(int a, int b)
    {
        return Multiple_modM(a, Pow(b, M - 2));
    }
    public int nCr_modM(int n, int r)
    {
        if (n < r) { return 0; }
        if (n == r) { return 1; }
        int res = Factorial(n);
        res = Div(res, Factorial(r));
        res = Div(res, Factorial(n - r));
        return res;
    }

}

class UnionFind<T>
{
    public int tree_height;
    public UnionFind<T> parent;
    public T item
    {
        get;
        private set;
    }

    public UnionFind(T item)
    {
        tree_height = 0;
        parent = this;
    }

    public UnionFind<T> FindAdam()
    {
        if (parent == this) return this;
        else
        {
            UnionFind<T> ParentOfParent = parent.FindAdam();
            parent = ParentOfParent;//ècí∑Ç»ç\ê¨ÇÇ¬Ç»Ç¨íºÇµÇƒÇ¢ÇÈ
            return ParentOfParent;
        }
    }
    public static void Unite(UnionFind<T> a, UnionFind<T> b)
    {
        UnionFind<T> ParentOfA = a.FindAdam();
        UnionFind<T> ParentOfB = b.FindAdam();
        if (ParentOfA.tree_height < ParentOfB.tree_height)
        {
            ParentOfA.parent = ParentOfB;
            ParentOfB.tree_height = Math.Max(ParentOfA.tree_height + 1, ParentOfB.tree_height);
        }
        else
        {
            ParentOfB.parent = ParentOfA;
            ParentOfA.tree_height = Math.Max(ParentOfB.tree_height + 1, ParentOfA.tree_height);
        }

    }

}
