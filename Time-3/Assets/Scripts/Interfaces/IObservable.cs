
public interface IObservable<T>
{
    void subscribe(IObserver<T> observer);
    void unsubscribe(IObserver<T> observer);
}
