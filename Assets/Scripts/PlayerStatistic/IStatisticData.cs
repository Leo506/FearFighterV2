public interface IStatisticData
{
    void Register();
    object GetValue();

    void SetValue(object value);

    void UnRegister();
}
