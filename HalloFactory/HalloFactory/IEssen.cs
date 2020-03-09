namespace HalloFactory
{
    //public abstract class IEssen
    public interface IEssen
    {
        int Kcal { get; }
        string Beschreibung { get; }

        void Essen();
    }
}
