using System;

namespace ClassSystem
{
    class Order<TDelivery, TSting> where TDelivery : Delivery
    {
        public TDelivery delivery;

        public TSting address;        
    }
}
