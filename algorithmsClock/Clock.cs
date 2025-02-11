using System.Diagnostics;

namespace algorithmsClock;

public static class Clock
{
	public static long[] BenchmarkCpuTwoArg(Action<int, int> action, (int, int)[] pars, Action clean, int iterations = 10000, int experiments = 5)
	{
		var stopwatch = new Stopwatch();
		var timings = new long[experiments];
		for (int i = 0; i < timings.Length; i++)
		{
			GarbageManually();
			stopwatch.Reset();
			for (int j = 0; j < iterations; j++)
			{
				clean();
				stopwatch.Start();
				action(pars[j].Item1, pars[j].Item2);
				stopwatch.Stop();
			}
			timings[i] = stopwatch.Elapsed.Ticks / iterations;
		}
		return timings;
	}

	public static long[] BenchmarkCpu(Action action, Action clean, int iterations = 10000, int experiments = 5)
	{
		var stopwatch = new Stopwatch();
		var timings = new long[experiments];
		for (int i = 0; i < timings.Length; i++)
		{
			GarbageManually();
			stopwatch.Reset();
			for (int j = 0; j < iterations; j++)
			{
				clean();
				stopwatch.Start();
				action();
				stopwatch.Stop();
			}
			timings[i] = stopwatch.Elapsed.Ticks / iterations;
		}
		return timings;
	}

	public static long OneMeasure(Action action)
	{
		GarbageManually();

		var stopwatch = new Stopwatch();
		stopwatch.Reset();
		stopwatch.Start();

		action();

		stopwatch.Stop();
		return stopwatch.Elapsed.Ticks;
	}

	public static void GarbageManually()
	{
		GC.Collect();
		GC.WaitForPendingFinalizers();
		GC.Collect();
	}
}