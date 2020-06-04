using System;
class Subscriber{
    public string SubscriberName { get; private set; }

    public Subscriber(string _subscriberName){
        SubscriberName = _subscriberName;
    }
    
    // This function subscribe to the event if it is raised by the Publisher
    public void Subscribe(Publisher p){
        //https://www.tutorialsteacher.com/csharp/csharp-event
        // register OnNotificationReceived with publisher event
        p.OnPublish += OnNotificationReceived;  // multicast delegate 
    }

    // This function unsubscribe from the event if it is raised by the Publisher
    public void Unsubscribe(Publisher p){

        // unregister OnNotificationReceived from publisher
        p.OnPublish -= OnNotificationReceived;  // multicast delegate 
    }

    // It get executed when the event published by the Publisher
    protected virtual void OnNotificationReceived(Publisher p, NotificationEvent e){
    
        Console.WriteLine("Hey " + SubscriberName + ", " + e.NotificationMessage +" - "+ p.PublisherName + " at " + e.NotificationDate);
    }
}
