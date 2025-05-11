namespace Huawei.E3372.Manager.Logic;

internal static class ConcurrentTasks
{
    public static async Task<(T1, T2)> AsParallel<T1, T2>(Task<T1> t1, Task<T2> t2)
    {
        await Task.WhenAll([t1, t2]);
        return (t1.Result, t2.Result);
    }

    public static async Task<(T1, T2, T3)> AsParallel<T1, T2, T3>(Task<T1> t1, Task<T2> t2, Task<T3> t3)
    {
        await Task.WhenAll([t1, t2, t3]);
        return (t1.Result, t2.Result, t3.Result);
    }

    public static async Task<(T1, T2, T3, T4)> AsParallel<T1, T2, T3, T4>(Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4)
    {
        await Task.WhenAll([t1, t2, t3, t4]);
        return (t1.Result, t2.Result, t3.Result, t4.Result);
    }
}