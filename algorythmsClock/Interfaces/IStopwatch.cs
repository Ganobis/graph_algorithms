using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmsClock.Interfaces
{
	internal interface IStopwatch
	{
		bool IsRunning { get; }
		TimeSpan Elapsed { get; }

		void Start();
		void Stop();
		void Reset();
	}
}
