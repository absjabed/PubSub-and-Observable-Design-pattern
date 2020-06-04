using System;
using System.Collections.Generic;
public class NotificationProvider : IObservable<SomeEvent>{
        
    public string ProviderName { get; private set; }
    // Maintain a list of observers
    private List<IObserver<SomeEvent>> _observers;

    public NotificationProvider(string _providerName){
        ProviderName = _providerName;
        _observers = new List<IObserver<SomeEvent>>();
    }

    // Define Unsubscriber class
    private class Unsubscriber : IDisposable{
        
        private List<IObserver<SomeEvent>> _observers;
        private IObserver<SomeEvent> _observer;

        public Unsubscriber(List<IObserver<SomeEvent>> observers,
                            IObserver<SomeEvent> observer){
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose(){
            if (!(_observer == null)) _observers.Remove(_observer);
        }
    }

    // Define Subscribe method
    public IDisposable Subscribe(IObserver<SomeEvent> observer){
        if (!_observers.Contains(observer))
            _observers.Add(observer);
        return new Unsubscriber(_observers, observer);
    }

    // Notify observers when event occurs
    public void EventNotification(string description){
        foreach (var observer in _observers){
            observer.OnNext(new SomeEvent(ProviderName, description,
                            DateTime.Now));
        }
    }
}
