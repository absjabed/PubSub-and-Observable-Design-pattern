﻿using System;
namespace ObserverObservablePattern{
    public class Program{
        public static void Main(string[] args){
            var fbObservable = new NotificationProvider("Facebook");
            var githubObservable = new NotificationProvider("GitHub");

            var observer = new NotificationSubscriber("Florin");
            observer.Subscribe(fbObservable);
            //observer.Unsubscribe();

            observer.Subscribe(githubObservable);
            //observer.Unsubscribe();

            var observer2 = new NotificationSubscriber("Piagio");
            observer2.Subscribe(fbObservable);

            fbObservable.EventNotification("Event notification 1 !");
            githubObservable.EventNotification("Event notification!");
        }
    }
}
