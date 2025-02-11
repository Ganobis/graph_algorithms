using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphAlgorithms.Interfaces;

public interface IWeightPathAlgorithm
{
	public void FindPath(int source, int destination);
	public List<int> GetPath();
	public int GetPathLength();
	public int GetWeightPath();
}