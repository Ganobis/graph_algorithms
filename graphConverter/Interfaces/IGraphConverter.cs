namespace graphConverter.Interfaces
{
	public interface IGraphConverter<T>
	{
		static abstract string GraphToTxt(T graph);
		static abstract T JsonToGraph(string path);
	}
}
