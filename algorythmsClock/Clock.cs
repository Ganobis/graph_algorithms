﻿using System.Diagnostics;

namespace algorithmsClock
{
	public static class Clock
	{

		class TimeWatch : IStopwatch
		{
			Stopwatch stopwatch = new Stopwatch();

			public TimeSpan Elapsed
			{
				get { return stopwatch.Elapsed; }
			}

			public bool IsRunning
			{
				get { return stopwatch.IsRunning; }
			}



			public TimeWatch()
			{
				if (!Stopwatch.IsHighResolution)
					throw new NotSupportedException("Your hardware doesn't support high resolution counter");

				//prevent the JIT Compiler from optimizing Fkt calls away
				long seed = Environment.TickCount;

				//use the second Core/Processor for the test
				Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);

				//prevent "Normal" Processes from interrupting Threads
				Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

				//prevent "Normal" Threads from interrupting this thread
				Thread.CurrentThread.Priority = ThreadPriority.Highest;
			}



			public void Start()
			{
				stopwatch.Start();
			}

			public void Stop()
			{
				stopwatch.Stop();
			}

			public void Reset()
			{
				stopwatch.Reset();
			}
		}



		class CpuWatch : IStopwatch
		{
			TimeSpan startTime;
			TimeSpan endTime;
			bool isRunning;



			public TimeSpan Elapsed
			{
				get
				{
					if (IsRunning)
						throw new NotImplementedException("Getting elapsed span while watch is running is not implemented");

					return endTime - startTime;
				}
			}

			public bool IsRunning
			{
				get { return isRunning; }
			}



			public void Start()
			{
				startTime = Process.GetCurrentProcess().TotalProcessorTime;
				isRunning = true;
			}

			public void Stop()
			{
				endTime = Process.GetCurrentProcess().TotalProcessorTime;
				isRunning = false;
			}

			public void Reset()
			{
				startTime = TimeSpan.Zero;
				endTime = TimeSpan.Zero;
			}
		}



		public static double[] BenchmarkTime(Action action, int iterations = 10000, int experiments = 5)
		{
			return Benchmark<TimeWatch>(action, iterations, experiments);
		}

		static double[] Benchmark<T>(Action action, int iterations, int experiments) where T : IStopwatch, new()
		{
			//clean Garbage
			// GC.Collect();

			//wait for the finalizer queue to empty
			// GC.WaitForPendingFinalizers();

			//clean Garbage
			//GC.Collect();

			GarbageManually();
			//warm up
			action();

			var stopwatch = new T();
			var timings = new double[experiments];
			for (int i = 0; i < timings.Length; i++)
			{
				GarbageManually();
				stopwatch.Reset();
				stopwatch.Start();
				for (int j = 0; j < iterations; j++)
				{
					action();
					//Console.WriteLine("i=" + i+ "\nj=" + j);
				}
				stopwatch.Stop();
				timings[i] = stopwatch.Elapsed.TotalMilliseconds / iterations;
			}
			//string asd = "normalized mean: " + timings.NormalizedMean().ToString();
			return timings;
		}

		public static double[] BenchmarkCpu(Action action, int iterations = 10000, int experiments = 5)
		{
			return Benchmark<CpuWatch>(action, iterations, experiments);
		}
		public static IEnumerable<Tuple<double, double>> Deviations(this ICollection<double> values)
		{
			if (values.Count == 0)
				yield break;

			var avg = values.Average();
			foreach (var d in values)
				yield return Tuple.Create(d, avg - d);
		}
		public static double NormalizedMean(this ICollection<double> values)
		{
			if (values.Count == 0)
				return double.NaN;

			var deviations = values.Deviations().ToArray();
			var meanDeviation = deviations.Sum(t => Math.Abs(t.Item2)) / values.Count;
			return deviations.Where(t => t.Item2 > 0 || Math.Abs(t.Item2) <= meanDeviation).Average(t => t.Item1);
		}

		public static void GarbageManually()
		{
			//clean Garbage
			GC.Collect();

			//wait for the finalizer queue to empty
			GC.WaitForPendingFinalizers();

			//clean Garbage
			GC.Collect();
		}


	}

}