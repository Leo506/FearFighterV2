public interface IStatisticData
{
    void Register();
    object GetValue();

    void UnRegister();
}
