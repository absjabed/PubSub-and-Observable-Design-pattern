using System;
using System.Threading.Tasks;

namespace pubSubEventDelegate{
    class Program{
        static void Main(string[] args){
            // Creating Instance of Publisher
            Publisher stackoverflow = new Publisher("StackOverflow.Com", 3000);
            Publisher facebook = new Publisher("Facebook.com", 1000);

            //Create Instances of Subscribers
            Subscriber sub1 = new Subscriber("Florin");
            Subscriber sub2 = new Subscriber("Piagio");
            Subscriber sub3 = new Subscriber("Shawn");
            
            //Pass the publisher obj to their Subscribe function
            sub1.Subscribe(facebook);
            sub3.Subscribe(facebook);

            sub1.Subscribe(stackoverflow);
            sub2.Subscribe(stackoverflow);
            
            //sub1.Unsubscribe(facebook);


            //Concurrently running multiple publishers thread
            Task task1 = Task.Factory.StartNew(() => facebook.Publish());
            Task task2 = Task.Factory.StartNew(() => stackoverflow.Publish());
            Task.WaitAll(task1, task2);

        }
    }
}
