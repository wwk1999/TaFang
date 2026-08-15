using System;

public static class LongRandom
{
    private static readonly Random _random = new Random();
    
    /// <summary>
    /// 获取 [min, max] 范围内的随机 long（包含最大值）
    /// </summary>
    public static long Range(long min, long max)
    {
        if (min > max)
            throw new ArgumentException("min 必须小于等于 max");
    
        if (min == max)
            return min;
    
        // 用 double 作为中间值（精度足够）
        double range = (double)max - (double)min;
        double randomDouble = _random.NextDouble(); // 0 ~ 1
        long result = min + (long)(range * randomDouble);
    
        // 边界保护
        if (result < min) result = min;
        if (result > max) result = max;
    
        return result;
    }
}